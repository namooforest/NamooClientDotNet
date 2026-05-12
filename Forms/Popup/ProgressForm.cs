using Namoo.Client.Config;
using Namoo.Frame;
using Namoo.Frame.Logger;
using Namoo.Frame.Message;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Namoo.Client.Forms.Popup
{
    public partial class ProgressForm : NaBaseXtraForm
    {
        private NaWorkerReq _wRequest;
        private NaWorkerRes _wResponse;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private CancellationTokenSource _pollingCts; // [수정] 클래스 멤버로 승격
        private DateTime _dtStartTime;

        public ProgressForm()
        {
            InitializeComponent();
            this.Load += ProgressForm_Load;
            this.Shown += ProgressForm_Shown;
        }

        public ProgressForm(NaWorkerReq spec) : this()
        {
            _wRequest = spec;
            this.Text = _wRequest.WorkerName;
            this.lblTitle.BaseControl.Font = new System.Drawing.Font("맑은 고딕", 10);
            this.lblTitle.BaseControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Text = _wRequest.WorkerName;

            // ProgressBar 초기 설정
            this.pgBar.Properties.Minimum = 0;
            this.pgBar.Properties.Maximum = 100;
        }

        private async void ProgressForm_Shown(object sender, EventArgs e)
        {
            // [수정] 폴링용 토큰 생성 (멤버 변수 사용)
            _pollingCts = new CancellationTokenSource();
            Task pollingTask = null;

            try
            {
                AddProgressMessage(_wRequest.WorkerName + " 호출", true);
                StartTicker();

                // 폴링을 독립적으로 실행
                pollingTask = PollProgressAsync(_wRequest.Header.TrxId, _pollingCts.Token);

                string sJsonMsg = NaFunctions.ConvertObjectToJsonString(_wRequest);
                var content = new StringContent(sJsonMsg, Encoding.UTF8, "application/json");

                // Request 로그 기록
                NaLogger.Logger(LogLevel.DEBUG, _wRequest.WorkerName, sJsonMsg);

                // 서버 호출 (CookieContainer 로 NAMOO_SESSION 유지)
                HttpResponseMessage response = await NamooServerHttp.Client.PostAsync(NaClientConfig.DoWorkEndpoint, content, _cts.Token);

                // 서버 응답이 오면 폴링 중단
                _pollingCts.Cancel();

                try
                {
                    if (pollingTask != null)
                        await pollingTask; // 폴링 종료까지 대기
                }
                catch { }

                response.EnsureSuccessStatusCode();

                string sReturn = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(sReturn))
                    throw new Exception("응답 데이터가 없습니다.");

                _wResponse = NaFunctions.ConvertJsonStringToObject<NaWorkerRes>(sReturn);

                // Response 로그 기록
                NaLogger.Logger(LogLevel.DEBUG, _wRequest.WorkerName, NaFunctions.ConvertObjectToJsonString(_wResponse));

                if (_wResponse.IsSuccess)
                {
                    this.DialogResult = DialogResult.OK;
                    EndWork(true);
                }
                else
                {
                    AddProgressMessage(_wResponse.Message);
                    EndWork(false);
                }
            }
            catch (OperationCanceledException)
            {
                // [수정] 예외 발생 시 폴링 확실하게 중단
                _pollingCts?.Cancel();
                AddProgressMessage("작업이 취소되었습니다.");
                EndWork(false);
            }
            catch (Exception ex)
            {
                // [수정] 예외 발생 시 폴링 확실하게 중단
                _pollingCts?.Cancel();
                AddProgressMessage("작업 중 오류가 발생했습니다: " + ex.Message);
                EndWork(false);
            }
        }

        public void EndWork(bool isSuccess)
        {
            StopTicker();

            if (this.IsDisposed) return; // [수정] 이미 닫힌 경우 처리 중단

            if (isSuccess)
            {
                AddProgressMessage("작업이 성공적으로 완료되었습니다.");
            }

            this.btnCancel.Text = "닫기";
            this.btnCancel.Enabled = true;
            this.pgBar.StyleController = null; // Indeterminate 모드 해제
            this.pgBar.Position = 100; // 진행률을 100%로 설정

            if (isSuccess)
                this.Close();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            this.btnCancel.Click += BtnCancel_Click;

            this.pgText.Font = new System.Drawing.Font("맑은 고딕", 8);
            this.pgText.ReadOnly = true;

            this.lblTicker.BaseControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // 이미 작업이 완료되어 '닫기' 버튼으로 바뀐 경우
            if (this.btnCancel.Text == "닫기")
            {
                this.Close();
                return;
            }

            // [수정] 취소 요청 상태에서 다시 클릭 시 강제 종료 처리
            if (this.btnCancel.Tag != null && this.btnCancel.Tag.ToString() == "CANCELLING")
            {
                if (MessageBox.Show("서버 응답을 기다리지 않고 강제로 종료하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _cts.Cancel(); // 클라이언트 연결 파기 -> PostAsync에서 예외 발생
                    _pollingCts?.Cancel();
                    this.Close();
                }
                return;
            }

            // -------------------------------------------------------
            // 취소 시에도 Response를 받기 위해 연결은 유지함
            // -------------------------------------------------------

            // 1. 서버 측 작업 취소 API 호출
            CancelServerWork(_wRequest.Header.TrxId);

            // 2. UI 업데이트
            AddProgressMessage("서버에 취소를 요청했습니다. 응답을 기다리는 중...");
            this.btnCancel.Text = "강제 종료";
            this.btnCancel.Tag = "CANCELLING"; // 상태 플래그 설정

            // this.Close(); <-- 삭제: 서버 응답이 오면 ProgressForm_Shown에서 자동으로 처리됨
        }

        public NaWorkerReq GetRequestWorker() { return _wRequest; }
        public NaWorkerRes GetResponseWorker() { return _wResponse; }

        // 진행 상황 조회 함수 예시
        public static async Task<string> GetProgressFromServer(string trxId)
        {
            return await NamooServerHttp.Client.GetStringAsync(NaClientConfig.ProgressEndpoint + $"?TrxId={trxId}");
        }

        // CancellationToken을 받아 폴링 중단 가능하게 수정
        private async Task PollProgressAsync(string trxId, CancellationToken token)
        {
            while (true)
            {
                // [수정] 취소 요청되면 루프 탈출 (OperationCanceledException 발생)
                token.ThrowIfCancellationRequested();

                string progress = "";
                try
                {
                    progress = await GetProgressFromServer(trxId);
                }
                catch
                {
                    // 조회 실패 시 무시하고 대기 후 재시도
                }

                try
                {
                    if (!string.IsNullOrEmpty(progress))
                    {
                        List<NaProgressMsg> liMsg = NaFunctions.ConvertJsonStringToObject<List<NaProgressMsg>>(progress);
                        if (liMsg != null && liMsg.Count > 0)
                        {
                            foreach (var msg in liMsg)
                            {
                                AddProgressMessage(msg);

                                if (msg.Message == "완료")
                                    return; // 완료 시 루프 종료
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    AddProgressMessage("진행 상황 조회 중 오류: " + ex.Message);
                    break;
                }

                await Task.Delay(1000, token); // 1초마다 조회, 취소 가능
            }
        }

        private async void CancelServerWork(string trxId)
        {
            try
            {
                await NamooServerHttp.Client.GetAsync(NaClientConfig.CancelWorkEndpoint + $"?TrxId={trxId}");
            }
            catch (Exception)
            {
                // 취소 요청 실패는 무시 (폼이 닫히거나 네트워크 문제 등)
            }
        }

        #region ▼▼▼ MessageBox ▼▼▼
        private void AddProgressMessage(NaProgressMsg msg, bool isFirst = false)
        {
            // 폼이 닫히거나 닫히는 중이면 무시
            if (this.IsDisposed || this.Disposing) return;

            if (this.pgText.InvokeRequired)
            {
                try
                {
                    this.pgText.Invoke(new Action(() =>
                    {
                        if (!this.IsDisposed && !this.Disposing)
                        {
                            this.pgText.AppendText(GetProgressMessage(msg, isFirst));
                            if (msg.Percent > 0)    // 0보다 큰 경우에만 진행률 업데이트
                                this.pgBar.Position = msg.Percent > 100 ? 100 : msg.Percent;
                        }
                    }));
                }
                catch { } // Invoke 중 폼 종료 시 예외 무시
            }
            else
            {
                this.pgText.AppendText(GetProgressMessage(msg, isFirst));
                if (msg.Percent > 0)    // 0보다 큰 경우에만 진행률 업데이트
                    this.pgBar.Position = msg.Percent > 100 ? 100 : msg.Percent;
            }
        }

        private void AddProgressMessage(string msg, bool isFirst = false)
        {
            NaProgressMsg progressMsg = new NaProgressMsg
            {
                Timestamp = DateTime.Now,
                Message = msg,
                Percent = 0
            };
            AddProgressMessage(progressMsg, isFirst);
        }

        private string GetProgressMessage(NaProgressMsg msg, bool isFirst = false)
        {
            string sFormat = "{0} | {1} | {2}";
            DateTime dtMgsTime = msg.Timestamp;
            TimeSpan diff = dtMgsTime - _dtStartTime;
            string sElipseTime = $"{diff.Minutes:D2}:{diff.Seconds:D2}"; // mm:ss
            string sStartTime = $"{msg.Timestamp:HH:mm:ss}";

            return (isFirst ? "" : $"{Environment.NewLine}") + string.Format(sFormat, sStartTime, sElipseTime, msg.Message);
        }
        #endregion ▲▲▲ MessageBox ▲▲▲

        #region ▼▼▼ Ticker ▼▼▼
        private System.Windows.Forms.Timer _tickerTimer;

        private void StartTicker()
        {
            _dtStartTime = DateTime.Now;
            _tickerTimer = new System.Windows.Forms.Timer();
            _tickerTimer.Interval = 100; // 0.1초
            _tickerTimer.Tick += TickerTimer_Tick;
            _tickerTimer.Start();
        }

        private void TickerTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now - _dtStartTime;
            lblTicker.Text = $"{diff.Minutes:D2}:{diff.Seconds:D2}";
        }

        private void StopTicker()
        {
            if (_tickerTimer != null)
            {
                _tickerTimer.Stop();
                _tickerTimer.Dispose();
                _tickerTimer = null;
            }
        }
        #endregion ▲▲▲ Ticker ▲▲▲
    }
}

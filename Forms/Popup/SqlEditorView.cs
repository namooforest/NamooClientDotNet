using DevExpress.XtraEditors;
using Namoo.Controls.DevExp.ExtMethods;
using Namoo.Controls.FormControl;
using Namoo.Database.SQL;
using Namoo.Frame;
using Namoo.Worker.Message;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Namoo.Controls.NaScintilla;

namespace Namoo.Client.Forms.Popup
{
    public partial class SqlEditorView : NaBaseXtraForm
    {
        DataTable _paramTable = new DataTable();
        NaSqlMapper _mapper = new NaSqlMapper();
        string _sSqlGroupId = null;
        string _sSqlId = null;
        string _sQuery = null;
        string _sSqlType = null;
        DataTable _dtSqlGroup = null;

        public SqlEditorView(DataTable dtSqlGroup)
        {
            InitializeComponent();
            this.Load += SqlNew_Load;

            if (dtSqlGroup.IsNullOrEmpty())
            {
                _dtSqlGroup = new DataTable();
                _dtSqlGroup.Columns.Add("SQL_GROUP_ID");
            }
            else
            {
                _dtSqlGroup = dtSqlGroup;
            }
        }

        public SqlEditorView(DataTable dtSqlGroup, string sSqlGroupId, string sSqlId, string sQuery, string sSqlType) : this(dtSqlGroup)
        {
            // 수정 모드로 초기화
            this.Text = "SQL 수정";
            _dtSqlGroup = dtSqlGroup;
            _sSqlGroupId = sSqlGroupId;
            _sSqlId = sSqlId;
            _sQuery = sQuery;
            _sSqlType = sSqlType;
        }

        private void SqlNew_Load(object sender, EventArgs e)
        {
            _paramTable.Columns.Add("KEY", typeof(string));
            _paramTable.Columns.Add("TYPE", typeof(string));
            _paramTable.Columns.Add("VALUE", typeof(string));

            InitControl();

            picExecute.Click += PicExecute_Click;
            txtQuery.TextChanged += TxtSql_TextChanged;
            btnSampleView.Click += BtnSampleView_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void InitControl()
        {
            // SQL GROUP ID
            gleSqlGroupId.SetDisplayMember("SQL_GROUP_ID");
            gleSqlGroupId.SetValueMember("SQL_GROUP_ID");
            gleSqlGroupId.ProcessNewValue += GleSqlGroupId_ProcessNewValue;
            if (_dtSqlGroup != null)
                gleSqlGroupId.SetDataTable(_dtSqlGroup);
            if (_sSqlGroupId != null)
            {
                gleSqlGroupId.SetValue(_sSqlGroupId);
                gleSqlGroupId.ReadOnly = true;
            }

            // SQL ID
            if (_sSqlId.IsNullOrEmpty() == false)
            {
                txtSqlId.SetValue(_sSqlId);
                txtSqlId.BaseControl.ReadOnly = true;
            }

            // SQL TYPE
            cmbSqlType.SetReadOnly();
            cmbSqlType.Properties.Items.AddRange(new string[] { "SELECT", "ELSE" });
            if (_sSqlType.IsNullOrEmpty() == false)
                cmbSqlType.SetValue(_sSqlType);
            else
                cmbSqlType.SelectedIndex = 0;

            // QUERY
            txtQuery.Syntax = SyntaxStyle.HandlebarsSql;
            if (_sQuery.IsNullOrEmpty() == false)
            {
                txtQuery.SetValue(_sQuery);
                TxtSql_TextChanged(null, null); // 이벤트 등록 전이라 수동 실행
            }

            // Parameter
            gvParameter.InitEditableGridView();
            gvParameter.AddTextColumn("KEY", "파라미터명").Editable(false).Width(100);
            gvParameter.AddTextColumn("TYPE", "유형").Editable(false).Width(80);
            gvParameter.AddTextColumn("VALUE", "값").Editable(true).Width(200);

            gvParameter.SetDataTable(_paramTable);
        }

        #region ▼▼▼ Control Event ▼▼▼
        private void GleSqlGroupId_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            // 신규 입력 처리를 위한 이벤트 처리
            GridLookUpEdit gle = (GridLookUpEdit)sender;
            string newValue = e.DisplayValue?.ToString().Trim();
            if (string.IsNullOrEmpty(newValue))
                return;

            string sDisplayMember = gle.GetDisplayMember();
            string sValueMember = gle.GetValueMember();
            DataTable dt = gle.GetDataTable();
            if (dt.IsNullOrEmpty())
            {
                // 새로운 임시 행 추가
                DataRow dr = dt.NewRow();
                dr[sDisplayMember] = newValue;
                dr[sValueMember] = newValue;
                dt.Rows.Add(dr);
            }
            else
            {
                // 1. 기존 데이터에 이미 존재하는지 확인 (있다면 추가할 필요 없음)
                DataRow[] existingRows = dt.Select(string.Format("{0} = '{1}'", sDisplayMember, newValue.Replace("'", "''")));

                if (existingRows.Length == 0)
                {
                    // RowState가 Added인 것을 찾아 삭제
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dt.Rows[i].RowState == DataRowState.Added)
                        {
                            dt.Rows[i].Delete();
                        }
                    }

                    // 3. 새로운 임시 행 추가
                    DataRow dr = dt.NewRow();
                    dr[sDisplayMember] = newValue;
                    dr[sValueMember] = newValue;
                    dt.Rows.Add(dr);
                }
            }

            e.Handled = true;
        }

        private void PicExecute_Click(object sender, EventArgs e)
        {
            gvParameter.AcceptChanes();
            string sSqlId = txtSqlId.GetValue().IsNullOrEmpty() ? "TempSqlId" : txtSqlId.GetValue();
            string sSqlType = cmbSqlType.GetValue();
            string sQuery = txtQuery.GetValue();
            if (string.IsNullOrEmpty(sSqlType) || string.IsNullOrEmpty(sQuery))
            {
                NaMsgBox.Warn("SQL유형과 쿼리는 필수값입니다.");
                return;
            }

            Dictionary<string, object> dicParam = new Dictionary<string, object>();
            foreach (DataRow row in _paramTable.Rows)
            {
                string key = row["KEY"].ToString();
                string value = row["VALUE"].ToString();
                dicParam.Add(key, value);
            }

            Dictionary<string, object> dicReqParam = new Dictionary<string, object>();
            dicReqParam.Add("CONN_NAME", conn.GetSelectedConnectorName());
            dicReqParam.Add("SQL_TYPE", sSqlType);
            dicReqParam.Add("QUERY", sQuery);
            dicReqParam.Add("PARAMS", dicParam);

            DataTable dtResult = null;
            string sMappedSql = null;
            if (sSqlType == "SELECT")
            {
                NaWorkerReq req = new NaWorkerReq("Namoo.ExecuteSelectSql", dicReqParam);
                NaWorkerRes res = CallWorker(req);
                if (res.IsSuccess == false)
                {
                    NaMsgBox.Error(res.Message);
                    return;
                }
                dtResult = res.GetResponseData<DataTable>("RESULT");
            }

            sMappedSql = _mapper.GetMappedQuery(sQuery, dicParam);

            SqlResultView resultView = new SqlResultView();
            resultView.Title = "SQL 실행 결과";
            resultView.SqlText = sMappedSql;
            resultView.ResultData = dtResult;
            resultView.StartPosition = FormStartPosition.CenterParent;
            resultView.ShowDialog();
        }

        private void TxtSql_TextChanged(object sender, EventArgs e)
        {
            string sSql = this.txtQuery.GetValue();
            if (string.IsNullOrEmpty(sSql))
            {
                _paramTable.Clear();
                return;
            }

            var foundParams = _mapper.GetParamKeys(sSql);
            gcParameter.BeginUpdate(); // 화면 깜빡임 방지
            try
            {
                // 1. 사라진 파라미터 삭제
                for (int i = _paramTable.Rows.Count - 1; i >= 0; i--)
                {
                    string rowKey = _paramTable.Rows[i]["KEY"].ToString();
                    if (!foundParams.Any(p => p.KEY == rowKey))
                        _paramTable.Rows.RemoveAt(i);
                }

                // 2. 새로운 파라미터 추가
                foreach (var p in foundParams)
                {
                    // 이미 테이블에 있는지 확인 (없을 때만 추가)
                    bool exists = _paramTable.AsEnumerable().Any(r => r["KEY"].ToString() == p.KEY);
                    if (exists == false)
                        _paramTable.Rows.Add(p.KEY, p.TYPE, "");
                }
            }
            finally
            {
                gcParameter.EndUpdate();
            }
        }

        private void BtnSampleView_Click(object sender, EventArgs e)
        {
            string sSampeSql = @"";
            sSampeSql += @"SELECT   U.USER_ID, U.USER_NAME, U.EMAIL, D.DEPT_NAME" + Environment.NewLine;
            sSampeSql += @"FROM     TB_USER U" + Environment.NewLine;
            sSampeSql += @"         LEFT JOIN TB_DEPT D" + Environment.NewLine;
            sSampeSql += @"             ON  U.DEPT_ID = D.DEPT_ID" + Environment.NewLine;
            sSampeSql += @"WHERE    1=1" + Environment.NewLine;
            sSampeSql += @"/* 1. 기본 변수 바인딩 (문자열) */" + Environment.NewLine;
            sSampeSql += @"AND      U.COMPANY_ID = '{{CompanyId}}'" + Environment.NewLine;
            sSampeSql += Environment.NewLine;
            sSampeSql += @"/* 2. 조건문: 참일 때 실행 (#if) - Boolean */" + Environment.NewLine;
            sSampeSql += @"{{#if IsActiveOnly}}" + Environment.NewLine;
            sSampeSql += @"AND      U.STATUS = 'ACTIVE'" + Environment.NewLine;
            sSampeSql += @"{{/if}}" + Environment.NewLine;
            sSampeSql += Environment.NewLine;
            sSampeSql += @"/* 3. 조건문: 거짓일 때 실행 (#unless) - Boolean */" + Environment.NewLine;
            sSampeSql += @"{{#unless ShowDeleted}}" + Environment.NewLine;
            sSampeSql += @"AND      U.DEL_YN = 'N'" + Environment.NewLine;
            sSampeSql += @"{{/unless}}" + Environment.NewLine;
            sSampeSql += Environment.NewLine;
            sSampeSql += @"/* 4. 값 비교 (#eq) - String/Number */" + Environment.NewLine;
            sSampeSql += @"{{#eq UserType ""ADMIN""}}" + Environment.NewLine;
            sSampeSql += @"AND      U.IS_ADMIN = 1" + Environment.NewLine;
            sSampeSql += @"{{/eq}}" + Environment.NewLine;
            sSampeSql += Environment.NewLine;
            sSampeSql += @"/* 5. 값 존재 여부 헬퍼 (#notEmpty) - String */" + Environment.NewLine;
            sSampeSql += @"{{#notEmpty SearchKeyword}}" + Environment.NewLine;
            sSampeSql += @"AND      (U.USER_NAME LIKE '%{{SearchKeyword}}%' OR U.EMAIL LIKE '%{{SearchKeyword}}%')" + Environment.NewLine;
            sSampeSql += @"{{/notEmpty}}" + Environment.NewLine;
            sSampeSql += Environment.NewLine;
            sSampeSql += @"/* 6. 리스트 순회 (#each) - List<String> */" + Environment.NewLine;
            sSampeSql += @"{{#notEmpty TargetDeptList}}" + Environment.NewLine;
            sSampeSql += @"AND      U.DEPT_ID IN (" + Environment.NewLine;
            sSampeSql += @"         {{#each TargetDeptList}}" + Environment.NewLine;
            sSampeSql += @"             '{{this}}'{{#unless @last}},{{/unless}} " + Environment.NewLine;
            sSampeSql += @"         {{/each}}" + Environment.NewLine;
            sSampeSql += @"         )" + Environment.NewLine;
            sSampeSql += @"{{/notEmpty}}";

            SqlResultView syntaxView = new SqlResultView();
            syntaxView.Title = "SQL 문법 보기";
            syntaxView.SqlText = sSampeSql;
            syntaxView.StartPosition = FormStartPosition.Manual;

            // 2. 현재 창(첫 번째 팝업)의 중앙 좌표 계산
            // (부모 좌측 좌표 + (부모 너비 - 자식 너비) / 2)
            syntaxView.Location = new Point(this.Location.X + (this.Width - syntaxView.Width) / 2, this.Location.Y + (this.Height - syntaxView.Height) / 2);

            syntaxView.Show(this);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sSqlGroupId = gleSqlGroupId.GetValue<string>();
            string sSqlId = txtSqlId.GetValue();
            string sQuery = txtQuery.GetValue();

            if (string.IsNullOrEmpty(sSqlGroupId) || string.IsNullOrEmpty(sSqlId) || string.IsNullOrEmpty(sQuery))
            {
                NaMsgBox.Warn("모든 항목은 필수값입니다.");
                return;
            }

            if (NaMsgBox.Confirm("저장 하시겠습니까?") != DialogResult.OK)
                return;

            Dictionary<string, object> dicParam = new Dictionary<string, object>();
            dicParam.Add("SQL_GROUP_ID", sSqlGroupId);
            dicParam.Add("SQL_ID", sSqlId);
            dicParam.Add("SQL_TYPE", cmbSqlType.GetValue());
            dicParam.Add("QUERY", sQuery);

            NaWorkerReq req = new NaWorkerReq("Namoo.SaveSql", dicParam);
            NaWorkerRes res = CallWorker(req);
            if (res.IsSuccess == false)
            {
                NaMsgBox.Error(res.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion ▲▲▲ Control Event ▲▲▲
    }
}

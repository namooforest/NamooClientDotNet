using Namoo.Controls.EventArguments;
using Namoo.Controls.FormControl;
using Namoo.Controls.StyleSet;
using Namoo.Frame;
using Namoo.Frame.DTO.Entity;
using Namoo.Frame.NaExceptions;
using Namoo.Worker.Message;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Namoo.Client.Forms.Config
{
    public partial class ConnectionManager : NaBaseXtraForm
    {
        private string _sDefaultConnectorName = null;

        public ConnectionManager()
        {
            InitializeComponent();
            this.Load += DBConnection_Load;
            this.Shown += DBConnection_Shown;
        }

        private void DBConnection_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        private void DBConnection_Shown(object sender, EventArgs e)
        {
            SelectData(null);
        }

        private void InitControl()
        {
            dgConnList.AddColumn("DB_NAME", "이름");
            dgConnList.AddColumn("DB_DESCRIPTION", "설명", 140);
            dgConnList.AddColumn("USE_YN", "사용여부", 100);
            dgConnList.Styler("USE_YN").Align(CellHAlign.Center);
            dgConnList.Editable = false;
            dgConnList.SelectionChanged += DgConnList_SelectionChanged;
            dgConnList.BaseControl.MultiSelect = false;
            dgConnList.BaseControl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            #region ■■ 입력 영역 ■■
            var values = Enum.GetValues(typeof(DBTypes));
            foreach (var val in values)
                cmbDBType.AddValue(val);

            cmbDBType.ReadOnly = true;
            cmbDBType.BaseControl.SelectedIndexChanged += CmbDBType_SelectedIndexChanged;
            CmbDBType_SelectedIndexChanged(null, null);

            txtPort.BaseControl.KeyPress += TxtPort_KeyPress;

            txtPassword.BaseControl.PasswordChar = '●';
            picShowPass.MouseDown += PicShowPass_MouseDown;
            picShowPass.MouseUp += PicShowPass_MouseUp;

            picPath.Click += PicPath_Click;

            picAddOption.Click += PicAddRemoveOption_Click;
            picRemoveOption.Click += PicAddRemoveOption_Click;
            dgOption.AddColumn("OPTION_KEY", "키", 100);
            dgOption.AddColumn("OPTION_VALUE", "값");
            dgOption.DataSource = GetEmptyOptions();
            #endregion

            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnTest.Click += BtnTest_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        #region ▼▼▼ Event Definition ▼▼▼
        private void PicPath_Click(object sender, EventArgs e)
        {
            NaFileBrowser fileBrowser = new NaFileBrowser();
            fileBrowser.ShowFiles = true;
            fileBrowser.StartPath = txtFilePath.Text;
            fileBrowser.ShowFileNameInputBox = false;
            fileBrowser.StartPosition = FormStartPosition.CenterParent;

            if (fileBrowser.ShowDialog() != DialogResult.OK)
                return;

            txtFilePath.Text = fileBrowser.GetPath();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputBox();
            chkUse.Checked = true;
            txtName.Enabled = true;
            dgConnList.BaseControl.ClearSelection();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataRow drSelect = dgConnList.GetSelectedRowData();
            if (drSelect == null)
            {
                NaMsgBox.Alert("선택된 값이 없습니다.");
                return;
            }

            if (chkDefault.Checked)
            {
                NaMsgBox.Alert("기본 연결은 삭제할 수 없습니다.");
                return;
            }

            string sName = Convert.ToString(drSelect["DB_NAME"]);

            if (NaMsgBox.Confirm("[" + sName + "] 삭제하시겠습니까 ? ") != DialogResult.OK)
                return;

            try
            {
                Dictionary<string, object> dicData = new Dictionary<string, object>();
                dicData.Add("CONN_NAME", sName);

                NaWorkerReq spec = new NaWorkerReq("Namoo.ConnectionManager.DeleteConnector", dicData);
                NaWorkerRes ret = CallWorker(spec);

                if (ret.IsSuccess == false)
                {
                    NaMsgBox.Error("삭제에 실패했습니다.", Convert.ToString(ret.ResponseData["MESSAGE"]));
                    return;
                }
                else
                {
                    NaMsgBox.Info("삭제되었습니다.");
                    SelectData(null);
                }
            }
            catch (Exception ex)
            {
                NaMsgBox.Error("삭제 실패했습니다.", ex.Message, ex);
                return;
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            NA_CFG_DATABASE cfg = GetInputData();

            // 서버에서 클라이언트 설정 정보 가져오기
            Dictionary<string, object> dicParam = new Dictionary<string, object>();
            dicParam.Add("CONNECTION_INFO", cfg);

            NaWorkerReq req = new NaWorkerReq("Namoo.Server.Common.ConnectionTest", dicParam);
            NaBaseFormHelper helper = new NaBaseFormHelper();
            NaWorkerRes res = helper.CallWorker(req);
            if (res.IsSuccess)
                NaMsgBox.Alert("연결 테스트 성공");
            else
                NaMsgBox.Error("연결 테스트 실패", res.Message);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            NA_CFG_DATABASE data = GetInputData();
            if (ValueValidation(data) == false)
                return;

            try
            {
                Dictionary<string, object> dicData = new Dictionary<string, object>();
                dicData.Add("DATA", data);
                dicData.Add("IS_DEFAULT", chkDefault.Checked ? "Y" : "N");

                NaWorkerReq spec = new NaWorkerReq("Namoo.ConnectionManager.SaveConnector", dicData);
                NaWorkerRes ret = CallWorker(spec);

                if (ret.IsSuccess == false)
                {
                    NaMsgBox.Error("저장 실패했습니다.", ret.Message);
                    return;
                }
                else
                {
                    NaMsgBox.Info("저장되었습니다.");
                    SelectData(data.DbName);
                }
            }
            catch (Exception ex)
            {
                NaMsgBox.Error("저장 실패했습니다.", ex.Message, ex);
                return;
            }
        }

        private void CmbDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSelect = cmbDBType.GetValue();
            if (string.IsNullOrEmpty(sSelect))
                return;

            DBTypes types = (DBTypes)Enum.Parse(typeof(DBTypes), sSelect);
            switch (types)
            {
                case DBTypes.PostgreSQL:
                case DBTypes.MySql8x:
                case DBTypes.MariaDB:
                    pnlIP.Visible = true;
                    pnlDatabase.Visible = true;
                    pnlServiceName.Visible = false;
                    pnlIdPw.Visible = true;
                    pnlFilePath.Visible = false;
                    break;
                case DBTypes.Oracle11g:
                    pnlIP.Visible = true;
                    pnlDatabase.Visible = false;
                    pnlServiceName.Visible = true;
                    pnlIdPw.Visible = true;
                    pnlFilePath.Visible = false;
                    break;
                case DBTypes.SQLite:
                    pnlIP.Visible = false;
                    pnlDatabase.Visible = false;
                    pnlServiceName.Visible = false;
                    pnlIdPw.Visible = false;
                    pnlFilePath.Visible = true;
                    break;
                case DBTypes.SQLServer:
                    pnlIP.Visible = true;
                    pnlDatabase.Visible = true;
                    pnlServiceName.Visible = false;
                    pnlIdPw.Visible = true;
                    pnlFilePath.Visible = false;
                    break;
                default:
                    throw new NaException("Not Support DB Type : " + types.ToString());
            }
        }

        private void DgConnList_SelectionChanged(object sender, NaSelectChangeArgs e)
        {
            DataRow drSelect = e.SelectedDataRow;
            if (drSelect == null)
                return;

            txtName.Enabled = false;
            txtName.Text = Convert.ToString(drSelect["DB_NAME"]);
            cmbDBType.SetValue(Convert.ToString(drSelect["DB_TYPE"]));
            chkUse.Checked = Convert.ToString(drSelect["USE_YN"]) == "Y" ? true : false;
            txtDescription.Text = Convert.ToString(drSelect["DB_DESCRIPTION"]);
            txtIp.Text = Convert.ToString(drSelect["IP"]);
            txtPort.Text = Convert.ToString(drSelect["PORT"]);
            txtDatabase.Text = Convert.ToString(drSelect["DATABASE"]);
            txtServiceName.Text = Convert.ToString(drSelect["SERVICE_NAME"]);
            txtId.Text = Convert.ToString(drSelect["ID"]);
            txtPassword.Text = Convert.ToString(drSelect["PASSWORD"]);
            txtFilePath.Text = Convert.ToString(drSelect["FILE_PATH"]);
            string sOptions = Convert.ToString(drSelect["OPTIONS"]);
            if (string.IsNullOrEmpty(sOptions) == false)
                dgOption.DataSource = NaFunctions.ConvertJsonStringToObject<DataTable>(sOptions);
            else
                dgOption.DataSource = null;

            if (txtName.Text.Equals(_sDefaultConnectorName))
                chkDefault.Checked = true;
            else
                chkDefault.Checked = false;
        }

        private void PicShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.BaseControl.PasswordChar = '●';
        }

        private void PicShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.BaseControl.PasswordChar = '\0';
        }

        private void TxtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void PicAddRemoveOption_Click(object sender, EventArgs e)
        {
            if (sender == picAddOption)
            {
                dgOption.DataSource.Rows.Add();
            }
            else if (sender == picRemoveOption)
            {
                DataRow drSelect = dgOption.GetSelectedRowData();
                if (drSelect == null)
                {
                    NaMsgBox.Alert("선택된 값이 없습니다.");
                    return;
                }
                dgOption.DataSource.Rows.Remove(drSelect);
            }
        }
        #endregion ▲▲▲ Event Definition ▲▲▲

        #region ▼▼▼ Methods Definition ▼▼▼
        private NA_CFG_DATABASE GetInputData()
        {
            NA_CFG_DATABASE cfg = new NA_CFG_DATABASE();
            string sName = txtName.Text;
            string sDBType = Convert.ToString(cmbDBType.BaseControl.SelectedValue);
            DBTypes dbType = (DBTypes)Enum.Parse(typeof(DBTypes), sDBType);
            string sDescription = txtDescription.Text;
            string sIp = txtIp.Text;
            string sPort = txtPort.Text;
            string sDatabase = txtDatabase.Text;
            string sServiceName = txtServiceName.Text;
            string sId = txtId.Text;
            string sPassword = txtPassword.Text;
            string sFilePath = txtFilePath.Text;

            switch (dbType)
            {
                case DBTypes.PostgreSQL:
                case DBTypes.MySql8x:
                case DBTypes.MariaDB:
                    cfg.DbType = dbType;
                    cfg.Ip = sIp;
                    cfg.Port = sPort;
                    cfg.Database = sDatabase;
                    cfg.Id = sId;
                    cfg.Password = sPassword;
                    break;
                case DBTypes.Oracle11g:
                    cfg.DbType = DBTypes.Oracle11g;
                    cfg.Ip = sIp;
                    cfg.Port = sPort;
                    cfg.Database = sDatabase;
                    cfg.ServiceName = sServiceName;
                    cfg.Id = sId;
                    cfg.Password = sPassword;
                    break;
                case DBTypes.SQLite:
                    cfg.DbType = DBTypes.SQLite;
                    cfg.FilePath = sFilePath;
                    break;
                case DBTypes.SQLServer:
                    cfg.DbType = DBTypes.SQLServer;
                    cfg.Ip = sIp;
                    cfg.Port = sPort;
                    cfg.Database = sDatabase;
                    cfg.Id = sId;
                    cfg.Password = sPassword;
                    break;
            }

            cfg.DbName = sName;
            cfg.DbType = dbType;
            cfg.DbDescription = sDescription;
            cfg.UseYn = chkUse.Checked ? "Y" : "N";

            dgOption.DataSource.AcceptChanges();
            cfg.Options = NaFunctions.ConvertObjectToJsonString(dgOption.DataSource);

            return cfg;
        }

        private void ClearInputBox()
        {
            txtName.Text = string.Empty;
            cmbDBType.SetSelectedIndex(0);
            txtDescription.Text = string.Empty;
            txtIp.Text = string.Empty;
            txtPort.Text = string.Empty;
            txtDatabase.Text = string.Empty;
            txtServiceName.Text = string.Empty;
            txtId.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFilePath.Text = string.Empty;
            dgOption.DataSource = GetEmptyOptions();
        }

        private bool ValueValidation(NA_CFG_DATABASE data)
        {
            DBTypes type = data.DbType;
            List<string> chkList = new List<string>();
            // 공통
            if (string.IsNullOrEmpty(txtName.Text))
                chkList.Add(txtName.Text);

            // DB 별 확인
            if (type == DBTypes.SQLite)
            {
                if (string.IsNullOrEmpty(txtFilePath.Text))
                    chkList.Add(lblFilePath.Text);
            }
            else
            {
                if (string.IsNullOrEmpty(txtIp.Text))
                    chkList.Add(lblIp.Text);
                if (string.IsNullOrEmpty(txtPort.Text))
                    chkList.Add(lblPort.Text);
                if (string.IsNullOrEmpty(txtId.Text))
                    chkList.Add(lblId.Text);
                if (string.IsNullOrEmpty(txtPassword.Text))
                    chkList.Add(lblPassword.Text);

                if (type == DBTypes.Oracle11g)
                {
                    if (string.IsNullOrEmpty(txtServiceName.Text))
                        chkList.Add(lblServiceName.Text);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtDatabase.Text))
                        chkList.Add(lblDatabase.Text);
                }
            }

            if (chkList.Count > 0)
            {
                NaMsgBox.Alert(string.Format("다음 항목은 필수 값입니다.\n{0}", string.Join(", ", chkList.ToArray())));
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SelectData(string sDBName)
        {
            _sDefaultConnectorName = null;
            NaWorkerReq spec = new NaWorkerReq("Namoo.ConnectionManager.SelectConnectorList");
            NaWorkerRes ret = CallWorker(spec);
            if (ret.IsSuccess == false)
                return;

            _sDefaultConnectorName = ret.GetResponseData<string>("DEFAULT_CONNECTOR");
            List<NA_CFG_DATABASE> connList = ret.GetResponseData<List<NA_CFG_DATABASE>>("CONN_LIST");
            if (connList == null || connList.Count == 0)
            {
                dgConnList.DataSource = null;
                MessageBox.Show("조회된 데이터가 없습니다.");
                return;
            }

            DataTable dt = NaFunctions.ConvertObjectToDataTable(connList);
            dgConnList.DataSource = dt;

            if (string.IsNullOrEmpty(sDBName) == false)
                dgConnList.SetSelectRow("NAME", sDBName);
        }

        private DataTable GetEmptyOptions()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OPTION_KEY", typeof(string));
            dt.Columns.Add("OPTION_VALUE", typeof(string));
            return dt;
        }
        #endregion ▲▲▲ Methods Definition ▲▲▲
    }
}

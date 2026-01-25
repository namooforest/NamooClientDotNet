using Namoo.Client.Forms.Popup;
using Namoo.Controls.DevExp.ExtMethods;
using Namoo.Controls.FormControl;
using Namoo.Frame;
using Namoo.Frame.DTO.Entity;
using Namoo.Worker.Message;
using System;
using System.Collections.Generic;
using System.Data;

namespace Namoo.Client.Forms.Frame
{
    public partial class SqlManager : NaBaseXtraForm
    {
        public SqlManager()
        {
            InitializeComponent();
            this.Load += SqlManager_Load;
        }

        private void SqlManager_Load(object sender, EventArgs e)
        {
            InitControl();
            SelectSqlGroupList(null);
        }

        private void InitControl()
        {
            picNew.Click += PicNew_Click;
            picRemove.Click += PicRemove_Click;

            gvSqlGroupList.InitReadOnlyGridView();
            gvSqlGroupList.AddTextColumn("SQL_GROUP_ID", "SQL 그룹 ID").Width(200);
            gvSqlGroupList.FocusedRowChanged += GvSqlGroupList_FocusedRowChanged;

            gvSqlList.InitEditableGridView();
            gvSqlList.AddCheckColumn("CHK_YN", " ", "Y", "N");
            gvSqlList.AddTextColumn("SQL_ID", "SQL ID").Editable(false);
            //gvSqlList.AddTextColumn("SQL_DESCRIPTION", "Description").Editable(false);
            gvSqlList.AddTextColumn("SQL_TYPE", "Type").Editable(false);
            gvSqlList.AddTextColumn("CREATE_USER_ID", "생성자").Editable(false);
            gvSqlList.AddDateTimeColumn("CREATE_TIME", "생성일시").Width(140).Editable(false);
            gvSqlList.AddTextColumn("UPDATE_USER_ID", "수정자").Editable(false);
            gvSqlList.AddDateTimeColumn("UPDATE_TIME", "수정일시").Width(140).Editable(false);

            gvSqlList.DoubleClick += GvSqlList_DoubleClick;
        }

        #region ▼▼▼ Call Worker Methods ▼▼▼
        private void SelectSqlGroupList(string sSqlGroupId)
        {
            gvSqlGroupList.ClearDataTable();

            NaWorkerReq req = new NaWorkerReq("Namoo.Server.SqlManager.SelectSqlGroupList");
            NaWorkerRes res = CallWorker(req);
            if (res.IsSuccess == false)
            {
                NaMsgBox.Alert(res.Message);
                return;
            }

            DataTable dt = res.GetResponseData<DataTable>("SQL_GROUP_LIST");
            if (dt.IsNullOrEmpty())
            {
                dt = new DataTable();
                dt.Columns.Add("SQL_GROUP_ID", typeof(string));
            }

            gvSqlGroupList.SetDataTable(dt);

            if (sSqlGroupId.IsNullOrEmpty() == false)
                gvSqlGroupList.SetSelectRow("SQL_GROUP_ID", sSqlGroupId);
        }

        private void SelectSqlList(string sSqlGroupId)
        {
            gvSqlList.ClearDataTable();

            Dictionary<string, object> dicParam = new Dictionary<string, object>();
            dicParam.Add("SQL_GROUP_ID", sSqlGroupId);

            NaWorkerReq req = new NaWorkerReq("Namoo.Server.SqlManager.SelectSqlList", dicParam);
            NaWorkerRes res = CallWorker(req);
            if (res.IsSuccess == false)
            {
                NaMsgBox.Alert(res.Message);
                return;
            }

            DataTable dt = res.GetResponseData<DataTable>("SQL_LIST");

            gvSqlList.SetDataTable(dt);
            gvSqlList.BestFitColumns();
        }

        private NA_SQL GetQuery(string sSqlGroupId, string sSqlId)
        {
            Dictionary<string, object> dicParam = new Dictionary<string, object>();
            dicParam.Add("SQL_GROUP_ID", sSqlGroupId);
            dicParam.Add("SQL_ID", sSqlId);

            NaWorkerReq req = new NaWorkerReq("Namoo.Server.SqlManager.GetSqlData", dicParam);
            NaWorkerRes res = CallWorker(req);
            if (res.IsSuccess == false)
            {
                NaMsgBox.Alert(res.Message);
                return null;
            }

            return res.GetResponseData<NA_SQL>("SQL_DATA");
        }

        private void DeleteSqlList(List<DataRow> liSelect)
        {
            Dictionary<string, object> dicParam = new Dictionary<string, object>();
            dicParam.Add("SQL_ID_LIST", liSelect.CopyToDataTable());

            NaWorkerReq req = new NaWorkerReq("Namoo.Server.SqlManager.DeleteSqlList", dicParam);
            NaWorkerRes res = CallWorker(req);

            if (res.IsSuccess)
            {
                NaMsgBox.Alert("선택한 SQL이 삭제되었습니다.");

                string sSqlGroupId = gvSqlGroupList.GetSelectedData<string>("SQL_GROUP_ID");
                // 삭제 후 SQL 리스트 재조회
                SelectSqlGroupList(sSqlGroupId);
            }
            else
            {
                NaMsgBox.Alert(res.Message);
            }
        }
        #endregion ▲▲▲ Call Worker Methods ▲▲▲

        #region ▼▼▼ Event Methods ▼▼▼
        /// <summary>SQL 신규 등록</summary>
        private void PicNew_Click(object sender, EventArgs e)
        {
            SqlEditorView popup = new SqlEditorView(gvSqlGroupList.GetDataTable());
            popup.Text = "SQL 신규 등록";
            popup.Width = 1000;
            popup.Height = 500;
            popup.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            popup.ShowDialog();

            // 신규 등록 후 SQL 그룹 리스트 재조회 (신규 등록 시 SQL 그룹도 함께 등록되므로)
            SelectSqlGroupList(null);
        }

        /// <summary>SQL 삭제</summary>
        private void PicRemove_Click(object sender, EventArgs e)
        {
            gvSqlList.AcceptChanes();
            List<DataRow> liSelect = gvSqlList.GetCheckedDataRows("CHK_YN");
            if (liSelect.IsNullOrEmpty())
            {
                NaMsgBox.Alert("삭제할 SQL을 선택하세요.");
                return;
            }
            else if (NaMsgBox.Confirm("선택한 SQL을 삭제하시겠습니까?") != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            DeleteSqlList(liSelect);
        }

        private void GvSqlGroupList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gvSqlList.ClearDataTable();
            string sSqlGroupId = gvSqlGroupList.GetSelectedData<string>("SQL_GROUP_ID");
            if (sSqlGroupId.IsNullOrEmpty())
                return;

            SelectSqlList(sSqlGroupId);
        }

        private void GvSqlList_DoubleClick(object sender, EventArgs e)
        {
            DataRow drSelect = gvSqlList.GetSelectedDataRow();
            if (drSelect == null)
                return;

            string sSqlGroupId = drSelect["SQL_GROUP_ID"].ToString();
            string sSqlId = drSelect["SQL_ID"].ToString();

            NA_SQL naSql = GetQuery(sSqlGroupId, sSqlId);
            if (naSql == null)
                return;

            SqlEditorView popup = new SqlEditorView(gvSqlGroupList.GetDataTable(), sSqlGroupId, sSqlId, naSql.Query, naSql.SqlType);
            popup.Text = "SQL 편집";
            popup.Width = 1000;
            popup.Height = 500;
            popup.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            popup.ShowDialog();

            // 편집 후 SQL 리스트 재조회
            SelectSqlList(sSqlGroupId);
        }
        #endregion ▲▲▲ Event Methods ▲▲▲
    }
}

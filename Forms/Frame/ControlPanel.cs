using Namoo.Controls.FormControl;
using Namoo.Frame.DTO;
using Namoo.Worker.Message;
using System;
using System.Collections.Generic;

namespace Namoo.Client.Forms.Frame
{
    public partial class ControlPanel : NaBaseXtraForm
    {
        public ControlPanel()
        {
            InitializeComponent();
            this.Load += ControlPanel_Load;
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            this.btnSetupDatabase.Click += BtnSetupDatabase_Click;
            this.btnProgressTest.Click += BtnProgressTest_Click;
            this.btnExecute.Click += BtnExecute_Click;
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            NaConnector conn = dbConnector.GetSelectedConnector();

            Dictionary<string, object> dicQueryParam = new Dictionary<string, object>();
            dicQueryParam.Add("SEARCH_TEXT", "ASDDF");

            Dictionary<string, object> dicWorkerParam = new Dictionary<string, object>();
            dicQueryParam.Add("TEST_TYPE", "SQL_TEST");
            dicWorkerParam.Add("SQL_GROUP_ID", txtSqlGroupId.GetValue());
            dicWorkerParam.Add("SQL_ID", txtSqlId.GetValue());
            dicWorkerParam.Add("PARAMETER", dicQueryParam);

            NaWorkerRes res = CallWorker(new NaWorkerReq("Namoo.TestWorker.TestWorker", dicWorkerParam, conn));
            if (res.IsSuccess)
                NaMsgBox.Confirm("Query executed successfully.");
            else
                NaMsgBox.Error("Query execution failed.\n" + res.Message);
        }

        private void BtnSetupDatabase_Click(object sender, EventArgs e)
        {
            NaWorkerRes res = CallWorker("Namoo.DefaultWorker.InitializeSetup");
            if (res.IsSuccess)
                NaMsgBox.Confirm("Database setup completed successfully.");
            else
                NaMsgBox.Error("Database setup failed.\n" + res.Message);
        }

        private void BtnProgressTest_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dicWorkerParam = new Dictionary<string, object>();
            dicWorkerParam.Add("TEST_TYPE", "PROGRESS_TEST");
            NaWorkerRes res = CallWorker("Namoo.DefaultWorker.TestWorker.ProgressTest", dicWorkerParam);
            if (res.IsSuccess)
                NaMsgBox.Confirm("Progress test completed.");
        }
    }
}

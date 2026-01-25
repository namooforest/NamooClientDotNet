using DevExpress.XtraEditors;
using System;

namespace Namoo.Client.Forms.Config
{
    public partial class LogManager : XtraForm
    {
        public LogManager()
        {
            InitializeComponent();
            this.Load += LogConfig_Load;
        }

        private void LogConfig_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void InitControls()
        {
            tcLogInfo.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            tpAppender.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            tpLogger.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
        }
    }
}
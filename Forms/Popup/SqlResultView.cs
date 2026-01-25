using Namoo.Controls.DevExp.ExtMethods;
using System;
using System.Data;
using static Namoo.Controls.NaScintilla;

namespace Namoo.Client.Forms.Popup
{
    public partial class SqlResultView : NaBaseXtraForm
    {
        public string Title { get => this.Text; set => this.Text = value; }
        public string SqlText { private get; set; }
        public DataTable ResultData { private get; set; }

        public SqlResultView()
        {
            InitializeComponent();
            this.Load += SqlTest_Load;
        }

        private void SqlTest_Load(object sender, EventArgs e)
        {
            this.btnClose.Click += BtnClose_Click;

            if (ResultData == null || ResultData.Rows.Count == 0)
            {
                this.scMain.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.False;
                this.scMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
                this.scMain.Collapsed = true;
                this.scMain.IsSplitterFixed = true;
                this.scMain.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            }
            else
            {
                this.scMain.IsSplitterFixed = false;
                this.scMain.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.True;

                this.gvResult.InitReadOnlyGridView();
                this.gvResult.SetAutoGenerateColumns(true);
                this.gvResult.SetDataTable(ResultData);
            }

            this.sqlText.Syntax = SyntaxStyle.HandlebarsSql;
            this.sqlText.Text = SqlText;
            this.sqlText.ReadOnly = true;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

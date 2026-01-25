namespace Namoo.Client.Forms.Popup
{
    partial class SqlResultView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnClose = new Namoo.Controls.NaButton();
            this.scMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.sqlText = new Namoo.Controls.NaScintilla();
            this.gcResult = new DevExpress.XtraGrid.GridControl();
            this.gvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain.Panel1)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain.Panel2)).BeginInit();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnClose);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 414);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Padding = new System.Windows.Forms.Padding(3);
            this.pnlButton.Size = new System.Drawing.Size(800, 36);
            this.pnlButton.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("Gulim", 9F);
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(794, 30);
            this.btnClose.StyleSet = null;
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            // 
            // scMain
            // 
            this.scMain.Collapsed = true;
            this.scMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.sqlText);
            this.scMain.Panel1.Text = "Panel1";
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gcResult);
            this.scMain.Panel2.Text = "Panel2";
            this.scMain.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.False;
            this.scMain.Size = new System.Drawing.Size(800, 414);
            this.scMain.SplitterPosition = 400;
            this.scMain.TabIndex = 1;
            // 
            // sqlText
            // 
            this.sqlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlText.EditorText = "";
            this.sqlText.LineNumberVisible = false;
            this.sqlText.Location = new System.Drawing.Point(0, 0);
            this.sqlText.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.sqlText.Name = "sqlText";
            this.sqlText.ReadOnly = false;
            this.sqlText.Size = new System.Drawing.Size(790, 414);
            this.sqlText.Syntax = Namoo.Controls.NaScintilla.SyntaxStyle.SQL;
            this.sqlText.TabIndex = 0;
            this.sqlText.Text = "";
            // 
            // gcResult
            // 
            this.gcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcResult.Location = new System.Drawing.Point(0, 0);
            this.gcResult.MainView = this.gvResult;
            this.gcResult.Name = "gcResult";
            this.gcResult.Size = new System.Drawing.Size(0, 0);
            this.gcResult.TabIndex = 0;
            this.gcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvResult});
            // 
            // gvResult
            // 
            this.gvResult.GridControl = this.gcResult;
            this.gvResult.Name = "gvResult";
            // 
            // SqlResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlButton);
            this.Name = "SqlResultView";
            this.Text = "SqlTest";
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain.Panel1)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain.Panel2)).EndInit();
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButton;
        private DevExpress.XtraEditors.SplitContainerControl scMain;
        private Controls.NaScintilla sqlText;
        private DevExpress.XtraGrid.GridControl gcResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gvResult;
        private Controls.NaButton btnClose;
    }
}
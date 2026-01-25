using System.Windows.Forms;

namespace Namoo.Client.Forms.Config
{
    partial class LogManager
    {
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

        private void InitializeComponent()
        {
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scRel = new System.Windows.Forms.SplitContainer();
            this.dgLoggerList = new Namoo.Controls.NaDataGrid();
            this.pnlLogger = new System.Windows.Forms.Panel();
            this.lblLogger = new System.Windows.Forms.Label();
            this.dgAppenderList = new Namoo.Controls.NaDataGrid();
            this.pnlAppender = new System.Windows.Forms.Panel();
            this.lblAppender = new System.Windows.Forms.Label();
            this.pnlRel = new System.Windows.Forms.Panel();
            this.picRelSave = new System.Windows.Forms.PictureBox();
            this.lblRel = new System.Windows.Forms.Label();
            this.tcLogInfo = new DevExpress.XtraTab.XtraTabControl();
            this.tpLogger = new DevExpress.XtraTab.XtraTabPage();
            this.tpAppender = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scRel)).BeginInit();
            this.scRel.Panel1.SuspendLayout();
            this.scRel.Panel2.SuspendLayout();
            this.scRel.SuspendLayout();
            this.pnlLogger.SuspendLayout();
            this.pnlAppender.SuspendLayout();
            this.pnlRel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRelSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcLogInfo)).BeginInit();
            this.tcLogInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.scRel);
            this.scMain.Panel1.Controls.Add(this.pnlRel);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.tcLogInfo);
            this.scMain.Size = new System.Drawing.Size(1232, 745);
            this.scMain.SplitterDistance = 409;
            this.scMain.TabIndex = 1;
            // 
            // scRel
            // 
            this.scRel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scRel.Location = new System.Drawing.Point(0, 30);
            this.scRel.Name = "scRel";
            // 
            // scRel.Panel1
            // 
            this.scRel.Panel1.Controls.Add(this.dgLoggerList);
            this.scRel.Panel1.Controls.Add(this.pnlLogger);
            // 
            // scRel.Panel2
            // 
            this.scRel.Panel2.Controls.Add(this.dgAppenderList);
            this.scRel.Panel2.Controls.Add(this.pnlAppender);
            this.scRel.Size = new System.Drawing.Size(409, 715);
            this.scRel.SplitterDistance = 135;
            this.scRel.TabIndex = 1;
            // 
            // dgLoggerList
            // 
            this.dgLoggerList.AutoGenerateColumns = false;
            this.dgLoggerList.DataSource = null;
            this.dgLoggerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLoggerList.Editable = true;
            this.dgLoggerList.Location = new System.Drawing.Point(0, 30);
            this.dgLoggerList.Margin = new System.Windows.Forms.Padding(4);
            this.dgLoggerList.Name = "dgLoggerList";
            this.dgLoggerList.Size = new System.Drawing.Size(135, 685);
            this.dgLoggerList.TabIndex = 4;
            // 
            // pnlLogger
            // 
            this.pnlLogger.Controls.Add(this.lblLogger);
            this.pnlLogger.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogger.Location = new System.Drawing.Point(0, 0);
            this.pnlLogger.Name = "pnlLogger";
            this.pnlLogger.Padding = new System.Windows.Forms.Padding(3);
            this.pnlLogger.Size = new System.Drawing.Size(135, 30);
            this.pnlLogger.TabIndex = 3;
            // 
            // lblLogger
            // 
            this.lblLogger.AutoSize = true;
            this.lblLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogger.Location = new System.Drawing.Point(3, 3);
            this.lblLogger.Name = "lblLogger";
            this.lblLogger.Size = new System.Drawing.Size(45, 14);
            this.lblLogger.TabIndex = 0;
            this.lblLogger.Text = "Logger";
            // 
            // dgAppenderList
            // 
            this.dgAppenderList.AutoGenerateColumns = false;
            this.dgAppenderList.DataSource = null;
            this.dgAppenderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAppenderList.Editable = true;
            this.dgAppenderList.Location = new System.Drawing.Point(0, 30);
            this.dgAppenderList.Margin = new System.Windows.Forms.Padding(4);
            this.dgAppenderList.Name = "dgAppenderList";
            this.dgAppenderList.Size = new System.Drawing.Size(270, 685);
            this.dgAppenderList.TabIndex = 4;
            // 
            // pnlAppender
            // 
            this.pnlAppender.Controls.Add(this.lblAppender);
            this.pnlAppender.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAppender.Location = new System.Drawing.Point(0, 0);
            this.pnlAppender.Name = "pnlAppender";
            this.pnlAppender.Padding = new System.Windows.Forms.Padding(3);
            this.pnlAppender.Size = new System.Drawing.Size(270, 30);
            this.pnlAppender.TabIndex = 3;
            // 
            // lblAppender
            // 
            this.lblAppender.AutoSize = true;
            this.lblAppender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppender.Location = new System.Drawing.Point(3, 3);
            this.lblAppender.Name = "lblAppender";
            this.lblAppender.Size = new System.Drawing.Size(61, 14);
            this.lblAppender.TabIndex = 0;
            this.lblAppender.Text = "Appender";
            // 
            // pnlRel
            // 
            this.pnlRel.Controls.Add(this.picRelSave);
            this.pnlRel.Controls.Add(this.lblRel);
            this.pnlRel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRel.Location = new System.Drawing.Point(0, 0);
            this.pnlRel.Name = "pnlRel";
            this.pnlRel.Padding = new System.Windows.Forms.Padding(3);
            this.pnlRel.Size = new System.Drawing.Size(409, 30);
            this.pnlRel.TabIndex = 2;
            // 
            // picRelSave
            // 
            this.picRelSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRelSave.Image = global::Namoo.Client.Properties.Resources.save_file_option;
            this.picRelSave.Location = new System.Drawing.Point(382, 3);
            this.picRelSave.Name = "picRelSave";
            this.picRelSave.Size = new System.Drawing.Size(24, 24);
            this.picRelSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRelSave.TabIndex = 1;
            this.picRelSave.TabStop = false;
            // 
            // lblRel
            // 
            this.lblRel.AutoSize = true;
            this.lblRel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRel.Location = new System.Drawing.Point(3, 3);
            this.lblRel.Name = "lblRel";
            this.lblRel.Size = new System.Drawing.Size(158, 14);
            this.lblRel.TabIndex = 0;
            this.lblRel.Text = "Logger - Appender Relation";
            // 
            // tcLogInfo
            // 
            this.tcLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLogInfo.Location = new System.Drawing.Point(0, 0);
            this.tcLogInfo.Name = "tcLogInfo";
            this.tcLogInfo.SelectedTabPage = this.tpLogger;
            this.tcLogInfo.Size = new System.Drawing.Size(819, 745);
            this.tcLogInfo.TabIndex = 2;
            this.tcLogInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpLogger,
            this.tpAppender});
            // 
            // tpLogger
            // 
            this.tpLogger.Name = "tpLogger";
            this.tpLogger.Size = new System.Drawing.Size(817, 719);
            this.tpLogger.Text = "Logger";
            // 
            // tpAppender
            // 
            this.tpAppender.Name = "tpAppender";
            this.tpAppender.Size = new System.Drawing.Size(817, 719);
            this.tpAppender.Text = "Appender";
            // 
            // LogManager
            // 
            this.ClientSize = new System.Drawing.Size(1232, 745);
            this.Controls.Add(this.scMain);
            this.Name = "LogManager";
            this.Text = "Log4Net Logger/Appender/Relation Manager";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scRel.Panel1.ResumeLayout(false);
            this.scRel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scRel)).EndInit();
            this.scRel.ResumeLayout(false);
            this.pnlLogger.ResumeLayout(false);
            this.pnlLogger.PerformLayout();
            this.pnlAppender.ResumeLayout(false);
            this.pnlAppender.PerformLayout();
            this.pnlRel.ResumeLayout(false);
            this.pnlRel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRelSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcLogInfo)).EndInit();
            this.tcLogInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer scMain;
        private SplitContainer scRel;
        private DevExpress.XtraTab.XtraTabControl tcLogInfo;
        private DevExpress.XtraTab.XtraTabPage tpLogger;
        private DevExpress.XtraTab.XtraTabPage tpAppender;
        private Panel pnlRel;
        private Panel pnlLogger;
        private Panel pnlAppender;
        private Label lblLogger;
        private Label lblAppender;
        private Label lblRel;
        private Namoo.Controls.NaDataGrid dgLoggerList;
        private Namoo.Controls.NaDataGrid dgAppenderList;
        private PictureBox picRelSave;
    }
}
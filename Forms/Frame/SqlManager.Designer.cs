namespace Namoo.Client.Forms.Frame
{
    partial class SqlManager
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gcSqlGroupList = new DevExpress.XtraGrid.GridControl();
            this.gvSqlGroupList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlGroupTitle = new System.Windows.Forms.Panel();
            this.lblGroupTitle = new Namoo.Controls.NaLabel();
            this.gcSqlList = new DevExpress.XtraGrid.GridControl();
            this.gvSqlList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlSqlTitle = new System.Windows.Forms.Panel();
            this.lblSqlTitle = new Namoo.Controls.NaLabel();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.picRemove = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSqlGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSqlGroupList)).BeginInit();
            this.pnlGroupTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSqlList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSqlList)).BeginInit();
            this.pnlSqlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
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
            this.scMain.Panel1.Controls.Add(this.gcSqlGroupList);
            this.scMain.Panel1.Controls.Add(this.pnlGroupTitle);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gcSqlList);
            this.scMain.Panel2.Controls.Add(this.pnlSqlTitle);
            this.scMain.Size = new System.Drawing.Size(800, 450);
            this.scMain.SplitterDistance = 266;
            this.scMain.TabIndex = 0;
            // 
            // gcSqlGroupList
            // 
            this.gcSqlGroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSqlGroupList.Location = new System.Drawing.Point(0, 24);
            this.gcSqlGroupList.MainView = this.gvSqlGroupList;
            this.gcSqlGroupList.Name = "gcSqlGroupList";
            this.gcSqlGroupList.Size = new System.Drawing.Size(266, 426);
            this.gcSqlGroupList.TabIndex = 1;
            this.gcSqlGroupList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSqlGroupList});
            // 
            // gvSqlGroupList
            // 
            this.gvSqlGroupList.GridControl = this.gcSqlGroupList;
            this.gvSqlGroupList.Name = "gvSqlGroupList";
            // 
            // pnlGroupTitle
            // 
            this.pnlGroupTitle.Controls.Add(this.lblGroupTitle);
            this.pnlGroupTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroupTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupTitle.Name = "pnlGroupTitle";
            this.pnlGroupTitle.Size = new System.Drawing.Size(266, 24);
            this.pnlGroupTitle.TabIndex = 0;
            // 
            // lblGroupTitle
            // 
            this.lblGroupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupTitle.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupTitle.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblGroupTitle.Location = new System.Drawing.Point(0, 0);
            this.lblGroupTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblGroupTitle.Name = "lblGroupTitle";
            this.lblGroupTitle.Size = new System.Drawing.Size(266, 24);
            this.lblGroupTitle.TabIndex = 0;
            this.lblGroupTitle.Text = "Sql Group ID";
            // 
            // gcSqlList
            // 
            this.gcSqlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSqlList.Location = new System.Drawing.Point(0, 24);
            this.gcSqlList.MainView = this.gvSqlList;
            this.gcSqlList.Name = "gcSqlList";
            this.gcSqlList.Size = new System.Drawing.Size(530, 426);
            this.gcSqlList.TabIndex = 1;
            this.gcSqlList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSqlList});
            // 
            // gvSqlList
            // 
            this.gvSqlList.GridControl = this.gcSqlList;
            this.gvSqlList.Name = "gvSqlList";
            // 
            // pnlSqlTitle
            // 
            this.pnlSqlTitle.Controls.Add(this.lblSqlTitle);
            this.pnlSqlTitle.Controls.Add(this.picNew);
            this.pnlSqlTitle.Controls.Add(this.pnlSpacer);
            this.pnlSqlTitle.Controls.Add(this.picRemove);
            this.pnlSqlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSqlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlSqlTitle.Name = "pnlSqlTitle";
            this.pnlSqlTitle.Size = new System.Drawing.Size(530, 24);
            this.pnlSqlTitle.TabIndex = 0;
            // 
            // lblSqlTitle
            // 
            this.lblSqlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlTitle.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblSqlTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSqlTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSqlTitle.Name = "lblSqlTitle";
            this.lblSqlTitle.Size = new System.Drawing.Size(478, 24);
            this.lblSqlTitle.TabIndex = 0;
            this.lblSqlTitle.Text = "Sql List";
            // 
            // picNew
            // 
            this.picNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.picNew.Image = global::Namoo.Client.Properties.Resources.add_square_button;
            this.picNew.Location = new System.Drawing.Point(478, 0);
            this.picNew.Name = "picNew";
            this.picNew.Padding = new System.Windows.Forms.Padding(2);
            this.picNew.Size = new System.Drawing.Size(24, 24);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 3;
            this.picNew.TabStop = false;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSpacer.Location = new System.Drawing.Point(502, 0);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(4, 24);
            this.pnlSpacer.TabIndex = 2;
            // 
            // picRemove
            // 
            this.picRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRemove.Image = global::Namoo.Client.Properties.Resources.minus_button;
            this.picRemove.Location = new System.Drawing.Point(506, 0);
            this.picRemove.Name = "picRemove";
            this.picRemove.Padding = new System.Windows.Forms.Padding(2);
            this.picRemove.Size = new System.Drawing.Size(24, 24);
            this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRemove.TabIndex = 1;
            this.picRemove.TabStop = false;
            // 
            // SqlManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scMain);
            this.Name = "SqlManager";
            this.Text = "SqlManager";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSqlGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSqlGroupList)).EndInit();
            this.pnlGroupTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSqlList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSqlList)).EndInit();
            this.pnlSqlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel pnlGroupTitle;
        private Controls.NaLabel lblGroupTitle;
        private System.Windows.Forms.Panel pnlSqlTitle;
        private Controls.NaLabel lblSqlTitle;
        private DevExpress.XtraGrid.GridControl gcSqlGroupList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSqlGroupList;
        private DevExpress.XtraGrid.GridControl gcSqlList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSqlList;
        private System.Windows.Forms.PictureBox picRemove;
        private System.Windows.Forms.Panel pnlSpacer;
        private System.Windows.Forms.PictureBox picNew;
    }
}
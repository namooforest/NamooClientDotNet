namespace Namoo.Client.Forms.Popup
{
    partial class SqlEditorView
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSqlTitle = new System.Windows.Forms.Panel();
            this.lblSqlTitle = new Namoo.Controls.NaLabel();
            this.pnlSqlParam = new System.Windows.Forms.Panel();
            this.lblSqlParam = new Namoo.Controls.NaLabel();
            this.txtQuery = new Namoo.Controls.NaScintilla();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.conn = new Namoo.Client.UserControls.DbConnector();
            this.picExecute = new System.Windows.Forms.PictureBox();
            this.btnSave = new Namoo.Controls.NaButton();
            this.btnCancel = new Namoo.Controls.NaButton();
            this.gcParameter = new DevExpress.XtraGrid.GridControl();
            this.gvParameter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tlpProperties = new System.Windows.Forms.TableLayoutPanel();
            this.lblSqlType = new Namoo.Controls.NaLabel();
            this.lblSqlGroupId = new Namoo.Controls.NaLabel();
            this.lblSqlId = new Namoo.Controls.NaLabel();
            this.gleSqlGroupId = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gleSqlGroupIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSqlId = new Namoo.Controls.NaTextBox();
            this.cmbSqlType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSampleView = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.pnlSqlTitle.SuspendLayout();
            this.pnlSqlParam.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExecute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameter)).BeginInit();
            this.tlpProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gleSqlGroupId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleSqlGroupIdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSqlType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.Controls.Add(this.pnlSqlTitle, 0, 0);
            this.tlpMain.Controls.Add(this.pnlSqlParam, 1, 0);
            this.tlpMain.Controls.Add(this.txtQuery, 0, 1);
            this.tlpMain.Controls.Add(this.tlpBottom, 0, 2);
            this.tlpMain.Controls.Add(this.gcParameter, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 55);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Size = new System.Drawing.Size(800, 395);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlSqlTitle
            // 
            this.pnlSqlTitle.Controls.Add(this.btnSampleView);
            this.pnlSqlTitle.Controls.Add(this.lblSqlTitle);
            this.pnlSqlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSqlTitle.Location = new System.Drawing.Point(3, 3);
            this.pnlSqlTitle.Name = "pnlSqlTitle";
            this.pnlSqlTitle.Size = new System.Drawing.Size(494, 24);
            this.pnlSqlTitle.TabIndex = 0;
            // 
            // lblSqlTitle
            // 
            this.lblSqlTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSqlTitle.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblSqlTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSqlTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSqlTitle.Name = "lblSqlTitle";
            this.lblSqlTitle.Size = new System.Drawing.Size(51, 24);
            this.lblSqlTitle.TabIndex = 0;
            this.lblSqlTitle.Text = "Sql";
            // 
            // pnlSqlParam
            // 
            this.pnlSqlParam.Controls.Add(this.lblSqlParam);
            this.pnlSqlParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSqlParam.Location = new System.Drawing.Point(503, 3);
            this.pnlSqlParam.Name = "pnlSqlParam";
            this.pnlSqlParam.Size = new System.Drawing.Size(294, 24);
            this.pnlSqlParam.TabIndex = 0;
            // 
            // lblSqlParam
            // 
            this.lblSqlParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlParam.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblSqlParam.Location = new System.Drawing.Point(0, 0);
            this.lblSqlParam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSqlParam.Name = "lblSqlParam";
            this.lblSqlParam.Size = new System.Drawing.Size(294, 24);
            this.lblSqlParam.TabIndex = 0;
            this.lblSqlParam.Text = "Parameter";
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.EditorText = "";
            this.txtQuery.LineNumberVisible = false;
            this.txtQuery.Location = new System.Drawing.Point(2, 31);
            this.txtQuery.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = false;
            this.txtQuery.Size = new System.Drawing.Size(496, 323);
            this.txtQuery.Syntax = Namoo.Controls.NaScintilla.SyntaxStyle.SQL;
            this.txtQuery.TabIndex = 1;
            this.txtQuery.Text = "";
            // 
            // tlpBottom
            // 
            this.tlpBottom.ColumnCount = 6;
            this.tlpMain.SetColumnSpan(this.tlpBottom, 2);
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpBottom.Controls.Add(this.conn, 0, 0);
            this.tlpBottom.Controls.Add(this.picExecute, 1, 0);
            this.tlpBottom.Controls.Add(this.btnSave, 3, 0);
            this.tlpBottom.Controls.Add(this.btnCancel, 5, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(3, 358);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.Padding = new System.Windows.Forms.Padding(2);
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(794, 34);
            this.tlpBottom.TabIndex = 3;
            // 
            // conn
            // 
            this.conn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conn.Location = new System.Drawing.Point(5, 5);
            this.conn.Name = "conn";
            this.conn.Properties.AutoHeight = false;
            this.conn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.conn.Size = new System.Drawing.Size(154, 24);
            this.conn.TabIndex = 0;
            // 
            // picExecute
            // 
            this.picExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picExecute.Image = global::Namoo.Client.Properties.Resources.play_sign;
            this.picExecute.Location = new System.Drawing.Point(165, 5);
            this.picExecute.Name = "picExecute";
            this.picExecute.Size = new System.Drawing.Size(24, 24);
            this.picExecute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExecute.TabIndex = 1;
            this.picExecute.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSave.Font = new System.Drawing.Font("Gulim", 9F);
            this.btnSave.Location = new System.Drawing.Point(627, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.StyleSet = null;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "저장";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCancel.Font = new System.Drawing.Font("Gulim", 9F);
            this.btnCancel.Location = new System.Drawing.Point(712, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.StyleSet = null;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            // 
            // gcParameter
            // 
            this.gcParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcParameter.Location = new System.Drawing.Point(503, 33);
            this.gcParameter.MainView = this.gvParameter;
            this.gcParameter.Name = "gcParameter";
            this.gcParameter.Size = new System.Drawing.Size(294, 319);
            this.gcParameter.TabIndex = 4;
            this.gcParameter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvParameter});
            // 
            // gvParameter
            // 
            this.gvParameter.GridControl = this.gcParameter;
            this.gvParameter.Name = "gvParameter";
            // 
            // tlpProperties
            // 
            this.tlpProperties.ColumnCount = 4;
            this.tlpProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpProperties.Controls.Add(this.lblSqlType, 2, 0);
            this.tlpProperties.Controls.Add(this.lblSqlGroupId, 0, 0);
            this.tlpProperties.Controls.Add(this.lblSqlId, 0, 1);
            this.tlpProperties.Controls.Add(this.gleSqlGroupId, 1, 0);
            this.tlpProperties.Controls.Add(this.txtSqlId, 1, 1);
            this.tlpProperties.Controls.Add(this.cmbSqlType, 3, 0);
            this.tlpProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpProperties.Location = new System.Drawing.Point(0, 0);
            this.tlpProperties.Name = "tlpProperties";
            this.tlpProperties.RowCount = 2;
            this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProperties.Size = new System.Drawing.Size(800, 55);
            this.tlpProperties.TabIndex = 1;
            // 
            // lblSqlType
            // 
            this.lblSqlType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlType.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblSqlType.Location = new System.Drawing.Point(563, 2);
            this.lblSqlType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSqlType.Name = "lblSqlType";
            this.lblSqlType.Size = new System.Drawing.Size(94, 23);
            this.lblSqlType.TabIndex = 3;
            this.lblSqlType.Text = "Sql Type";
            // 
            // lblSqlGroupId
            // 
            this.lblSqlGroupId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlGroupId.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblSqlGroupId.Location = new System.Drawing.Point(3, 2);
            this.lblSqlGroupId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSqlGroupId.Name = "lblSqlGroupId";
            this.lblSqlGroupId.Size = new System.Drawing.Size(94, 23);
            this.lblSqlGroupId.TabIndex = 0;
            this.lblSqlGroupId.Text = "Sql Group ID";
            // 
            // lblSqlId
            // 
            this.lblSqlId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlId.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblSqlId.Location = new System.Drawing.Point(3, 29);
            this.lblSqlId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSqlId.Name = "lblSqlId";
            this.lblSqlId.Size = new System.Drawing.Size(94, 24);
            this.lblSqlId.TabIndex = 0;
            this.lblSqlId.Text = "Sql ID";
            // 
            // gleSqlGroupId
            // 
            this.gleSqlGroupId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gleSqlGroupId.EditValue = " ";
            this.gleSqlGroupId.Location = new System.Drawing.Point(103, 3);
            this.gleSqlGroupId.Name = "gleSqlGroupId";
            this.gleSqlGroupId.Properties.AutoHeight = false;
            this.gleSqlGroupId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gleSqlGroupId.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.gleSqlGroupId.Properties.PopupView = this.gleSqlGroupIdView;
            this.gleSqlGroupId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.gleSqlGroupId.Size = new System.Drawing.Size(454, 21);
            this.gleSqlGroupId.TabIndex = 1;
            // 
            // gleSqlGroupIdView
            // 
            this.gleSqlGroupIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gleSqlGroupIdView.Name = "gleSqlGroupIdView";
            this.gleSqlGroupIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gleSqlGroupIdView.OptionsView.ShowGroupPanel = false;
            // 
            // txtSqlId
            // 
            this.txtSqlId.BackColor = System.Drawing.Color.White;
            this.txtSqlId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpProperties.SetColumnSpan(this.txtSqlId, 3);
            this.txtSqlId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSqlId.Location = new System.Drawing.Point(103, 29);
            this.txtSqlId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSqlId.Name = "txtSqlId";
            this.txtSqlId.Size = new System.Drawing.Size(694, 24);
            this.txtSqlId.TabIndex = 2;
            // 
            // cmbSqlType
            // 
            this.cmbSqlType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSqlType.Location = new System.Drawing.Point(663, 3);
            this.cmbSqlType.Name = "cmbSqlType";
            this.cmbSqlType.Properties.AutoHeight = false;
            this.cmbSqlType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSqlType.Size = new System.Drawing.Size(134, 21);
            this.cmbSqlType.TabIndex = 4;
            // 
            // btnSampleView
            // 
            this.btnSampleView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSampleView.Location = new System.Drawing.Point(394, 0);
            this.btnSampleView.Name = "btnSampleView";
            this.btnSampleView.Size = new System.Drawing.Size(100, 24);
            this.btnSampleView.TabIndex = 1;
            this.btnSampleView.Text = "Syntax Sample";
            this.btnSampleView.UseVisualStyleBackColor = true;
            // 
            // SqlEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.tlpProperties);
            this.Name = "SqlEditorView";
            this.Text = "SqlNew";
            this.tlpMain.ResumeLayout(false);
            this.pnlSqlTitle.ResumeLayout(false);
            this.pnlSqlParam.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.conn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExecute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameter)).EndInit();
            this.tlpProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gleSqlGroupId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gleSqlGroupIdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSqlType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlSqlTitle;
        private Controls.NaLabel lblSqlTitle;
        private System.Windows.Forms.Panel pnlSqlParam;
        private Controls.NaLabel lblSqlParam;
        private Controls.NaScintilla txtQuery;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private UserControls.DbConnector conn;
        private System.Windows.Forms.PictureBox picExecute;
        private System.Windows.Forms.TableLayoutPanel tlpProperties;
        private Controls.NaLabel lblSqlGroupId;
        private Controls.NaLabel lblSqlId;
        private DevExpress.XtraEditors.GridLookUpEdit gleSqlGroupId;
        private DevExpress.XtraGrid.Views.Grid.GridView gleSqlGroupIdView;
        private Controls.NaTextBox txtSqlId;
        private DevExpress.XtraGrid.GridControl gcParameter;
        private DevExpress.XtraGrid.Views.Grid.GridView gvParameter;
        private Controls.NaButton btnSave;
        private Controls.NaButton btnCancel;
        private Controls.NaLabel lblSqlType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSqlType;
        private System.Windows.Forms.Button btnSampleView;
    }
}
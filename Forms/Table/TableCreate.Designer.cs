namespace Namoo.Client.Forms.Table
{
    partial class TableCreate
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
            this.gcColumn = new DevExpress.XtraGrid.GridControl();
            this.gvColumn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlColumnList = new System.Windows.Forms.Panel();
            this.lblColumnList = new Namoo.Controls.NaLabel();
            this.gcTable = new DevExpress.XtraGrid.GridControl();
            this.gvTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tlpTableInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTableName = new Namoo.Controls.NaLabel();
            this.lblTableDesc = new Namoo.Controls.NaLabel();
            this.txtTableName = new Namoo.Controls.NaTextBox();
            this.txtTableDesc = new Namoo.Controls.NaTextBox();
            this.pnlTableDefine = new System.Windows.Forms.Panel();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.picRemove = new System.Windows.Forms.PictureBox();
            this.naLabel2 = new Namoo.Controls.NaLabel();
            this.pnlControlBox = new System.Windows.Forms.Panel();
            this.picExecute = new System.Windows.Forms.PictureBox();
            this.cmbConnector = new Namoo.Client.UserControls.DbConnector();
            this.lblDbConn = new Namoo.Controls.NaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColumn)).BeginInit();
            this.pnlColumnList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTable)).BeginInit();
            this.tlpTableInfo.SuspendLayout();
            this.pnlTableDefine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).BeginInit();
            this.pnlControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExecute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbConnector.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 44);
            this.scMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gcColumn);
            this.scMain.Panel1.Controls.Add(this.pnlColumnList);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.gcTable);
            this.scMain.Panel2.Controls.Add(this.tlpTableInfo);
            this.scMain.Panel2.Controls.Add(this.pnlTableDefine);
            this.scMain.Size = new System.Drawing.Size(1143, 781);
            this.scMain.SplitterDistance = 380;
            this.scMain.SplitterWidth = 6;
            this.scMain.TabIndex = 0;
            // 
            // gcColumn
            // 
            this.gcColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcColumn.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gcColumn.Location = new System.Drawing.Point(0, 48);
            this.gcColumn.MainView = this.gvColumn;
            this.gcColumn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gcColumn.Name = "gcColumn";
            this.gcColumn.Size = new System.Drawing.Size(380, 733);
            this.gcColumn.TabIndex = 1;
            this.gcColumn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvColumn});
            // 
            // gvColumn
            // 
            this.gvColumn.DetailHeight = 642;
            this.gvColumn.GridControl = this.gcColumn;
            this.gvColumn.Name = "gvColumn";
            // 
            // pnlColumnList
            // 
            this.pnlColumnList.Controls.Add(this.lblColumnList);
            this.pnlColumnList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColumnList.Location = new System.Drawing.Point(0, 0);
            this.pnlColumnList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlColumnList.Name = "pnlColumnList";
            this.pnlColumnList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlColumnList.Size = new System.Drawing.Size(380, 48);
            this.pnlColumnList.TabIndex = 0;
            // 
            // lblColumnList
            // 
            this.lblColumnList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblColumnList.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblColumnList.Location = new System.Drawing.Point(3, 4);
            this.lblColumnList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblColumnList.Name = "lblColumnList";
            this.lblColumnList.Size = new System.Drawing.Size(214, 40);
            this.lblColumnList.TabIndex = 0;
            this.lblColumnList.Text = "컬럼목록";
            // 
            // gcTable
            // 
            this.gcTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTable.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gcTable.Location = new System.Drawing.Point(0, 140);
            this.gcTable.MainView = this.gvTable;
            this.gcTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gcTable.Name = "gcTable";
            this.gcTable.Size = new System.Drawing.Size(757, 641);
            this.gcTable.TabIndex = 1;
            this.gcTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTable});
            // 
            // gvTable
            // 
            this.gvTable.DetailHeight = 642;
            this.gvTable.GridControl = this.gcTable;
            this.gvTable.Name = "gvTable";
            // 
            // tlpTableInfo
            // 
            this.tlpTableInfo.ColumnCount = 2;
            this.tlpTableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tlpTableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTableInfo.Controls.Add(this.lblTableName, 0, 0);
            this.tlpTableInfo.Controls.Add(this.lblTableDesc, 0, 1);
            this.tlpTableInfo.Controls.Add(this.txtTableName, 1, 0);
            this.tlpTableInfo.Controls.Add(this.txtTableDesc, 1, 1);
            this.tlpTableInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTableInfo.Location = new System.Drawing.Point(0, 48);
            this.tlpTableInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpTableInfo.Name = "tlpTableInfo";
            this.tlpTableInfo.RowCount = 2;
            this.tlpTableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTableInfo.Size = new System.Drawing.Size(757, 92);
            this.tlpTableInfo.TabIndex = 2;
            // 
            // lblTableName
            // 
            this.lblTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTableName.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTableName.Location = new System.Drawing.Point(4, 4);
            this.lblTableName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(135, 38);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "테이블 이름";
            // 
            // lblTableDesc
            // 
            this.lblTableDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTableDesc.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTableDesc.Location = new System.Drawing.Point(4, 50);
            this.lblTableDesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTableDesc.Name = "lblTableDesc";
            this.lblTableDesc.Size = new System.Drawing.Size(135, 38);
            this.lblTableDesc.TabIndex = 0;
            this.lblTableDesc.Text = "테이블 설명";
            // 
            // txtTableName
            // 
            this.txtTableName.BackColor = System.Drawing.Color.White;
            this.txtTableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTableName.Location = new System.Drawing.Point(147, 4);
            this.txtTableName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(606, 38);
            this.txtTableName.TabIndex = 1;
            // 
            // txtTableDesc
            // 
            this.txtTableDesc.BackColor = System.Drawing.Color.White;
            this.txtTableDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTableDesc.Location = new System.Drawing.Point(147, 50);
            this.txtTableDesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTableDesc.Name = "txtTableDesc";
            this.txtTableDesc.Size = new System.Drawing.Size(606, 38);
            this.txtTableDesc.TabIndex = 1;
            // 
            // pnlTableDefine
            // 
            this.pnlTableDefine.Controls.Add(this.picAdd);
            this.pnlTableDefine.Controls.Add(this.pnlSpacer);
            this.pnlTableDefine.Controls.Add(this.picRemove);
            this.pnlTableDefine.Controls.Add(this.naLabel2);
            this.pnlTableDefine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTableDefine.Location = new System.Drawing.Point(0, 0);
            this.pnlTableDefine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTableDefine.Name = "pnlTableDefine";
            this.pnlTableDefine.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTableDefine.Size = new System.Drawing.Size(757, 48);
            this.pnlTableDefine.TabIndex = 0;
            // 
            // picAdd
            // 
            this.picAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.picAdd.Image = global::Namoo.Client.Properties.Resources.add_square_button;
            this.picAdd.Location = new System.Drawing.Point(685, 4);
            this.picAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(31, 40);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdd.TabIndex = 4;
            this.picAdd.TabStop = false;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSpacer.Location = new System.Drawing.Point(716, 4);
            this.pnlSpacer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(7, 40);
            this.pnlSpacer.TabIndex = 5;
            // 
            // picRemove
            // 
            this.picRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRemove.Image = global::Namoo.Client.Properties.Resources.minus_button;
            this.picRemove.Location = new System.Drawing.Point(723, 4);
            this.picRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picRemove.Name = "picRemove";
            this.picRemove.Size = new System.Drawing.Size(31, 40);
            this.picRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRemove.TabIndex = 3;
            this.picRemove.TabStop = false;
            // 
            // naLabel2
            // 
            this.naLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.naLabel2.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.naLabel2.Location = new System.Drawing.Point(3, 4);
            this.naLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.naLabel2.Name = "naLabel2";
            this.naLabel2.Size = new System.Drawing.Size(214, 40);
            this.naLabel2.TabIndex = 0;
            this.naLabel2.Text = "테이블 정의";
            // 
            // pnlControlBox
            // 
            this.pnlControlBox.Controls.Add(this.picExecute);
            this.pnlControlBox.Controls.Add(this.cmbConnector);
            this.pnlControlBox.Controls.Add(this.lblDbConn);
            this.pnlControlBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlBox.Location = new System.Drawing.Point(0, 0);
            this.pnlControlBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControlBox.Name = "pnlControlBox";
            this.pnlControlBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlControlBox.Size = new System.Drawing.Size(1143, 44);
            this.pnlControlBox.TabIndex = 1;
            // 
            // picExecute
            // 
            this.picExecute.Dock = System.Windows.Forms.DockStyle.Right;
            this.picExecute.Image = global::Namoo.Client.Properties.Resources.play_sign;
            this.picExecute.Location = new System.Drawing.Point(1111, 4);
            this.picExecute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picExecute.Name = "picExecute";
            this.picExecute.Size = new System.Drawing.Size(29, 36);
            this.picExecute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExecute.TabIndex = 2;
            this.picExecute.TabStop = false;
            // 
            // cmbConnector
            // 
            this.cmbConnector.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbConnector.Location = new System.Drawing.Point(89, 4);
            this.cmbConnector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbConnector.Name = "cmbConnector";
            this.cmbConnector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbConnector.Size = new System.Drawing.Size(143, 28);
            this.cmbConnector.TabIndex = 1;
            // 
            // lblDbConn
            // 
            this.lblDbConn.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDbConn.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDbConn.Location = new System.Drawing.Point(3, 4);
            this.lblDbConn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblDbConn.Name = "lblDbConn";
            this.lblDbConn.Size = new System.Drawing.Size(86, 36);
            this.lblDbConn.TabIndex = 0;
            this.lblDbConn.Text = "연결DB :";
            // 
            // TableCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 825);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlControlBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TableCreate";
            this.Text = "TableCreate";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvColumn)).EndInit();
            this.pnlColumnList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTable)).EndInit();
            this.tlpTableInfo.ResumeLayout(false);
            this.pnlTableDefine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemove)).EndInit();
            this.pnlControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExecute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbConnector.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel pnlColumnList;
        private System.Windows.Forms.Panel pnlTableDefine;
        private System.Windows.Forms.Panel pnlControlBox;
        private Namoo.Controls.NaLabel lblDbConn;
        private Namoo.Client.UserControls.DbConnector cmbConnector;
        private DevExpress.XtraGrid.GridControl gcColumn;
        private DevExpress.XtraGrid.Views.Grid.GridView gvColumn;
        private DevExpress.XtraGrid.GridControl gcTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTable;
        private Namoo.Controls.NaLabel lblColumnList;
        private Namoo.Controls.NaLabel naLabel2;
        private System.Windows.Forms.PictureBox picExecute;
        private System.Windows.Forms.PictureBox picAdd;
        private System.Windows.Forms.PictureBox picRemove;
        private System.Windows.Forms.Panel pnlSpacer;
        private System.Windows.Forms.TableLayoutPanel tlpTableInfo;
        private Namoo.Controls.NaLabel lblTableName;
        private Namoo.Controls.NaLabel lblTableDesc;
        private Namoo.Controls.NaTextBox txtTableName;
        private Namoo.Controls.NaTextBox txtTableDesc;
    }
}
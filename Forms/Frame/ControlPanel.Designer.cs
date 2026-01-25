namespace Namoo.Client.Forms.Frame
{
    partial class ControlPanel
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
            this.btnSetupDatabase = new Namoo.Controls.NaButton();
            this.btnProgressTest = new Namoo.Controls.NaButton();
            this.dbConnector = new Namoo.Client.UserControls.DbConnector();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle1 = new Namoo.Controls.NaLabel();
            this.lblConnector = new Namoo.Controls.NaLabel();
            this.lblSqlGroupId = new Namoo.Controls.NaLabel();
            this.lblSqlId = new Namoo.Controls.NaLabel();
            this.txtSqlGroupId = new Namoo.Controls.NaTextBox();
            this.txtSqlId = new Namoo.Controls.NaTextBox();
            this.btnExecute = new Namoo.Controls.NaButton();
            ((System.ComponentModel.ISupportInitialize)(this.dbConnector.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetupDatabase
            // 
            this.btnSetupDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSetupDatabase.Location = new System.Drawing.Point(40, 31);
            this.btnSetupDatabase.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetupDatabase.Name = "btnSetupDatabase";
            this.btnSetupDatabase.Size = new System.Drawing.Size(80, 30);
            this.btnSetupDatabase.StyleSet = null;
            this.btnSetupDatabase.TabIndex = 0;
            this.btnSetupDatabase.Text = "Setup DB";
            // 
            // btnProgressTest
            // 
            this.btnProgressTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnProgressTest.Location = new System.Drawing.Point(613, 31);
            this.btnProgressTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnProgressTest.Name = "btnProgressTest";
            this.btnProgressTest.Size = new System.Drawing.Size(100, 30);
            this.btnProgressTest.StyleSet = null;
            this.btnProgressTest.TabIndex = 1;
            this.btnProgressTest.Text = "Progress Test";
            // 
            // dbConnector
            // 
            this.dbConnector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbConnector.Location = new System.Drawing.Point(88, 23);
            this.dbConnector.Name = "dbConnector";
            this.dbConnector.Properties.AutoHeight = false;
            this.dbConnector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dbConnector.Size = new System.Drawing.Size(161, 20);
            this.dbConnector.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dbConnector, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblConnector, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSqlGroupId, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSqlId, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSqlGroupId, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSqlId, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnExecute, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(536, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 128);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblTitle1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle1, 2);
            this.lblTitle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle1.LabelFont = new System.Drawing.Font("Tahoma", 9F);
            this.lblTitle1.Location = new System.Drawing.Point(3, 2);
            this.lblTitle1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(246, 16);
            this.lblTitle1.TabIndex = 3;
            this.lblTitle1.Text = "Sql Tester";
            // 
            // lblConnector
            // 
            this.lblConnector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConnector.LabelFont = new System.Drawing.Font("Tahoma", 9F);
            this.lblConnector.Location = new System.Drawing.Point(3, 22);
            this.lblConnector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblConnector.Name = "lblConnector";
            this.lblConnector.Size = new System.Drawing.Size(79, 22);
            this.lblConnector.TabIndex = 4;
            this.lblConnector.Text = "Connector";
            // 
            // lblSqlGroupId
            // 
            this.lblSqlGroupId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlGroupId.LabelFont = new System.Drawing.Font("Tahoma", 9F);
            this.lblSqlGroupId.Location = new System.Drawing.Point(3, 48);
            this.lblSqlGroupId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSqlGroupId.Name = "lblSqlGroupId";
            this.lblSqlGroupId.Size = new System.Drawing.Size(79, 22);
            this.lblSqlGroupId.TabIndex = 4;
            this.lblSqlGroupId.Text = "Sql Group ID";
            // 
            // lblSqlId
            // 
            this.lblSqlId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlId.LabelFont = new System.Drawing.Font("Tahoma", 9F);
            this.lblSqlId.Location = new System.Drawing.Point(3, 74);
            this.lblSqlId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSqlId.Name = "lblSqlId";
            this.lblSqlId.Size = new System.Drawing.Size(79, 22);
            this.lblSqlId.TabIndex = 4;
            this.lblSqlId.Text = "Sql ID";
            // 
            // txtSqlGroupId
            // 
            this.txtSqlGroupId.BackColor = System.Drawing.Color.White;
            this.txtSqlGroupId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSqlGroupId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSqlGroupId.Location = new System.Drawing.Point(88, 48);
            this.txtSqlGroupId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSqlGroupId.Name = "txtSqlGroupId";
            this.txtSqlGroupId.Size = new System.Drawing.Size(161, 22);
            this.txtSqlGroupId.TabIndex = 5;
            // 
            // txtSqlId
            // 
            this.txtSqlId.BackColor = System.Drawing.Color.White;
            this.txtSqlId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSqlId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSqlId.Location = new System.Drawing.Point(88, 74);
            this.txtSqlId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSqlId.Name = "txtSqlId";
            this.txtSqlId.Size = new System.Drawing.Size(161, 22);
            this.txtSqlId.TabIndex = 5;
            // 
            // btnExecute
            // 
            this.btnExecute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnExecute.Location = new System.Drawing.Point(85, 98);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(0);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(167, 30);
            this.btnExecute.StyleSet = null;
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "실행";
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnProgressTest);
            this.Controls.Add(this.btnSetupDatabase);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            ((System.ComponentModel.ISupportInitialize)(this.dbConnector.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NaButton btnSetupDatabase;
        private Controls.NaButton btnProgressTest;
        private UserControls.DbConnector dbConnector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.NaLabel lblTitle1;
        private Controls.NaLabel lblConnector;
        private Controls.NaLabel lblSqlGroupId;
        private Controls.NaLabel lblSqlId;
        private Controls.NaTextBox txtSqlGroupId;
        private Controls.NaTextBox txtSqlId;
        private Controls.NaButton btnExecute;
    }
}
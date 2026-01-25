
using System.Windows.Forms;

namespace Namoo.Client.Forms.Config
{
    partial class ConnectionManager
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
            this.sccMain = new System.Windows.Forms.SplitContainer();
            this.dgConnList = new Namoo.Controls.NaDataGrid();
            this.pnlListTitle = new System.Windows.Forms.Panel();
            this.lblListTitle = new Namoo.Controls.NaLabel();
            this.pnlConnStr = new System.Windows.Forms.Panel();
            this.dgOption = new Namoo.Controls.NaDataGrid();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.nLabel8 = new Namoo.Controls.NaLabel();
            this.picAddOption = new System.Windows.Forms.PictureBox();
            this.picRemoveOption = new System.Windows.Forms.PictureBox();
            this.pnlFilePath = new System.Windows.Forms.Panel();
            this.picPath = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtFilePath = new Namoo.Controls.NaTextBox();
            this.lblFilePath = new Namoo.Controls.NaLabel();
            this.pnlIdPw = new System.Windows.Forms.Panel();
            this.picShowPass = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtPassword = new Namoo.Controls.NaTextBox();
            this.lblPassword = new Namoo.Controls.NaLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtId = new Namoo.Controls.NaTextBox();
            this.lblId = new Namoo.Controls.NaLabel();
            this.pnlServiceName = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtServiceName = new Namoo.Controls.NaTextBox();
            this.lblServiceName = new Namoo.Controls.NaLabel();
            this.pnlDatabase = new System.Windows.Forms.Panel();
            this.txtDatabase = new Namoo.Controls.NaTextBox();
            this.lblDatabase = new Namoo.Controls.NaLabel();
            this.pnlIP = new System.Windows.Forms.Panel();
            this.txtPort = new Namoo.Controls.NaTextBox();
            this.lblPort = new Namoo.Controls.NaLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIp = new Namoo.Controls.NaTextBox();
            this.lblIp = new Namoo.Controls.NaLabel();
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.txtDescription = new Namoo.Controls.NaTextBox();
            this.lblDescription = new Namoo.Controls.NaLabel();
            this.pnlName = new System.Windows.Forms.Panel();
            this.chkUse = new System.Windows.Forms.CheckBox();
            this.cmbDBType = new Namoo.Controls.NaComboBox();
            this.lblDBType = new Namoo.Controls.NaLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtName = new Namoo.Controls.NaTextBox();
            this.lblName = new Namoo.Controls.NaLabel();
            this.pnlContentButtons = new System.Windows.Forms.Panel();
            this.btnTest = new Namoo.Controls.NaButton();
            this.pnlBtnSpacer2 = new System.Windows.Forms.Panel();
            this.btnSave = new Namoo.Controls.NaButton();
            this.pnlBtnSpacer1 = new System.Windows.Forms.Panel();
            this.btnDelete = new Namoo.Controls.NaButton();
            this.btnNew = new Namoo.Controls.NaButton();
            this.pnlBtnSpacer３ = new System.Windows.Forms.Panel();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.Panel1.SuspendLayout();
            this.sccMain.Panel2.SuspendLayout();
            this.sccMain.SuspendLayout();
            this.pnlListTitle.SuspendLayout();
            this.pnlConnStr.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemoveOption)).BeginInit();
            this.pnlFilePath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPath)).BeginInit();
            this.pnlIdPw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPass)).BeginInit();
            this.pnlServiceName.SuspendLayout();
            this.pnlDatabase.SuspendLayout();
            this.pnlIP.SuspendLayout();
            this.pnlDesc.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlContentButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // sccMain
            // 
            this.sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccMain.Location = new System.Drawing.Point(0, 0);
            this.sccMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sccMain.Name = "sccMain";
            // 
            // sccMain.Panel1
            // 
            this.sccMain.Panel1.Controls.Add(this.dgConnList);
            this.sccMain.Panel1.Controls.Add(this.pnlListTitle);
            // 
            // sccMain.Panel2
            // 
            this.sccMain.Panel2.Controls.Add(this.pnlConnStr);
            this.sccMain.Panel2.Controls.Add(this.pnlFilePath);
            this.sccMain.Panel2.Controls.Add(this.pnlIdPw);
            this.sccMain.Panel2.Controls.Add(this.pnlServiceName);
            this.sccMain.Panel2.Controls.Add(this.pnlDatabase);
            this.sccMain.Panel2.Controls.Add(this.pnlIP);
            this.sccMain.Panel2.Controls.Add(this.pnlDesc);
            this.sccMain.Panel2.Controls.Add(this.pnlName);
            this.sccMain.Panel2.Controls.Add(this.pnlContentButtons);
            this.sccMain.Size = new System.Drawing.Size(784, 514);
            this.sccMain.SplitterDistance = 183;
            this.sccMain.TabIndex = 0;
            this.sccMain.TabStop = false;
            // 
            // dgConnList
            // 
            this.dgConnList.AutoGenerateColumns = false;
            this.dgConnList.DataSource = null;
            this.dgConnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgConnList.Editable = true;
            this.dgConnList.Location = new System.Drawing.Point(0, 35);
            this.dgConnList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgConnList.Name = "dgConnList";
            this.dgConnList.Size = new System.Drawing.Size(183, 479);
            this.dgConnList.TabIndex = 1;
            this.dgConnList.TabStop = false;
            // 
            // pnlListTitle
            // 
            this.pnlListTitle.Controls.Add(this.lblListTitle);
            this.pnlListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlListTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlListTitle.Name = "pnlListTitle";
            this.pnlListTitle.Size = new System.Drawing.Size(183, 35);
            this.pnlListTitle.TabIndex = 0;
            // 
            // lblListTitle
            // 
            this.lblListTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblListTitle.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblListTitle.Location = new System.Drawing.Point(0, 0);
            this.lblListTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(183, 35);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.TabStop = false;
            this.lblListTitle.Text = "연결목록";
            // 
            // pnlConnStr
            // 
            this.pnlConnStr.Controls.Add(this.dgOption);
            this.pnlConnStr.Controls.Add(this.pnlOptions);
            this.pnlConnStr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConnStr.Location = new System.Drawing.Point(0, 280);
            this.pnlConnStr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlConnStr.Name = "pnlConnStr";
            this.pnlConnStr.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlConnStr.Size = new System.Drawing.Size(597, 234);
            this.pnlConnStr.TabIndex = 8;
            // 
            // dgOption
            // 
            this.dgOption.AutoGenerateColumns = false;
            this.dgOption.DataSource = null;
            this.dgOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOption.Editable = true;
            this.dgOption.Location = new System.Drawing.Point(3, 39);
            this.dgOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgOption.Name = "dgOption";
            this.dgOption.Size = new System.Drawing.Size(591, 191);
            this.dgOption.TabIndex = 1;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.nLabel8);
            this.pnlOptions.Controls.Add(this.picAddOption);
            this.pnlOptions.Controls.Add(this.picRemoveOption);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(3, 4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.pnlOptions.Size = new System.Drawing.Size(591, 35);
            this.pnlOptions.TabIndex = 2;
            // 
            // nLabel8
            // 
            this.nLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nLabel8.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nLabel8.Location = new System.Drawing.Point(0, 2);
            this.nLabel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nLabel8.Name = "nLabel8";
            this.nLabel8.Size = new System.Drawing.Size(519, 31);
            this.nLabel8.TabIndex = 0;
            this.nLabel8.TabStop = false;
            this.nLabel8.Text = "Options";
            // 
            // picAddOption
            // 
            this.picAddOption.Dock = System.Windows.Forms.DockStyle.Right;
            this.picAddOption.Image = global::Namoo.Client.Properties.Resources.add_square_button;
            this.picAddOption.InitialImage = null;
            this.picAddOption.Location = new System.Drawing.Point(519, 2);
            this.picAddOption.Name = "picAddOption";
            this.picAddOption.Size = new System.Drawing.Size(35, 31);
            this.picAddOption.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddOption.TabIndex = 0;
            this.picAddOption.TabStop = false;
            // 
            // picRemoveOption
            // 
            this.picRemoveOption.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRemoveOption.Image = global::Namoo.Client.Properties.Resources.minus_button;
            this.picRemoveOption.Location = new System.Drawing.Point(554, 2);
            this.picRemoveOption.Name = "picRemoveOption";
            this.picRemoveOption.Size = new System.Drawing.Size(35, 31);
            this.picRemoveOption.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRemoveOption.TabIndex = 0;
            this.picRemoveOption.TabStop = false;
            // 
            // pnlFilePath
            // 
            this.pnlFilePath.Controls.Add(this.picPath);
            this.pnlFilePath.Controls.Add(this.panel5);
            this.pnlFilePath.Controls.Add(this.txtFilePath);
            this.pnlFilePath.Controls.Add(this.lblFilePath);
            this.pnlFilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilePath.Location = new System.Drawing.Point(0, 245);
            this.pnlFilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFilePath.Name = "pnlFilePath";
            this.pnlFilePath.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFilePath.Size = new System.Drawing.Size(597, 35);
            this.pnlFilePath.TabIndex = 7;
            // 
            // picPath
            // 
            this.picPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.picPath.Image = global::Namoo.Client.Properties.Resources.open_folder_outline;
            this.picPath.Location = new System.Drawing.Point(531, 4);
            this.picPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picPath.Name = "picPath";
            this.picPath.Size = new System.Drawing.Size(27, 27);
            this.picPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPath.TabIndex = 3;
            this.picPath.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(521, 4);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 27);
            this.panel5.TabIndex = 2;
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.White;
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtFilePath.Location = new System.Drawing.Point(103, 4);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(418, 27);
            this.txtFilePath.TabIndex = 0;
            // 
            // lblFilePath
            // 
            this.lblFilePath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFilePath.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFilePath.Location = new System.Drawing.Point(3, 4);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(100, 27);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.TabStop = false;
            this.lblFilePath.Text = "FilePath";
            // 
            // pnlIdPw
            // 
            this.pnlIdPw.Controls.Add(this.picShowPass);
            this.pnlIdPw.Controls.Add(this.panel6);
            this.pnlIdPw.Controls.Add(this.txtPassword);
            this.pnlIdPw.Controls.Add(this.lblPassword);
            this.pnlIdPw.Controls.Add(this.panel4);
            this.pnlIdPw.Controls.Add(this.txtId);
            this.pnlIdPw.Controls.Add(this.lblId);
            this.pnlIdPw.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIdPw.Location = new System.Drawing.Point(0, 210);
            this.pnlIdPw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlIdPw.Name = "pnlIdPw";
            this.pnlIdPw.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlIdPw.Size = new System.Drawing.Size(597, 35);
            this.pnlIdPw.TabIndex = 6;
            // 
            // picShowPass
            // 
            this.picShowPass.Dock = System.Windows.Forms.DockStyle.Left;
            this.picShowPass.Image = global::Namoo.Client.Properties.Resources.vintage_key_outline;
            this.picShowPass.Location = new System.Drawing.Point(565, 4);
            this.picShowPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picShowPass.Name = "picShowPass";
            this.picShowPass.Size = new System.Drawing.Size(27, 27);
            this.picShowPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShowPass.TabIndex = 5;
            this.picShowPass.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(555, 4);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 27);
            this.panel6.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPassword.Location = new System.Drawing.Point(384, 4);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(171, 27);
            this.txtPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPassword.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPassword.Location = new System.Drawing.Point(284, 4);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 27);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.TabStop = false;
            this.lblPassword.Text = "Password";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(274, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 27);
            this.panel4.TabIndex = 2;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtId.Location = new System.Drawing.Point(103, 4);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(171, 27);
            this.txtId.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblId.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblId.Location = new System.Drawing.Point(3, 4);
            this.lblId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(100, 27);
            this.lblId.TabIndex = 0;
            this.lblId.TabStop = false;
            this.lblId.Text = "ID";
            // 
            // pnlServiceName
            // 
            this.pnlServiceName.Controls.Add(this.panel3);
            this.pnlServiceName.Controls.Add(this.txtServiceName);
            this.pnlServiceName.Controls.Add(this.lblServiceName);
            this.pnlServiceName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlServiceName.Location = new System.Drawing.Point(0, 175);
            this.pnlServiceName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlServiceName.Name = "pnlServiceName";
            this.pnlServiceName.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlServiceName.Size = new System.Drawing.Size(597, 35);
            this.pnlServiceName.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(274, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 27);
            this.panel3.TabIndex = 2;
            // 
            // txtServiceName
            // 
            this.txtServiceName.BackColor = System.Drawing.Color.White;
            this.txtServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtServiceName.Location = new System.Drawing.Point(103, 4);
            this.txtServiceName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(171, 27);
            this.txtServiceName.TabIndex = 0;
            // 
            // lblServiceName
            // 
            this.lblServiceName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblServiceName.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblServiceName.Location = new System.Drawing.Point(3, 4);
            this.lblServiceName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(100, 27);
            this.lblServiceName.TabIndex = 0;
            this.lblServiceName.TabStop = false;
            this.lblServiceName.Text = "ServiceName";
            // 
            // pnlDatabase
            // 
            this.pnlDatabase.Controls.Add(this.txtDatabase);
            this.pnlDatabase.Controls.Add(this.lblDatabase);
            this.pnlDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatabase.Location = new System.Drawing.Point(0, 140);
            this.pnlDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDatabase.Name = "pnlDatabase";
            this.pnlDatabase.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDatabase.Size = new System.Drawing.Size(597, 35);
            this.pnlDatabase.TabIndex = 4;
            // 
            // txtDatabase
            // 
            this.txtDatabase.BackColor = System.Drawing.Color.White;
            this.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabase.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDatabase.Location = new System.Drawing.Point(103, 4);
            this.txtDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(171, 27);
            this.txtDatabase.TabIndex = 0;
            // 
            // lblDatabase
            // 
            this.lblDatabase.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDatabase.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDatabase.Location = new System.Drawing.Point(3, 4);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(100, 27);
            this.lblDatabase.TabIndex = 0;
            this.lblDatabase.TabStop = false;
            this.lblDatabase.Text = "Database";
            // 
            // pnlIP
            // 
            this.pnlIP.Controls.Add(this.txtPort);
            this.pnlIP.Controls.Add(this.lblPort);
            this.pnlIP.Controls.Add(this.panel2);
            this.pnlIP.Controls.Add(this.txtIp);
            this.pnlIP.Controls.Add(this.lblIp);
            this.pnlIP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIP.Location = new System.Drawing.Point(0, 105);
            this.pnlIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlIP.Name = "pnlIP";
            this.pnlIP.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlIP.Size = new System.Drawing.Size(597, 35);
            this.pnlIP.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.White;
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPort.Location = new System.Drawing.Point(384, 4);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(171, 27);
            this.txtPort.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPort.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPort.Location = new System.Drawing.Point(284, 4);
            this.lblPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(100, 27);
            this.lblPort.TabIndex = 3;
            this.lblPort.TabStop = false;
            this.lblPort.Text = "Port";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(274, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 27);
            this.panel2.TabIndex = 2;
            // 
            // txtIp
            // 
            this.txtIp.BackColor = System.Drawing.Color.White;
            this.txtIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIp.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtIp.Location = new System.Drawing.Point(103, 4);
            this.txtIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(171, 27);
            this.txtIp.TabIndex = 0;
            // 
            // lblIp
            // 
            this.lblIp.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblIp.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIp.Location = new System.Drawing.Point(3, 4);
            this.lblIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(100, 27);
            this.lblIp.TabIndex = 0;
            this.lblIp.TabStop = false;
            this.lblIp.Text = "IP";
            // 
            // pnlDesc
            // 
            this.pnlDesc.Controls.Add(this.txtDescription);
            this.pnlDesc.Controls.Add(this.lblDescription);
            this.pnlDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDesc.Location = new System.Drawing.Point(0, 70);
            this.pnlDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDesc.Size = new System.Drawing.Size(597, 35);
            this.pnlDesc.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(103, 4);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(491, 27);
            this.txtDescription.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDescription.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDescription.Location = new System.Drawing.Point(3, 4);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 27);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.TabStop = false;
            this.lblDescription.Text = "연결설명";
            // 
            // pnlName
            // 
            this.pnlName.Controls.Add(this.chkUse);
            this.pnlName.Controls.Add(this.cmbDBType);
            this.pnlName.Controls.Add(this.lblDBType);
            this.pnlName.Controls.Add(this.panel1);
            this.pnlName.Controls.Add(this.txtName);
            this.pnlName.Controls.Add(this.lblName);
            this.pnlName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlName.Location = new System.Drawing.Point(0, 35);
            this.pnlName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlName.Name = "pnlName";
            this.pnlName.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlName.Size = new System.Drawing.Size(597, 35);
            this.pnlName.TabIndex = 1;
            // 
            // chkUse
            // 
            this.chkUse.AutoSize = true;
            this.chkUse.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkUse.Location = new System.Drawing.Point(548, 4);
            this.chkUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkUse.Name = "chkUse";
            this.chkUse.Size = new System.Drawing.Size(46, 27);
            this.chkUse.TabIndex = 2;
            this.chkUse.Text = "사용";
            this.chkUse.UseVisualStyleBackColor = true;
            // 
            // cmbDBType
            // 
            this.cmbDBType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmbDBType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbDBType.Location = new System.Drawing.Point(384, 4);
            this.cmbDBType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDBType.Name = "cmbDBType";
            this.cmbDBType.ReadOnly = false;
            this.cmbDBType.Size = new System.Drawing.Size(100, 27);
            this.cmbDBType.StyleSet = null;
            this.cmbDBType.TabIndex = 1;
            this.cmbDBType.Text = "nComboBox1";
            // 
            // lblDBType
            // 
            this.lblDBType.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDBType.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDBType.Location = new System.Drawing.Point(284, 4);
            this.lblDBType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblDBType.Name = "lblDBType";
            this.lblDBType.Size = new System.Drawing.Size(100, 27);
            this.lblDBType.TabIndex = 3;
            this.lblDBType.TabStop = false;
            this.lblDBType.Text = "DB 종류";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(274, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 27);
            this.panel1.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtName.Location = new System.Drawing.Point(103, 4);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(171, 27);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblName.LabelFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.Location = new System.Drawing.Point(3, 4);
            this.lblName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 27);
            this.lblName.TabIndex = 0;
            this.lblName.TabStop = false;
            this.lblName.Text = "연결명";
            // 
            // pnlContentButtons
            // 
            this.pnlContentButtons.Controls.Add(this.chkDefault);
            this.pnlContentButtons.Controls.Add(this.pnlBtnSpacer３);
            this.pnlContentButtons.Controls.Add(this.btnTest);
            this.pnlContentButtons.Controls.Add(this.pnlBtnSpacer2);
            this.pnlContentButtons.Controls.Add(this.btnSave);
            this.pnlContentButtons.Controls.Add(this.pnlBtnSpacer1);
            this.pnlContentButtons.Controls.Add(this.btnDelete);
            this.pnlContentButtons.Controls.Add(this.btnNew);
            this.pnlContentButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContentButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlContentButtons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlContentButtons.Name = "pnlContentButtons";
            this.pnlContentButtons.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlContentButtons.Size = new System.Drawing.Size(597, 35);
            this.pnlContentButtons.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTest.Location = new System.Drawing.Point(113, 4);
            this.btnTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 27);
            this.btnTest.StyleSet = null;
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "연결 테스트";
            // 
            // pnlBtnSpacer2
            // 
            this.pnlBtnSpacer2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBtnSpacer2.Location = new System.Drawing.Point(108, 4);
            this.pnlBtnSpacer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBtnSpacer2.Name = "pnlBtnSpacer2";
            this.pnlBtnSpacer2.Size = new System.Drawing.Size(5, 27);
            this.pnlBtnSpacer2.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(58, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 27);
            this.btnSave.StyleSet = null;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "저장";
            // 
            // pnlBtnSpacer1
            // 
            this.pnlBtnSpacer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBtnSpacer1.Location = new System.Drawing.Point(53, 4);
            this.pnlBtnSpacer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBtnSpacer1.Name = "pnlBtnSpacer1";
            this.pnlBtnSpacer1.Size = new System.Drawing.Size(5, 27);
            this.pnlBtnSpacer1.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(544, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 27);
            this.btnDelete.StyleSet = null;
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "삭제";
            // 
            // btnNew
            // 
            this.btnNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNew.Location = new System.Drawing.Point(3, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 27);
            this.btnNew.StyleSet = null;
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "신규";
            // 
            // pnlBtnSpacer３
            // 
            this.pnlBtnSpacer３.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBtnSpacer３.Location = new System.Drawing.Point(213, 4);
            this.pnlBtnSpacer３.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBtnSpacer３.Name = "pnlBtnSpacer３";
            this.pnlBtnSpacer３.Size = new System.Drawing.Size(5, 27);
            this.pnlBtnSpacer３.TabIndex = 2;
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDefault.Location = new System.Drawing.Point(218, 4);
            this.chkDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(66, 27);
            this.chkDefault.TabIndex = 3;
            this.chkDefault.Text = "기본연결";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // ConnectionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 514);
            this.Controls.Add(this.sccMain);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConnectionManager";
            this.Text = "DBConnectionInfo";
            this.sccMain.Panel1.ResumeLayout(false);
            this.sccMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            this.pnlListTitle.ResumeLayout(false);
            this.pnlConnStr.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAddOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRemoveOption)).EndInit();
            this.pnlFilePath.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPath)).EndInit();
            this.pnlIdPw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShowPass)).EndInit();
            this.pnlServiceName.ResumeLayout(false);
            this.pnlDatabase.ResumeLayout(false);
            this.pnlIP.ResumeLayout(false);
            this.pnlDesc.ResumeLayout(false);
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlContentButtons.ResumeLayout(false);
            this.pnlContentButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sccMain;
        private System.Windows.Forms.Panel pnlListTitle;
        private System.Windows.Forms.Panel pnlContentButtons;
        private Namoo.Controls.NaLabel lblListTitle;
        private Namoo.Controls.NaButton btnTest;
        private System.Windows.Forms.Panel pnlBtnSpacer2;
        private Namoo.Controls.NaButton btnSave;
        private System.Windows.Forms.Panel pnlBtnSpacer1;
        private Namoo.Controls.NaButton btnDelete;
        private Namoo.Controls.NaButton btnNew;
        private Namoo.Controls.NaDataGrid dgConnList;
        private System.Windows.Forms.Panel pnlConnStr;
        private System.Windows.Forms.Panel pnlFilePath;
        private System.Windows.Forms.Panel pnlIdPw;
        private System.Windows.Forms.Panel pnlServiceName;
        private System.Windows.Forms.Panel pnlDatabase;
        private System.Windows.Forms.Panel pnlIP;
        private System.Windows.Forms.Panel pnlDesc;
        private System.Windows.Forms.Panel pnlName;
        private Namoo.Controls.NaLabel lblFilePath;
        private Namoo.Controls.NaLabel lblId;
        private Namoo.Controls.NaLabel lblServiceName;
        private Namoo.Controls.NaLabel lblDatabase;
        private Namoo.Controls.NaLabel lblIp;
        private Namoo.Controls.NaLabel lblDescription;
        private Namoo.Controls.NaLabel lblName;
        private Namoo.Controls.NaTextBox txtName;
        private Namoo.Controls.NaTextBox txtFilePath;
        private Namoo.Controls.NaTextBox txtId;
        private Namoo.Controls.NaTextBox txtServiceName;
        private Namoo.Controls.NaTextBox txtDatabase;
        private Namoo.Controls.NaTextBox txtIp;
        private Namoo.Controls.NaLabel lblPassword;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private Namoo.Controls.NaLabel lblPort;
        private System.Windows.Forms.Panel panel2;
        private Namoo.Controls.NaLabel lblDBType;
        private System.Windows.Forms.Panel panel1;
        private Namoo.Controls.NaComboBox cmbDBType;
        private Namoo.Controls.NaTextBox txtPassword;
        private Namoo.Controls.NaTextBox txtPort;
        private System.Windows.Forms.CheckBox chkUse;
        private System.Windows.Forms.PictureBox picPath;
        private System.Windows.Forms.Panel panel5;
        private Namoo.Controls.NaTextBox txtDescription;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox picShowPass;
        private Namoo.Controls.NaDataGrid dgOption;
        private Namoo.Controls.NaLabel nLabel8;
        private Panel pnlOptions;
        private PictureBox picAddOption;
        private PictureBox picRemoveOption;
        private CheckBox chkDefault;
        private Panel pnlBtnSpacer３;
    }
}
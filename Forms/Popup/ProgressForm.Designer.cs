namespace Namoo.Client.Forms.Popup
{
    partial class ProgressForm
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
            this.pgBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.pgText = new System.Windows.Forms.RichTextBox();
            this.pnlProgressTitle = new System.Windows.Forms.Panel();
            this.lblTicker = new Namoo.Controls.NaLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new Namoo.Controls.NaButton();
            this.lblTitle = new Namoo.Controls.NaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pgBar.Properties)).BeginInit();
            this.pnlProgressTitle.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgBar
            // 
            this.tlpMain.SetColumnSpan(this.pgBar, 3);
            this.pgBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgBar.Location = new System.Drawing.Point(8, 53);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(774, 34);
            this.pgBar.TabIndex = 0;
            // 
            // pgText
            // 
            this.tlpMain.SetColumnSpan(this.pgText, 3);
            this.pgText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgText.Location = new System.Drawing.Point(8, 98);
            this.pgText.Name = "pgText";
            this.pgText.Size = new System.Drawing.Size(774, 289);
            this.pgText.TabIndex = 1;
            this.pgText.Text = "";
            // 
            // pnlProgressTitle
            // 
            this.tlpMain.SetColumnSpan(this.pnlProgressTitle, 3);
            this.pnlProgressTitle.Controls.Add(this.lblTitle);
            this.pnlProgressTitle.Controls.Add(this.lblTicker);
            this.pnlProgressTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProgressTitle.Location = new System.Drawing.Point(8, 8);
            this.pnlProgressTitle.Name = "pnlProgressTitle";
            this.pnlProgressTitle.Size = new System.Drawing.Size(774, 34);
            this.pnlProgressTitle.TabIndex = 2;
            // 
            // lblTicker
            // 
            this.lblTicker.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTicker.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblTicker.Location = new System.Drawing.Point(671, 0);
            this.lblTicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblTicker.Name = "lblTicker";
            this.lblTicker.Size = new System.Drawing.Size(103, 34);
            this.lblTicker.TabIndex = 0;
            this.lblTicker.Text = "00:00";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(2, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMain.Size = new System.Drawing.Size(796, 446);
            this.pnlMain.TabIndex = 3;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 5;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.Controls.Add(this.pnlProgressTitle, 1, 1);
            this.tlpMain.Controls.Add(this.pgText, 1, 5);
            this.tlpMain.Controls.Add(this.pgBar, 1, 3);
            this.tlpMain.Controls.Add(this.btnCancel, 2, 7);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 9;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.Size = new System.Drawing.Size(790, 440);
            this.tlpMain.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Font = new System.Drawing.Font("Gulim", 9F);
            this.btnCancel.Location = new System.Drawing.Point(295, 395);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 40);
            this.btnCancel.StyleSet = null;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.LabelFont = new System.Drawing.Font("Gulim", 9F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(671, 34);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "";
            // 
            // ProgressForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "ProgressForm";
            ((System.ComponentModel.ISupportInitialize)(this.pgBar.Properties)).EndInit();
            this.pnlProgressTitle.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl pgBar;
        private System.Windows.Forms.RichTextBox pgText;
        private System.Windows.Forms.Panel pnlProgressTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private Namoo.Controls.NaButton btnCancel;
        private Namoo.Controls.NaLabel lblTicker;
        private Namoo.Controls.NaLabel lblTitle;
    }
}
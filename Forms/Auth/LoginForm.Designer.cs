using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace Namoo.Client.Forms.Auth
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private PanelControl panelRoot;
        private LabelControl labelTitle;
        private LabelControl labelUserId;
        private TextEdit textUserId;
        private LabelControl labelPassword;
        private TextEdit textPassword;
        private SimpleButton btnLogin;
        private LabelControl lblError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelRoot = new PanelControl();
            labelTitle = new LabelControl();
            labelUserId = new LabelControl();
            textUserId = new TextEdit();
            labelPassword = new LabelControl();
            textPassword = new TextEdit();
            btnLogin = new SimpleButton();
            lblError = new LabelControl();
            ((System.ComponentModel.ISupportInitialize)(panelRoot)).BeginInit();
            panelRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(textUserId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(textPassword.Properties)).BeginInit();
            SuspendLayout();
            //
            // panelRoot
            //
            panelRoot.Appearance.BackColor = Color.FromArgb(248, 250, 252);
            panelRoot.Appearance.Options.UseBackColor = true;
            panelRoot.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelRoot.Controls.Add(lblError);
            panelRoot.Controls.Add(btnLogin);
            panelRoot.Controls.Add(textPassword);
            panelRoot.Controls.Add(labelPassword);
            panelRoot.Controls.Add(textUserId);
            panelRoot.Controls.Add(labelUserId);
            panelRoot.Controls.Add(labelTitle);
            panelRoot.Dock = DockStyle.Fill;
            panelRoot.Location = new Point(0, 0);
            panelRoot.Margin = new Padding(4);
            panelRoot.Name = "panelRoot";
            panelRoot.Padding = new Padding(28, 24, 28, 20);
            panelRoot.Size = new Size(420, 320);
            //
            // labelTitle
            //
            labelTitle.Appearance.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            labelTitle.Appearance.ForeColor = Color.FromArgb(17, 24, 39);
            labelTitle.Appearance.Options.UseFont = true;
            labelTitle.Appearance.Options.UseForeColor = true;
            labelTitle.AutoSizeMode = LabelAutoSizeMode.None;
            labelTitle.Location = new Point(28, 24);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(364, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "로그인";
            //
            // labelUserId
            //
            labelUserId.Appearance.Font = new Font("맑은 고딕", 9F);
            labelUserId.Appearance.ForeColor = Color.FromArgb(55, 65, 81);
            labelUserId.Location = new Point(28, 72);
            labelUserId.Name = "labelUserId";
            labelUserId.Size = new Size(364, 18);
            labelUserId.TabIndex = 1;
            labelUserId.Text = "사용자 ID";
            //
            // textUserId
            //
            textUserId.Location = new Point(28, 94);
            textUserId.Name = "textUserId";
            textUserId.Properties.AutoHeight = false;
            textUserId.Properties.NullValuePrompt = "아이디";
            textUserId.Size = new Size(364, 34);
            textUserId.TabIndex = 2;
            //
            // labelPassword
            //
            labelPassword.Appearance.Font = new Font("맑은 고딕", 9F);
            labelPassword.Appearance.ForeColor = Color.FromArgb(55, 65, 81);
            labelPassword.Location = new Point(28, 140);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(364, 18);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "비밀번호";
            //
            // textPassword
            //
            textPassword.Location = new Point(28, 162);
            textPassword.Name = "textPassword";
            textPassword.Properties.AutoHeight = false;
            textPassword.Properties.NullValuePrompt = "비밀번호";
            textPassword.Properties.UseSystemPasswordChar = true;
            textPassword.Size = new Size(364, 34);
            textPassword.TabIndex = 4;
            textPassword.KeyDown += TextPassword_KeyDown;
            //
            // btnLogin
            //
            btnLogin.Appearance.BackColor = Color.FromArgb(37, 99, 235);
            btnLogin.Appearance.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnLogin.Appearance.ForeColor = Color.White;
            btnLogin.Appearance.Options.UseBackColor = true;
            btnLogin.Appearance.Options.UseFont = true;
            btnLogin.Appearance.Options.UseForeColor = true;
            btnLogin.Location = new Point(28, 216);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(364, 42);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "로그인";
            btnLogin.Click += BtnLogin_Click;
            //
            // lblError
            //
            lblError.Appearance.Font = new Font("맑은 고딕", 8.5F);
            lblError.Appearance.ForeColor = Color.FromArgb(220, 38, 38);
            lblError.Appearance.Options.UseFont = true;
            lblError.Appearance.Options.UseForeColor = true;
            lblError.AutoSizeMode = LabelAutoSizeMode.None;
            lblError.Location = new Point(28, 270);
            lblError.Name = "lblError";
            lblError.Size = new Size(364, 36);
            lblError.TabIndex = 5;
            //
            // LoginForm
            //
            Appearance.BackColor = Color.FromArgb(248, 250, 252);
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 320);
            Controls.Add(panelRoot);
            Margin = new Padding(4);
            Name = "LoginForm";
            Text = "로그인";
            ((System.ComponentModel.ISupportInitialize)(panelRoot)).EndInit();
            panelRoot.ResumeLayout(false);
            panelRoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(textUserId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(textPassword.Properties)).EndInit();
            ResumeLayout(false);
        }
    }
}

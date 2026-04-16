using DevExpress.XtraEditors;
using Namoo.Worker.Message;
using System;
using System.Windows.Forms;

namespace Namoo.Client.Forms.Auth
{
    public partial class LoginForm : XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            btnLogin.Enabled = false;
            try
            {
                NaWorkerRes res = await NaLoginClient.TryLoginAsync(textUserId.Text, textPassword.Text).ConfigureAwait(true);
                if (res != null && res.IsSuccess)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                lblError.Text = string.IsNullOrWhiteSpace(res?.Message) ? "로그인에 실패했습니다." : res.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void TextPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                BtnLogin_Click(btnLogin, EventArgs.Empty);
            }
        }
    }
}

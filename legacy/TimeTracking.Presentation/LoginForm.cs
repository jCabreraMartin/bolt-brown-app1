using System;
using System.Windows.Forms;
using TimeTracking.Business;
using TimeTracking.Data.Models;

namespace TimeTracking.Presentation
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _authenticationService;

        public LoginForm()
        {
            InitializeComponent();
            _authenticationService = new AuthenticationService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = _authenticationService.Login(username, password);

            if (user != null)
            {
                this.Hide();
                var mainForm = new MainForm(user);
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Authentication Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }
}

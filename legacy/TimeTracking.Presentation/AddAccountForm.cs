using System;
using System.Windows.Forms;
using TimeTracking.Business;

namespace TimeTracking.Presentation
{
    public partial class AddAccountForm : Form
    {
        private readonly ChargeAccountService _chargeAccountService;

        public AddAccountForm()
        {
            InitializeComponent();
            _chargeAccountService = new ChargeAccountService();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string description = txtDescription.Text.Trim();

            var result = _chargeAccountService.AddChargeAccount(code, description);

            if (result.Success)
            {
                MessageBox.Show(result.Message, "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

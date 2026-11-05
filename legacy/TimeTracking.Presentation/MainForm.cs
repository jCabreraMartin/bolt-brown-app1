using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TimeTracking.Business;
using TimeTracking.Data.Models;

namespace TimeTracking.Presentation
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;
        private readonly FortnightService _fortnightService;
        private readonly TimeEntryService _timeEntryService;
        private readonly ChargeAccountService _chargeAccountService;
        private FortnightInfo _currentFortnight;
        private DateTime[] _fortnightDays;
        private List<ChargeAccount> _chargeAccounts;
        private bool _updatingGrid;

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _fortnightService = new FortnightService();
            _timeEntryService = new TimeEntryService();
            _chargeAccountService = new ChargeAccountService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupHeader();
            LoadFortnight();
            SetupGrid();
            LoadData();
        }

        private void SetupHeader()
        {
            lblUserName.Text = _currentUser.FullName;
            lblCurrentDate.Text = DateTime.Today.ToString("dddd, MMMM dd, yyyy", new CultureInfo("en-US"));
        }

        private void LoadFortnight()
        {
            LoadFortnightByDate(DateTime.Today);
        }

        private void LoadFortnightByDate(DateTime date)
        {
            _currentFortnight = _fortnightService.GetFortnightByDate(date);
            _fortnightDays = _fortnightService.GetFortnightDays(_currentFortnight);
            lblFortnight.Text = _currentFortnight.Description;
        }

        private void btnPrevFortnight_Click(object sender, EventArgs e)
        {
            LoadFortnightByDate(_currentFortnight.StartDate.AddDays(-1));
            SetupGrid();
            LoadData();
        }

        private void btnNextFortnight_Click(object sender, EventArgs e)
        {
            LoadFortnightByDate(_currentFortnight.EndDate.AddDays(1));
            SetupGrid();
            LoadData();
        }

        private void SetupGrid()
        {
            dgvHours.Columns.Clear();
            dgvHours.Rows.Clear();

            var colAccount = new DataGridViewComboBoxColumn
            {
                Name = "colChargeAccount",
                HeaderText = "Charge Account",
                Width = 220,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                FlatStyle = FlatStyle.Flat
            };

            _chargeAccounts = _chargeAccountService.GetActiveAccounts();
            colAccount.Items.Add("");
            foreach (var account in _chargeAccounts)
            {
                colAccount.Items.Add(string.Format("{0} - {1}", account.Code, account.Description));
            }
            dgvHours.Columns.Add(colAccount);

            foreach (var day in _fortnightDays)
            {
                string abbreviation = _fortnightService.GetDayOfWeekAbbreviation(day.DayOfWeek);
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "col_" + day.ToString("yyyyMMdd"),
                    HeaderText = day.Day.ToString() + "\n" + abbreviation,
                    Width = 45,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                };

                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    col.DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
                }

                dgvHours.Columns.Add(col);
            }

            var colTotal = new DataGridViewTextBoxColumn
            {
                Name = "colRowTotal",
                HeaderText = "Total",
                Width = 60,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(220, 235, 250),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            };
            dgvHours.Columns.Add(colTotal);

            dgvHours.AllowUserToAddRows = false;
            dgvHours.AllowUserToDeleteRows = false;
            dgvHours.RowHeadersVisible = false;
            dgvHours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHours.ColumnHeadersHeight = 45;
            dgvHours.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvHours.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dgvHours.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadData()
        {
            _updatingGrid = true;

            var entries = _timeEntryService.GetFortnightEntries(_currentUser.Id, _currentFortnight);

            var accountsWithEntries = entries
                .Select(e => e.ChargeAccountId)
                .Distinct()
                .ToList();

            dgvHours.Rows.Clear();

            foreach (int accountId in accountsWithEntries)
            {
                var account = _chargeAccounts.FirstOrDefault(a => a.Id == accountId);
                if (account == null) continue;

                int rowIndex = dgvHours.Rows.Add();
                var row = dgvHours.Rows[rowIndex];

                string accountDisplay = string.Format("{0} - {1}", account.Code, account.Description);
                row.Cells["colChargeAccount"].Value = accountDisplay;

                foreach (var day in _fortnightDays)
                {
                    var entry = entries.FirstOrDefault(e => e.ChargeAccountId == accountId && e.Date.Date == day.Date);
                    if (entry != null && entry.Hours > 0)
                    {
                        string colName = "col_" + day.ToString("yyyyMMdd");
                        row.Cells[colName].Value = entry.Hours.ToString("0.#");
                    }
                }

                decimal rowTotal = _timeEntryService.CalculateTotalByAccount(entries, accountId);
                row.Cells["colRowTotal"].Value = rowTotal.ToString("0.#");
            }

            if (dgvHours.Rows.Count == 0 || !string.IsNullOrEmpty(dgvHours.Rows[dgvHours.Rows.Count - 1].Cells["colChargeAccount"].Value as string))
            {
                dgvHours.Rows.Add();
            }

            UpdateDayTotals();

            _updatingGrid = false;
        }

        private void UpdateDayTotals()
        {
            decimal grandTotal = 0;

            foreach (var day in _fortnightDays)
            {
                string colName = "col_" + day.ToString("yyyyMMdd");
                decimal dayTotal = 0;

                for (int i = 0; i < dgvHours.Rows.Count; i++)
                {
                    var value = dgvHours.Rows[i].Cells[colName].Value;
                    if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        decimal hours = _timeEntryService.ParseHours(value.ToString());
                        dayTotal += hours;
                    }
                }

                grandTotal += dayTotal;
            }

            lblTotalHours.Text = string.Format("Fortnight total: {0:0.#} hours", grandTotal);

            for (int i = 0; i < dgvHours.Rows.Count; i++)
            {
                decimal rowTotal = 0;
                foreach (var day in _fortnightDays)
                {
                    string colName = "col_" + day.ToString("yyyyMMdd");
                    var value = dgvHours.Rows[i].Cells[colName].Value;
                    if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        rowTotal += _timeEntryService.ParseHours(value.ToString());
                    }
                }
                dgvHours.Rows[i].Cells["colRowTotal"].Value = rowTotal > 0 ? rowTotal.ToString("0.#") : "";
            }
        }

        private void dgvHours_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_updatingGrid || e.RowIndex < 0) return;

            string colName = dgvHours.Columns[e.ColumnIndex].Name;

            if (colName.StartsWith("col_") && colName != "colChargeAccount" && colName != "colRowTotal")
            {
                var value = dgvHours.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                string valueStr = value != null ? value.ToString() : "";

                if (!string.IsNullOrWhiteSpace(valueStr) && !_timeEntryService.ValidateHoursFormat(valueStr))
                {
                    MessageBox.Show("Invalid hours format.\nUse whole numbers or one decimal place (e.g. 8, 7.5).",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvHours.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    return;
                }

                SaveCellToDatabase(e.RowIndex, colName, valueStr);
                UpdateDayTotals();
            }

            if (colName == "colChargeAccount")
            {
                if (e.RowIndex == dgvHours.Rows.Count - 1)
                {
                    var value = dgvHours.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                    {
                        dgvHours.Rows.Add();
                    }
                }
            }
        }

        private void SaveCellToDatabase(int rowIndex, string colName, string valueStr)
        {
            var accountValue = dgvHours.Rows[rowIndex].Cells["colChargeAccount"].Value;
            if (accountValue == null || string.IsNullOrEmpty(accountValue.ToString())) return;

            string accountDisplay = accountValue.ToString();
            int separatorIndex = accountDisplay.IndexOf(" - ");
            if (separatorIndex < 0) return;
            string accountCode = accountDisplay.Substring(0, separatorIndex).Trim();

            var account = _chargeAccounts.FirstOrDefault(a => a.Code == accountCode);
            if (account == null) return;

            string dateStr = colName.Replace("col_", "");
            DateTime date = DateTime.ParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture);

            decimal hours = _timeEntryService.ParseHours(valueStr);
            _timeEntryService.SaveHours(_currentUser.Id, account.Id, date, hours);
        }

        private void dgvHours_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = dgvHours.Columns[e.ColumnIndex].Name;
            if (colName.StartsWith("col_") && colName != "colChargeAccount" && colName != "colRowTotal")
            {
                string value = e.FormattedValue.ToString();
                if (!string.IsNullOrWhiteSpace(value) && !_timeEntryService.ValidateHoursFormat(value))
                {
                    e.Cancel = true;
                    MessageBox.Show("Invalid hours format.\nUse whole numbers or one decimal place (e.g. 8, 7.5).",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvHours_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvHours.IsCurrentCellDirty)
            {
                dgvHours.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            using (var form = new AddAccountForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SetupGrid();
                    LoadData();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string help = "TIME TRACKING - Help\n" +
                "==============================\n\n" +
                "1. Select a charge account from the dropdown.\n" +
                "2. Enter the hours worked for each day.\n" +
                "3. Valid format: whole numbers (8) or one decimal place (7.5).\n" +
                "4. Totals are calculated automatically.\n" +
                "5. Use 'Add Account' to create new charge accounts.\n\n" +
                "The fortnight is detected automatically:\n" +
                "  - First fortnight: days 1-15\n" +
                "  - Second fortnight: days 16-end of month\n\n" +
                "Data is saved automatically when values are entered.";

            MessageBox.Show(help, "Help - Time Tracking",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to sign out?", "Sign Out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

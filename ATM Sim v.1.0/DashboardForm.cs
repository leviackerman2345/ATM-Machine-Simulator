using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ATM_Sim_v._1._0
{
    public partial class DashboardForm : Form
    {
        private readonly ATMCore atm;

        public DashboardForm(ATMCore atm)
        {
            InitializeComponent();
            this.atm = atm;
            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            var account = atm.GetCurrentAccount();
            if (account == null)
            {
                MessageBox.Show(this, "No active session.", "Session Ended", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            nameLabel.Text = $"Welcome, {account.CardholderName}";
            balanceLabel.Text = $"Balance: ${account.Balance:F2}";
        }

        private void BalanceBtn_Click(object? sender, EventArgs e)
        {
            RefreshDashboard();
            MessageBox.Show(this, balanceLabel.Text, "Current Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WithdrawBtn_Click(object? sender, EventArgs e)
        {
            var value = PromptForAmount("Withdraw", "Enter amount to withdraw:");
            if (value == null) return;

            if (!atm.Withdraw(value.Value))
            {
                MessageBox.Show(this, "Insufficient funds.", "Withdrawal Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RefreshDashboard();
            MessageBox.Show(this, "Withdrawal successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DepositBtn_Click(object? sender, EventArgs e)
        {
            var value = PromptForAmount("Deposit", "Enter amount to deposit:");
            if (value == null) return;

            atm.Deposit(value.Value);
            RefreshDashboard();
            MessageBox.Show(this, "Deposit successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangePinBtn_Click(object? sender, EventArgs e)
        {
            var oldPin = PromptForInput("Change PIN", "Enter current PIN:", true);
            if (string.IsNullOrWhiteSpace(oldPin)) return;

            var newPin = PromptForInput("Change PIN", "Enter new PIN:", true);
            if (string.IsNullOrWhiteSpace(newPin)) return;

            if (!atm.ChangePin(oldPin, newPin))
            {
                MessageBox.Show(this, "Current PIN is incorrect.", "Change PIN Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(this, "PIN changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LogoutBtn_Click(object? sender, EventArgs e)
        {
            atm.Logout();
            Close();
        }

        private static decimal? PromptForAmount(string title, string prompt)
        {
            var input = PromptForInput(title, prompt, false);
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (!decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out var amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return amount;
        }

        private static string? PromptForInput(string title, string prompt, bool isPassword)
        {
            using var dialog = new Form();
            dialog.Text = title;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ClientSize = new Size(320, 150);
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;

            var label = new Label
            {
                Text = prompt,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var textBox = new TextBox
            {
                Dock = DockStyle.Top,
                UseSystemPasswordChar = isPassword,
                TextAlign = HorizontalAlignment.Center
            };

            var okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Left,
                Width = 150
            };

            var cancelButton = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Dock = DockStyle.Right,
                Width = 150
            };

            var buttonsPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40
            };
            buttonsPanel.Controls.Add(okButton);
            buttonsPanel.Controls.Add(cancelButton);

            dialog.Controls.Add(buttonsPanel);
            dialog.Controls.Add(textBox);
            dialog.Controls.Add(label);
            dialog.AcceptButton = okButton;
            dialog.CancelButton = cancelButton;

            return dialog.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : null;
        }
    }
}

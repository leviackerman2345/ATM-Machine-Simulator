using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ATM_Sim_v._1._0
{
    public partial class PasswordForm : Form
    {
        private readonly ATMCore atm;
        private readonly string cardNumber;

        public PasswordForm(ATMCore atm, string cardNumber)
        {
            InitializeComponent();
            this.atm = atm;
            this.cardNumber = cardNumber;
        }

        private void ProceedBtn_Click(object? sender, EventArgs e)
        {
            var pin = pinTextBox.Text.Trim();
            if (pin.Length < 4 || !pin.All(char.IsDigit))
            {
                MessageBox.Show(this, "Please enter a valid PIN (at least 4 digits).", "Invalid PIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!atm.AuthenticateCard(cardNumber, pin))
            {
                MessageBox.Show(this, "Incorrect PIN. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pinTextBox.Text = string.Empty;
                return;
            }

            using var dashboard = new DashboardForm(atm);
            Hide();
            dashboard.ShowDialog(this);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BackBtn_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

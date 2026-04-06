using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ATM_Sim_v._1._0
{
    public partial class CardEntryForm : Form
    {
        private readonly ATMCore atm;

        public CardEntryForm()
        {
            InitializeComponent();
            atm = new ATMCore();
        }

        private void CardNumberTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ProceedBtn_Click(object? sender, EventArgs e)
        {
            var cardNumber = cardNumberTextBox.Text.Trim();
            if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
            {
                MessageBox.Show(this, "Please enter a valid 16-digit card number.", "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!atm.IsRegisteredCard(cardNumber))
            {
                MessageBox.Show(this, "Card number is not registered.", "Card Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var passwordForm = new PasswordForm(atm, cardNumber);
            Hide();
            var result = passwordForm.ShowDialog(this);
            Show();

            if (result == DialogResult.OK)
            {
                cardNumberTextBox.Text = string.Empty;
            }
        }

        private void ExitBtn_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

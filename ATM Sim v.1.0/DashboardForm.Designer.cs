using System.Drawing;
using System.Windows.Forms;

namespace ATM_Sim_v._1._0
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label titleLabel;
        private Label nameLabel;
        private Label balanceLabel;
        private Button balanceBtn;
        private Button withdrawBtn;
        private Button depositBtn;
        private Button changePinBtn;
        private Button logoutBtn;

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

            titleLabel = new Label();
            nameLabel = new Label();
            balanceLabel = new Label();
            balanceBtn = new Button();
            withdrawBtn = new Button();
            depositBtn = new Button();
            changePinBtn = new Button();
            logoutBtn = new Button();

            titleLabel.Text = "ATM Dashboard";
            titleLabel.Font = new Font("Arial", 20F, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 60;

            nameLabel.Text = "Welcome";
            nameLabel.Font = new Font("Arial", 12F, FontStyle.Regular);
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.Dock = DockStyle.Top;
            nameLabel.Height = 30;

            balanceLabel.Text = "Balance: $0.00";
            balanceLabel.Font = new Font("Arial", 12F, FontStyle.Bold);
            balanceLabel.TextAlign = ContentAlignment.MiddleCenter;
            balanceLabel.Dock = DockStyle.Top;
            balanceLabel.Height = 30;

            balanceBtn.Text = "Balance";
            balanceBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            balanceBtn.Height = 40;
            balanceBtn.Dock = DockStyle.Top;
            balanceBtn.Click += BalanceBtn_Click;

            withdrawBtn.Text = "Withdraw";
            withdrawBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            withdrawBtn.Height = 40;
            withdrawBtn.Dock = DockStyle.Top;
            withdrawBtn.Click += WithdrawBtn_Click;

            depositBtn.Text = "Deposit";
            depositBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            depositBtn.Height = 40;
            depositBtn.Dock = DockStyle.Top;
            depositBtn.Click += DepositBtn_Click;

            changePinBtn.Text = "Change PIN";
            changePinBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            changePinBtn.Height = 40;
            changePinBtn.Dock = DockStyle.Top;
            changePinBtn.Click += ChangePinBtn_Click;

            logoutBtn.Text = "Logout";
            logoutBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            logoutBtn.Height = 40;
            logoutBtn.Dock = DockStyle.Top;
            logoutBtn.Click += LogoutBtn_Click;

            Controls.Add(logoutBtn);
            Controls.Add(changePinBtn);
            Controls.Add(depositBtn);
            Controls.Add(withdrawBtn);
            Controls.Add(balanceBtn);
            Controls.Add(balanceLabel);
            Controls.Add(nameLabel);
            Controls.Add(titleLabel);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 420);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ATM Dashboard";
        }
    }
}

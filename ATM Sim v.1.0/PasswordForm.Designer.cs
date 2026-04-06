using System.Drawing;
using System.Windows.Forms;

namespace ATM_Sim_v._1._0
{
    partial class PasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label titleLabel;
        private Label promptLabel;
        private TextBox pinTextBox;
        private Button proceedBtn;
        private Button backBtn;

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
            promptLabel = new Label();
            pinTextBox = new TextBox();
            proceedBtn = new Button();
            backBtn = new Button();

            titleLabel.Text = "ATM - Password";
            titleLabel.Font = new Font("Arial", 20F, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 60;

            promptLabel.Text = "Enter your PIN";
            promptLabel.Font = new Font("Arial", 11F, FontStyle.Regular);
            promptLabel.TextAlign = ContentAlignment.MiddleCenter;
            promptLabel.Dock = DockStyle.Top;
            promptLabel.Height = 30;

            pinTextBox.Font = new Font("Consolas", 14F, FontStyle.Regular);
            pinTextBox.Dock = DockStyle.Top;
            pinTextBox.MaxLength = 12;
            pinTextBox.UseSystemPasswordChar = true;
            pinTextBox.TextAlign = HorizontalAlignment.Center;

            proceedBtn.Text = "Proceed";
            proceedBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            proceedBtn.Height = 40;
            proceedBtn.Dock = DockStyle.Top;
            proceedBtn.Click += ProceedBtn_Click;

            backBtn.Text = "Back";
            backBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            backBtn.Height = 40;
            backBtn.Dock = DockStyle.Top;
            backBtn.Click += BackBtn_Click;

            Controls.Add(backBtn);
            Controls.Add(proceedBtn);
            Controls.Add(pinTextBox);
            Controls.Add(promptLabel);
            Controls.Add(titleLabel);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 260);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ATM - Password";
        }
    }
}

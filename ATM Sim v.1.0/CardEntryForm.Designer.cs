using System.Drawing;
using System.Windows.Forms;

namespace ATM_Sim_v._1._0
{
    partial class CardEntryForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label titleLabel;
        private Label promptLabel;
        private TextBox cardNumberTextBox;
        private Button proceedBtn;
        private Button exitBtn;

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
            cardNumberTextBox = new TextBox();
            proceedBtn = new Button();
            exitBtn = new Button();

            titleLabel.Text = "ATM - Card Entry";
            titleLabel.Font = new Font("Arial", 20F, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 60;

            promptLabel.Text = "Enter your 16-digit card number";
            promptLabel.Font = new Font("Arial", 11F, FontStyle.Regular);
            promptLabel.TextAlign = ContentAlignment.MiddleCenter;
            promptLabel.Dock = DockStyle.Top;
            promptLabel.Height = 30;

            cardNumberTextBox.Font = new Font("Consolas", 14F, FontStyle.Regular);
            cardNumberTextBox.Dock = DockStyle.Top;
            cardNumberTextBox.MaxLength = 16;
            cardNumberTextBox.Margin = new Padding(20);
            cardNumberTextBox.TextAlign = HorizontalAlignment.Center;
            cardNumberTextBox.KeyPress += CardNumberTextBox_KeyPress;

            proceedBtn.Text = "Proceed";
            proceedBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            proceedBtn.Height = 40;
            proceedBtn.Dock = DockStyle.Top;
            proceedBtn.Click += ProceedBtn_Click;

            exitBtn.Text = "Exit";
            exitBtn.Font = new Font("Arial", 11F, FontStyle.Bold);
            exitBtn.Height = 40;
            exitBtn.Dock = DockStyle.Top;
            exitBtn.Click += ExitBtn_Click;

            Controls.Add(exitBtn);
            Controls.Add(proceedBtn);
            Controls.Add(cardNumberTextBox);
            Controls.Add(promptLabel);
            Controls.Add(titleLabel);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 280);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ATM - Card Entry";
        }
    }
}

namespace ATM_Sim_v._1._0
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Panel mainPanel;
        private Panel screenPanel;
        private Panel contentPanel;
        private Panel buttonsPanel;
        private FlowLayoutPanel topButtonsPanel;
        private TableLayoutPanel numberPadPanel;
        private Panel inputPanel;
        private FlowLayoutPanel controlButtonsPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Main Panel
            mainPanel = new Panel();
            mainPanel.BackColor = Color.FromArgb(240, 240, 240);
            mainPanel.Dock = DockStyle.Fill;

            // Header Label
            Label headerLabel = new Label();
            headerLabel.Text = "ATM MACHINE";
            headerLabel.Font = new Font("Arial", 28, FontStyle.Bold);
            headerLabel.ForeColor = Color.FromArgb(0, 51, 102);
            headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            headerLabel.Height = 60;
            headerLabel.Dock = DockStyle.Top;

            // Display Screen Panel
            screenPanel = new Panel();
            screenPanel.BackColor = Color.FromArgb(0, 51, 102);
            screenPanel.Height = 140;
            screenPanel.Dock = DockStyle.Top;
            screenPanel.Padding = new Padding(15);

            displayLabel = new Label();
            displayLabel.Text = "WELCOME\r\nEnter your card number";
            displayLabel.Font = new Font("Courier New", 12, FontStyle.Regular);
            displayLabel.ForeColor = Color.Lime;
            displayLabel.BackColor = Color.FromArgb(0, 20, 40);
            displayLabel.TextAlign = ContentAlignment.MiddleCenter;
            displayLabel.Dock = DockStyle.Fill;
            displayLabel.BorderStyle = BorderStyle.Fixed3D;
            screenPanel.Controls.Add(displayLabel);

            // Start/Insert Card button
            startBtn = CreateButton("Insert Card / Start");
            startBtn.Height = 35;
            startBtn.Dock = DockStyle.Bottom;
            startBtn.Margin = new Padding(0);
            screenPanel.Controls.Add(startBtn);

            // Main Content Panel
            contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(20);

            // Buttons Panel
            buttonsPanel = new Panel();
            buttonsPanel.Dock = DockStyle.Fill;
            buttonsPanel.Padding = new Padding(10);

            // Transaction Buttons - Top Row
            topButtonsPanel = new FlowLayoutPanel();
            topButtonsPanel.Height = 50;
            topButtonsPanel.Dock = DockStyle.Top;
            topButtonsPanel.Padding = new Padding(5);
            topButtonsPanel.AutoSize = false;
            topButtonsPanel.WrapContents = false;

            withdrawBtn = CreateButton("Withdraw");
            withdrawBtn.Width = 115;
            withdrawBtn.Height = 35;
            withdrawBtn.Margin = new Padding(3);

            depositBtn = CreateButton("Deposit");
            depositBtn.Width = 115;
            depositBtn.Height = 35;
            depositBtn.Margin = new Padding(3);

            balanceBtn = CreateButton("Balance");
            balanceBtn.Width = 115;
            balanceBtn.Height = 35;
            balanceBtn.Margin = new Padding(3);

            changePinBtn = CreateButton("Change PIN");
            changePinBtn.Width = 115;
            changePinBtn.Height = 35;
            changePinBtn.Margin = new Padding(3);

            logoutBtn = CreateButton("Logout");
            logoutBtn.Width = 115;
            logoutBtn.Height = 35;
            logoutBtn.Margin = new Padding(3);

            topButtonsPanel.Controls.AddRange(new Control[] { withdrawBtn, depositBtn, balanceBtn, changePinBtn, logoutBtn });

            // Number Pad - Grid 3x4
            numberPadPanel = new TableLayoutPanel();
            numberPadPanel.MinimumSize = new Size(0, 240);
            numberPadPanel.Dock = DockStyle.Fill;
            numberPadPanel.Padding = new Padding(5);
            numberPadPanel.ColumnCount = 3;
            numberPadPanel.RowCount = 4;
            numberPadPanel.AutoSize = false;
            numberPadPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            numberPadPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            numberPadPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            numberPadPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            numberPadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            numberPadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            numberPadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            numberPadPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            numberButtons = new Button[12];
            keypad1 = CreateKeypadButton("1");
            keypad2 = CreateKeypadButton("2");
            keypad3 = CreateKeypadButton("3");
            keypad4 = CreateKeypadButton("4");
            keypad5 = CreateKeypadButton("5");
            keypad6 = CreateKeypadButton("6");
            keypad7 = CreateKeypadButton("7");
            keypad8 = CreateKeypadButton("8");
            keypad9 = CreateKeypadButton("9");
            keypadStar = CreateKeypadButton("*");
            keypad0 = CreateKeypadButton("0");
            keypadHash = CreateKeypadButton("#");

            numberButtons[0] = keypad1;
            numberButtons[1] = keypad2;
            numberButtons[2] = keypad3;
            numberButtons[3] = keypad4;
            numberButtons[4] = keypad5;
            numberButtons[5] = keypad6;
            numberButtons[6] = keypad7;
            numberButtons[7] = keypad8;
            numberButtons[8] = keypad9;
            numberButtons[9] = keypadStar;
            numberButtons[10] = keypad0;
            numberButtons[11] = keypadHash;

            numberPadPanel.Controls.Add(keypad1, 0, 0);
            numberPadPanel.Controls.Add(keypad2, 1, 0);
            numberPadPanel.Controls.Add(keypad3, 2, 0);
            numberPadPanel.Controls.Add(keypad4, 0, 1);
            numberPadPanel.Controls.Add(keypad5, 1, 1);
            numberPadPanel.Controls.Add(keypad6, 2, 1);
            numberPadPanel.Controls.Add(keypad7, 0, 2);
            numberPadPanel.Controls.Add(keypad8, 1, 2);
            numberPadPanel.Controls.Add(keypad9, 2, 2);
            numberPadPanel.Controls.Add(keypadStar, 0, 3);
            numberPadPanel.Controls.Add(keypad0, 1, 3);
            numberPadPanel.Controls.Add(keypadHash, 2, 3);

            // Input Display
            inputPanel = new Panel();
            inputPanel.Height = 40;
            inputPanel.Dock = DockStyle.Top;
            inputPanel.Padding = new Padding(5);
            inputPanel.BackColor = Color.White;

            inputLabel = new Label();
            inputLabel.Text = "";
            inputLabel.Font = new Font("Courier New", 14, FontStyle.Regular);
            inputLabel.ForeColor = Color.Black;
            inputLabel.BackColor = Color.FromArgb(230, 230, 230);
            inputLabel.TextAlign = ContentAlignment.MiddleRight;
            inputLabel.Dock = DockStyle.Fill;
            inputLabel.BorderStyle = BorderStyle.Fixed3D;
            inputPanel.Controls.Add(inputLabel);

            // Control Buttons - Clear and Enter
            controlButtonsPanel = new FlowLayoutPanel();
            controlButtonsPanel.Height = 50;
            controlButtonsPanel.Dock = DockStyle.Top;
            controlButtonsPanel.Padding = new Padding(5);
            controlButtonsPanel.AutoSize = false;
            controlButtonsPanel.WrapContents = false;

            clearBtn = CreateButton("Clear");
            clearBtn.Width = 145;
            clearBtn.Height = 35;
            clearBtn.BackColor = Color.FromArgb(200, 100, 100);
            clearBtn.Margin = new Padding(3);
            clearBtn.Click += ClearBtn_Click;

            eraseBtn = CreateButton("Erase");
            eraseBtn.Width = 145;
            eraseBtn.Height = 35;
            eraseBtn.BackColor = Color.FromArgb(220, 170, 90);
            eraseBtn.Margin = new Padding(3);
            eraseBtn.Click += EraseBtn_Click;

            enterBtn = CreateButton("Enter");
            enterBtn.Width = 145;
            enterBtn.Height = 35;
            enterBtn.BackColor = Color.FromArgb(100, 200, 100);
            enterBtn.Margin = new Padding(3);
            enterBtn.Click += EnterBtn_Click;

            proceedBtn = CreateButton("Proceed");
            proceedBtn.Width = 145;
            proceedBtn.Height = 35;
            proceedBtn.BackColor = Color.FromArgb(80, 140, 220);
            proceedBtn.Margin = new Padding(3);
            proceedBtn.Click += EnterBtn_Click;

            controlButtonsPanel.Controls.AddRange(new Control[] { clearBtn, eraseBtn, enterBtn, proceedBtn });

            // Add in correct dock order (top items first, fill last)
            buttonsPanel.Controls.Add(numberPadPanel);
            buttonsPanel.Controls.Add(controlButtonsPanel);
            buttonsPanel.Controls.Add(inputPanel);
            buttonsPanel.Controls.Add(topButtonsPanel);

            // Message Label
            messageLabel = new Label();
            messageLabel.Text = "Ready";
            messageLabel.Font = new Font("Arial", 10);
            messageLabel.ForeColor = Color.FromArgb(0, 100, 0);
            messageLabel.Height = 30;
            messageLabel.Dock = DockStyle.Bottom;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;

            contentPanel.Controls.AddRange(new Control[] { messageLabel, buttonsPanel });

            mainPanel.Controls.AddRange(new Control[] { headerLabel, screenPanel, contentPanel });

            // Form Settings
            Controls.Add(mainPanel);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 600);
            Text = "ATM Simulator v1.0";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(240, 240, 240);
        }

        private Button CreateKeypadButton(string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Arial", 16, FontStyle.Bold);
            btn.BackColor = Color.FromArgb(100, 150, 200);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.Dock = DockStyle.Fill;
            btn.Margin = new Padding(2);
            btn.Cursor = Cursors.Hand;
            btn.Click += KeypadButton_Click;
            return btn;
        }

        private void KeypadButton_Click(object? sender, EventArgs e)
        {
            if (numberButtons == null || numberButtons.Length == 0 || !numberButtons[0].Enabled)
            {
                return;
            }
            if (sender is Button btn)
            {
                inputLabel.Text += btn.Text;
            }
        }

        private Button CreateButton(string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Arial", 10, FontStyle.Bold);
            btn.BackColor = Color.FromArgb(0, 51, 102);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 2;
            btn.Cursor = Cursors.Hand;
            return btn;
        }

        private void ClearBtn_Click(object? sender, EventArgs e)
        {
            inputLabel.Text = "";
        }

        private void EraseBtn_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputLabel.Text))
            {
                inputLabel.Text = inputLabel.Text[..^1];
            }
        }

        private void EnterBtn_Click(object? sender, EventArgs e)
        {
            ProcessInput();
        }

        #endregion

        private Label displayLabel;
        private Label inputLabel;
        private Label messageLabel;
        private Button withdrawBtn;
        private Button depositBtn;
        private Button balanceBtn;
        private Button changePinBtn;
        private Button logoutBtn;
        private Button clearBtn;
        private Button eraseBtn;
        private Button enterBtn;
        private Button proceedBtn;
        private Button[] numberButtons;

        private Button startBtn;

        private Button keypad1;
        private Button keypad2;
        private Button keypad3;
        private Button keypad4;
        private Button keypad5;
        private Button keypad6;
        private Button keypad7;
        private Button keypad8;
        private Button keypad9;
        private Button keypad0;
        private Button keypadStar;
        private Button keypadHash;
    }
}

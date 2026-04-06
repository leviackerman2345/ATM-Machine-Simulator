namespace ATM_Sim_v._1._0
{
    public partial class Form1 : Form
    {
        private ATMCore atm;
        private ATMState currentState = ATMState.CardEntry;
        private string? enteredCardNumber;
        private string? pendingOldPin;
        private string? pendingNewPin;
        private bool suppressPreview;

        private enum ATMState
        {
            CardEntry,
            PasswordEntry,
            Dashboard,
            EnteringWithdrawAmount,
            EnteringDepositAmount,
            EnteringOldPin,
            EnteringNewPin,
            EnteringNewPinConfirm
        }

        public Form1()
        {
            InitializeComponent();
            atm = new ATMCore();
            EnableNumberPad(false);
            HideTransactionButtons();
            SetupEventHandlers();

            enteredCardNumber = null;
            UpdateWelcomeState();

            inputLabel.TextChanged += InputLabel_TextChanged;
        }

        private void InputLabel_TextChanged(object? sender, EventArgs e)
        {
            if (!suppressPreview)
            {
                RenderCurrentScreenPreview();
            }
        }

        private void RenderCurrentScreenPreview()
        {
            var input = inputLabel.Text;

            switch (currentState)
            {
                case ATMState.CardEntry:
                    UpdateDisplay($"CARD ENTRY\r\nEnter card number\r\n{FormatCardEntryPreview(input)}");
                    break;
                case ATMState.PasswordEntry:
                    UpdateDisplay($"CARD: {MaskCardNumber(enteredCardNumber ?? string.Empty)}\r\nEnter password (PIN)\r\n{new string('•', input.Length)}");
                    break;
                case ATMState.Dashboard:
                    // Dashboard screen is set by actions; no live preview needed.
                    break;
                case ATMState.EnteringWithdrawAmount:
                    UpdateDisplay($"Enter amount to withdraw\r\n{input}");
                    break;
                case ATMState.EnteringDepositAmount:
                    UpdateDisplay($"Enter amount to deposit\r\n{input}");
                    break;
                case ATMState.EnteringOldPin:
                    UpdateDisplay($"Enter current PIN\r\n{new string('•', input.Length)}");
                    break;
                case ATMState.EnteringNewPin:
                    UpdateDisplay($"Enter new PIN\r\n{new string('•', input.Length)}");
                    break;
                case ATMState.EnteringNewPinConfirm:
                    UpdateDisplay($"Confirm new PIN\r\n{new string('•', input.Length)}");
                    break;
            }
        }

        private string FilterInputForState(string input)
        {
            switch (currentState)
            {
                case ATMState.CardEntry:
                    return new string(input.Where(char.IsDigit).Take(16).ToArray());
                case ATMState.PasswordEntry:
                case ATMState.EnteringOldPin:
                case ATMState.EnteringNewPin:
                case ATMState.EnteringNewPinConfirm:
                    return new string(input.Where(char.IsDigit).Take(12).ToArray());

                case ATMState.EnteringWithdrawAmount:
                case ATMState.EnteringDepositAmount:
                    {
                        bool usedDot = false;
                        var chars = new List<char>(input.Length);
                        foreach (var c in input)
                        {
                            if (char.IsDigit(c))
                            {
                                chars.Add(c);
                            }
                            else if (c == '.' && !usedDot)
                            {
                                chars.Add(c);
                                usedDot = true;
                            }
                        }
                        return new string(chars.ToArray());
                    }

                default:
                    return input;
            }
        }

        private static string FormatCardEntryPreview(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var digits = new string(input.Where(char.IsDigit).Take(16).ToArray());
            var groups = Enumerable.Range(0, (digits.Length + 3) / 4)
                .Select(i => digits.Substring(i * 4, Math.Min(4, digits.Length - (i * 4))));
            return string.Join("-", groups);
        }

        private void SetupEventHandlers()
        {
            withdrawBtn.Click += WithdrawBtn_Click;
            depositBtn.Click += DepositBtn_Click;
            balanceBtn.Click += BalanceBtn_Click;
            changePinBtn.Click += ChangePinBtn_Click;
            logoutBtn.Click += LogoutBtn_Click;
            if (startBtn != null)
            {
                startBtn.Click += StartBtn_Click;
            }
        }

        private void StartBtn_Click(object? sender, EventArgs e)
        {
            UpdateWelcomeState();
        }

        private void UpdateWelcomeState()
        {
            currentState = ATMState.CardEntry;
            enteredCardNumber = null;
            pendingOldPin = null;
            pendingNewPin = null;
            inputLabel.Text = "";
            UpdateDisplay("CARD ENTRY\r\nEnter card number");
            ShowMessage("Enter 16-digit card number, then press Enter/Proceed", Color.Blue);
            EnableNumberPad(true);
            HideTransactionButtons();
        }

        private void ShowMessage(string message, Color color)
        {
            messageLabel.Text = message;
            messageLabel.ForeColor = color;
        }

        private void UpdateDisplay(string text)
        {
            displayLabel.Text = text;
        }

        private void EnableNumberPad(bool enable)
        {
            foreach (var btn in numberButtons)
            {
                btn.Enabled = enable;
            }
            enterBtn.Enabled = enable;
            clearBtn.Enabled = enable;
        }

        private void HideTransactionButtons()
        {
            withdrawBtn.Visible = false;
            depositBtn.Visible = false;
            balanceBtn.Visible = false;
            changePinBtn.Visible = false;
            logoutBtn.Visible = false;
        }

        private void ShowTransactionButtons()
        {
            withdrawBtn.Visible = true;
            depositBtn.Visible = true;
            balanceBtn.Visible = true;
            changePinBtn.Visible = true;
            logoutBtn.Visible = true;
        }

        private void ProcessInput()
        {
            string rawInput = inputLabel.Text.Trim();
            string input = FilterInputForState(rawInput);
            if (!string.Equals(rawInput, input, StringComparison.Ordinal))
            {
                inputLabel.Text = input;
            }

            switch (currentState)
            {
                case ATMState.CardEntry:
                    if (input.Length == 16 && input.All(char.IsDigit))
                    {
                        if (!atm.IsRegisteredCard(input))
                        {
                            MessageBox.Show(this, "Card number is not registered.", "Card Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            inputLabel.Text = "";
                            ShowMessage("Unregistered card", Color.Red);
                            RenderCurrentScreenPreview();
                            break;
                        }

                        enteredCardNumber = input;
                        currentState = ATMState.PasswordEntry;
                        UpdateDisplay($"CARD: {MaskCardNumber(input)}\r\nEnter password (PIN)");
                        inputLabel.Text = "";
                        ShowMessage("Card accepted. Enter password (PIN)", Color.Green);
                    }
                    else
                    {
                        ShowMessage("Invalid card number (16 digits required)", Color.Red);
                        inputLabel.Text = "";
                    }
                    break;

                case ATMState.PasswordEntry:
                    if (input.Length >= 4)
                    {
                        if (!string.IsNullOrWhiteSpace(enteredCardNumber) && atm.AuthenticateCard(enteredCardNumber, input))
                        {
                            currentState = ATMState.Dashboard;
                            var account = atm.GetCurrentAccount();
                            UpdateDisplay($"DASHBOARD\r\nWelcome {account.CardholderName}\r\nBalance: ${account.Balance:F2}");
                            inputLabel.Text = "";
                            EnableNumberPad(false);
                            ShowTransactionButtons();
                            ShowMessage("Logged in successfully", Color.Green);
                        }
                        else
                        {
                            MessageBox.Show(this, "Incorrect PIN. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            inputLabel.Text = "";
                            ShowMessage("Invalid PIN. Try again", Color.Red);
                            RenderCurrentScreenPreview();
                        }
                    }
                    else
                    {
                        ShowMessage("Password (PIN) must be at least 4 digits", Color.Red);
                        inputLabel.Text = "";
                    }
                    break;

                case ATMState.EnteringWithdrawAmount:
                    if (decimal.TryParse(input, out decimal withdrawAmount))
                    {
                        if (withdrawAmount > 0)
                        {
                            if (atm.Withdraw(withdrawAmount))
                            {
                                currentState = ATMState.Dashboard;
                                var account = atm.GetCurrentAccount();
                                UpdateDisplay($"Withdrawal Successful!\r\nAmount: ${withdrawAmount:F2}\r\nNew Balance: ${account.Balance:F2}");
                                inputLabel.Text = "";
                                ShowMessage("Withdrawal completed", Color.Green);
                                EnableNumberPad(false);
                                ShowTransactionButtons();
                            }
                            else
                            {
                                currentState = ATMState.Dashboard;
                                UpdateDisplay($"Insufficient funds\r\nYour Balance: ${atm.GetBalance():F2}");
                                inputLabel.Text = "";
                                ShowMessage("Cannot withdraw. Insufficient funds", Color.Red);
                                EnableNumberPad(false);
                                ShowTransactionButtons();
                            }
                        }
                        else
                        {
                            ShowMessage("Amount must be greater than 0", Color.Red);
                            inputLabel.Text = "";
                        }
                    }
                    else
                    {
                        ShowMessage("Invalid amount", Color.Red);
                        inputLabel.Text = "";
                    }
                    break;
                case ATMState.EnteringDepositAmount:
                    if (decimal.TryParse(input, out decimal depositAmount))
                    {
                        if (depositAmount > 0)
                        {
                            atm.Deposit(depositAmount);
                            currentState = ATMState.Dashboard;
                            var account = atm.GetCurrentAccount();
                            UpdateDisplay($"Deposit Successful!\r\nAmount: ${depositAmount:F2}\r\nNew Balance: ${account.Balance:F2}");
                            inputLabel.Text = "";
                            ShowMessage("Deposit completed", Color.Green);
                            EnableNumberPad(false);
                            ShowTransactionButtons();
                        }
                        else
                        {
                            ShowMessage("Amount must be greater than 0", Color.Red);
                            inputLabel.Text = "";
                        }
                    }
                    else
                    {
                        ShowMessage("Invalid amount", Color.Red);
                        inputLabel.Text = "";
                    }
                    break;

                case ATMState.EnteringOldPin:
                    if (input.Length >= 4)
                    {
                        pendingOldPin = input;
                        currentState = ATMState.EnteringNewPin;
                        UpdateDisplay("Enter new PIN");
                        inputLabel.Text = "";
                        ShowMessage("Enter new PIN", Color.Blue);
                    }
                    else
                    {
                        ShowMessage("PIN must be at least 4 digits", Color.Red);
                        inputLabel.Text = "";
                    }
                    break;

                case ATMState.EnteringNewPin:
                    if (input.Length >= 4)
                    {
                        pendingNewPin = input;
                        currentState = ATMState.EnteringNewPinConfirm;
                        UpdateDisplay("Confirm new PIN");
                        inputLabel.Text = "";
                        ShowMessage("Confirm new PIN", Color.Blue);
                    }
                    else
                    {
                        ShowMessage("PIN must be at least 4 digits", Color.Red);
                        inputLabel.Text = "";
                    }
                    break;

                case ATMState.EnteringNewPinConfirm:
                    if (input.Length >= 4)
                    {
                        if (pendingNewPin != input)
                        {
                            currentState = ATMState.EnteringNewPin;
                            UpdateDisplay("PINs did not match\r\nEnter new PIN");
                            inputLabel.Text = "";
                            ShowMessage("PINs did not match. Try again", Color.Red);
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(pendingOldPin) || string.IsNullOrWhiteSpace(pendingNewPin))
                        {
                            currentState = ATMState.Dashboard;
                            EnableNumberPad(false);
                            ShowTransactionButtons();
                            ShowMessage("PIN change cancelled", Color.Red);
                            break;
                        }

                        if (atm.ChangePin(pendingOldPin, pendingNewPin))
                        {
                            currentState = ATMState.Dashboard;
                            UpdateDisplay("PIN Changed!\r\nReturning to menu...");
                            inputLabel.Text = "";
                            ShowMessage("PIN changed successfully", Color.Green);
                        }
                        else
                        {
                            currentState = ATMState.Dashboard;
                            UpdateDisplay("PIN change failed\r\nReturning to menu...");
                            inputLabel.Text = "";
                            ShowMessage("Current PIN incorrect", Color.Red);
                        }

                        pendingOldPin = null;
                        pendingNewPin = null;
                        EnableNumberPad(false);
                        ShowTransactionButtons();
                    }
                    else
                    {
                        ShowMessage("PIN must be at least 4 digits", Color.Red);
                        inputLabel.Text = "";
                    }
                    break;
            }
        }

        private string MaskCardNumber(string cardNumber)
        {
            return "****-****-****-" + cardNumber.Substring(12);
        }

        private void WithdrawBtn_Click(object? sender, EventArgs e)
        {
            currentState = ATMState.EnteringWithdrawAmount;
            UpdateDisplay("Enter amount to withdraw");
            inputLabel.Text = "";
            EnableNumberPad(true);
            HideTransactionButtons();
            ShowMessage("Enter withdrawal amount", Color.Blue);
        }

        private void DepositBtn_Click(object? sender, EventArgs e)
        {
            currentState = ATMState.EnteringDepositAmount;
            UpdateDisplay("Enter amount to deposit");
            inputLabel.Text = "";
            EnableNumberPad(true);
            ShowTransactionButtons();
            ShowMessage("Enter deposit amount", Color.Blue);
        }

        private void BalanceBtn_Click(object? sender, EventArgs e)
        {
            var account = atm.GetCurrentAccount();
            UpdateDisplay($"Account Balance\r\n${account.Balance:F2}");
            ShowMessage("Balance checked", Color.Green);
        }

        private void ChangePinBtn_Click(object? sender, EventArgs e)
        {
            currentState = ATMState.EnteringOldPin;
            UpdateDisplay("Enter current PIN");
            inputLabel.Text = "";
            EnableNumberPad(true);
            HideTransactionButtons();
            ShowMessage("Enter your current PIN", Color.Blue);
        }

        private void LogoutBtn_Click(object? sender, EventArgs e)
        {
            atm.Logout();
            ShowMessage("Logged out successfully", Color.Green);
            UpdateWelcomeState();
        }
    }
}

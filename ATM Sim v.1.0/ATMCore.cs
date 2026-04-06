namespace ATM_Sim_v._1._0
{
    public class ATMCore
    {
        private List<Account> accounts = new();
        private Account? currentAccount;

        public ATMCore()
        {
            InitializeAccounts();
        }

        private void InitializeAccounts()
        {
            accounts.Add(new Account("1234567890123456", "1234", "John Doe", 5000m));
            accounts.Add(new Account("9876543210987654", "5678", "Jane Smith", 3500m));
            accounts.Add(new Account("5555666677778888", "9999", "Bob Johnson", 7200m));
        }

        public bool AuthenticateCard(string cardNumber, string pin)
        {
            var account = accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
            if (account != null && account.PIN == pin)
            {
                currentAccount = account;
                return true;
            }
            return false;
        }

        public bool IsRegisteredCard(string cardNumber)
        {
            return accounts.Any(a => a.CardNumber == cardNumber);
        }

        public Account? GetCurrentAccount()
        {
            return currentAccount;
        }

        public void Logout()
        {
            currentAccount = null;
        }

        public bool Withdraw(decimal amount)
        {
            if (currentAccount == null)
                return false;

            if (amount <= 0)
                return false;

            if (currentAccount.Balance >= amount)
            {
                currentAccount.Balance -= amount;
                return true;
            }
            return false;
        }

        public bool Deposit(decimal amount)
        {
            if (currentAccount == null)
                return false;

            if (amount <= 0)
                return false;

            currentAccount.Balance += amount;
            return true;
        }

        public decimal GetBalance()
        {
            return currentAccount?.Balance ?? 0m;
        }

        public bool ChangePin(string oldPin, string newPin)
        {
            if (currentAccount == null)
                return false;

            if (currentAccount.PIN == oldPin)
            {
                currentAccount.PIN = newPin;
                return true;
            }
            return false;
        }
    }
}

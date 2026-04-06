namespace ATM_Sim_v._1._0
{
    public class Account
    {
        public string CardNumber { get; set; }
        public string PIN { get; set; }
        public string CardholderName { get; set; }
        public decimal Balance { get; set; }

        public Account(string cardNumber, string pin, string name, decimal balance)
        {
            CardNumber = cardNumber;
            PIN = pin;
            CardholderName = name;
            Balance = balance;
        }
    }
}

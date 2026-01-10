namespace DAY_3_BANK
{
    public class BankAccount
    {
        private string accountPIN;
        public string accountNumber;
        protected internal decimal interestRate;
        internal string bankBranchCode;
        protected decimal balance;

        public BankAccount(string acc, string pin, decimal interest, string branch)
        {
            accountNumber = acc;
            accountPIN = pin;
            interestRate = interest;
            bankBranchCode = branch;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
}

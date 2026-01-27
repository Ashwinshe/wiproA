namespace DAY_3_BANK
{
    public class SavingAccount : BankAccount
    {
        public SavingAccount(string acc, string pin, decimal interest, string branch)
            : base(acc, pin, interest, branch)
        {
        }

        public decimal CalculateInterest()
        {
            return balance * interestRate / 100;
        }
    }
}

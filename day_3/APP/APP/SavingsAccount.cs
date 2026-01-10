namespace APP
{
    class SavingsAccount : Account
    {
        public double InterestRate;

        public void ShowInterest()
        {
            double interest = Balance * InterestRate / 100;
            Console.WriteLine("Interest: " + interest);
        }
    }
}

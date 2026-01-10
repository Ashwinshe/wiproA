namespace APP
{
    class Account
    {
        public int AccountNumber;
        public string HolderName;
        public double Balance;

        public void Display()
        {
            Console.WriteLine("Account No: " + AccountNumber);
            Console.WriteLine("Holder Name: " + HolderName);
            Console.WriteLine("Balance: " + Balance);
        }
    }
}

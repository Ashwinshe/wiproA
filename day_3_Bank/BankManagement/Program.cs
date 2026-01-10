using DAY_3_BANK;

var sa = new SavingAccount("SA101", "1234", 5.5m, "PUNE01");

sa.Deposit(10000);
var interest = sa.CalculateInterest();

Console.WriteLine("Savings Account: " + sa.accountNumber);
Console.WriteLine("Interest Earned: " + interest);
Console.WriteLine("Final Balance: " + (sa.GetBalance() + interest));

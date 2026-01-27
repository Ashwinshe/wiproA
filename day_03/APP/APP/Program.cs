using System;
using APP;

SavingsAccount acc = new SavingsAccount();

acc.AccountNumber = 101;
acc.HolderName = "Ashwin";
acc.Balance = 50000;
acc.InterestRate = 5;

acc.Display();        // from Account class
acc.ShowInterest();  // from SavingsAccount

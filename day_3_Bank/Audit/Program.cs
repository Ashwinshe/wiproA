using System;
using DAY_3_BANK;

namespace Audit
{
    class Program
    {
        static void Main()
        {
            AuditAccount audit = new AuditAccount("SA201", "4321", 5.5m, "PUNE01");

            audit.Deposit(10000);
            audit.Withdraw(2000);

            Console.WriteLine("Account: " + audit.accountNumber);
            Console.WriteLine("Balance: " + audit.GetBalance());
        }
    }
}

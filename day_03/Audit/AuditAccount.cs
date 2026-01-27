using System;
using DAY_3_BANK;

namespace Audit
{
    public class AuditAccount : SavingAccount
    {
        public string AuditorName = "Internal Audit";

        public AuditAccount(string acc, string pin, decimal interest, string branch)
            : base(acc, pin, interest, branch)
        {
        }

        public override bool Withdraw(decimal amount)
        {
            Console.WriteLine("Audit check before withdrawal...");
            return base.Withdraw(amount);
        }
    }
}

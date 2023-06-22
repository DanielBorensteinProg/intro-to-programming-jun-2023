using System.Runtime.CompilerServices;

namespace Banking.Domain;

public class GoldAccount: Account
{
    
        public override void Deposit(decimal amountToDeposit)
        {
        base.Deposit(amountToDeposit * 1.10M);
    
        }
}
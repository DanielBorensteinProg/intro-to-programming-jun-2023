namespace Banking.Domain;

public class StandardBonusCalculator : ICanCalculateBonuses
{

    public decimal CalculateBonusForDepositOn(decimal balance, decimal amountOfDeposit)
    {
        if(balance > 4000M)
        {
            return amountOfDeposit * .10M;

        } else
        {
            return 0;
        }
    }
}
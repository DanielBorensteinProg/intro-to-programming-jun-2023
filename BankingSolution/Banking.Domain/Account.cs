namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000; // Fields class level variable
    private ICanCalculateBonuses _bonusCalculator;

    public Account(ICanCalculateBonuses bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public void Deposit(decimal amountToDeposit)
    {
        
        
        decimal bonus = _bonusCalculator.CalculateBonusForDepositOn(_balance, amountToDeposit);

        _balance += amountToDeposit + bonus;
    }

   

    public decimal GetBalance()
    {
        return _balance; // "Sliming"
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if(amountToWithdraw > _balance)
        {
            throw new OverdraftException();
        }
       _balance -= amountToWithdraw;
    }
}
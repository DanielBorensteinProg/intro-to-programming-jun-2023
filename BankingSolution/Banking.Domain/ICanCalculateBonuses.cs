namespace Banking.Domain;

public interface ICanCalculateBonuses
{
    decimal CalculateBonusForDepositOn(decimal balance, decimal amountToDeposit);
}
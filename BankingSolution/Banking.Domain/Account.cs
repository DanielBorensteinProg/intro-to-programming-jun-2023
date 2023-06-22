namespace Banking.Domain
{
    public enum LoyaltyLevel { Standard, Gold }
    public class Account
    {
        private decimal _balance = 5000; // Fields class level variable
        public LoyaltyLevel AccountType { get; set; } = LoyaltyLevel.Standard;
        public void Deposit(decimal amountToDeposit)
        {

            if (AccountType == LoyaltyLevel.Gold)
            {
                _balance += amountToDeposit * 1.10M;
            }
            else
            {
                _balance += amountToDeposit;
            }

        }

        public void Withdrawal(decimal amountToWithdrawal)
        {
            if (amountToWithdrawal > _balance)
            {
                throw new OverdraftException();
            }
            _balance -= amountToWithdrawal;
        }

        public decimal GetBalance()
        {
            return _balance;
        }
    }
}
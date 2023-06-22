namespace Banking.Domain
{
    public class Account
    {
        private decimal _balance = 5000M;
        public virtual void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
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
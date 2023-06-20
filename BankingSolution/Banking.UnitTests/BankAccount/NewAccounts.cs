using Banking.Domain;

namespace Banking.UnitTests.BankAccount
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            Account account = new Account();

            decimal balance = account.GetBalance();

            Assert.Equal(5000M, balance);
        }
    }
}

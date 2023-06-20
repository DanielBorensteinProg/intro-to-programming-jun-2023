namespace Banking.UnitTests.BankAccount;

public class WithdrawalGuards
{
    [Fact]
    public void OverdraftNotAllowed()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdrawal(openingBalance + .01M);

        Assert.Equal(openingBalance, account.GetBalance());
    }
}

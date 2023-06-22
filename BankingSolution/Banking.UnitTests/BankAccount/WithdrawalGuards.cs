using Banking.Domain;

namespace Banking.UnitTests.BankAccount;

public class WithdrawalGuards
{
    [Fact]
    public void OverdraftNotAllowed()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        try
        {
            account.Withdrawal(openingBalance + .01M);
        }
        catch (OverdraftException)
        {

            //ignore any exceptions
        }

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void OVerdraftThrowsException()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        Assert.Throws<OverdraftException>(
            () => account.Withdrawal(openingBalance + .01M));
    }
}

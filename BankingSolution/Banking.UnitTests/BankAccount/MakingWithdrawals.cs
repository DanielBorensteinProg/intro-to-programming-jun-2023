
namespace Banking.UnitTests.BankAccount;

public class MakingWithdrawals
{
    [Fact]
    public static void MakingAWithdrawalDecreasesTheBalance()
    {
        // Given 
        // If I have an account and I want to deposit 100
        Account account = new Account();
        decimal openingBalance = account.GetBalance(); // Query
        decimal amountToWithdrawal = 100M;



        // When - I do the deposit
        account.Withdrawal(amountToWithdrawal); // "Command"



        // Then - I can verify it worked if the new balance is 100 more than the balance
        //        was before.
        Assert.Equal(openingBalance - amountToWithdrawal, account.GetBalance());
    }

    [Fact]
    public void CanTakeFullBalance()
    {
        // Given 
        // If I have an account and I want to deposit 100
        Account account = new Account();
        decimal openingBalance = account.GetBalance(); // Query
        decimal amountToWithdrawal = openingBalance;



        // When - I do the deposit
        account.Withdrawal(amountToWithdrawal); // "Command"



        // Then - I can verify it worked if the new balance is 100 more than the balance
        //        was before.
        Assert.Equal(openingBalance - amountToWithdrawal, account.GetBalance());

    }
}

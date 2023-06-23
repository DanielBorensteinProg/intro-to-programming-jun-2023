using Banking.UnitTests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BankAccount;
public class AccountBonusCalculations
{
    [Fact]
    public void DeposisUsesTheBonusCalculator()
    {
        var stubbedBonusCalculator = new Mock<ICanCalculateBonuses>();

        var account = new Account(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();

        stubbedBonusCalculator.Setup(c => c.CalculateBonusForDepositOn(openingBalance, 112)).Returns(42);

        account.Deposit(112);

        Assert.Equal(openingBalance + 112M + 42M, account.GetBalance());
    }
}

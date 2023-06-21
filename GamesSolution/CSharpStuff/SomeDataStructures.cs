

namespace CSharpStuff;
public class SomeDataStructures
{
    [Fact]
    public void Classes()
    {
        var myAccount = new BankAccount("bob@aol.com");

        Assert.Equal(5000M, myAccount.GetBalance());

        var yourAccount = myAccount;
        Assert.Equal(5000M, yourAccount.GetBalance());

        myAccount.Deposit(100M);

        Assert.Equal(5100M, myAccount.GetBalance());
        Assert.Equal(5100M, yourAccount.Balance);

       

    }

    [Fact]
    public void ClassesHaveSomeDataAttachedToThem()
    {
        var myAccount = new BankAccount("jeff@hypertheory.com");
        //myAccount.Email = "jeff@hypertheory.com";

        Assert.Equal("jeff@hypertheory.com", myAccount.Email);

        myAccount.PhoneNumber = "867-5309";
        Assert.Equal("867-5309", myAccount.PhoneNumber);
    }

    [Fact]
    public void Records()
    {
        var fullName = Utilities.FormatName("Han", "Solo");

        Assert.Equal("Solo, Han", fullName.FullName);
        Assert.Equal(9, fullName.NumberOfLetters);

        //fullName.FullName = "Skywalker, Luke";

        var n1 = new FormattedName
        {
            FullName = "Jeff",
            NumberOfLetters = 4
        };

        var n2 = new FormattedName
        {
            FullName = "Jeff",
            NumberOfLetters = 4
        };

        //var isEqual = n1 == n2;

        Assert.Equal(n1, n2);

    }

    [Fact]
    public void Tuples()
    {

    }

    [Fact]
    public void Structs()
    {

    }
}

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeter.UnitTests;
public class GreetingTests
{
    private readonly GreetingMaker _greetingMaker;
    private readonly Mock<IFindBadNames> _findBadNames;
    
    public GreetingTests()
    {
        _findBadNames = new Mock<IFindBadNames>();
        _greetingMaker = new GreetingMaker(_findBadNames.Object);
    }

    [Theory]
    [InlineData("Windom", "Hello, Windom!")]
    [InlineData("Cooper", "Hello, Cooper!")]
    public void SingleName(string name, string expected)
    {
        

        string greeting = _greetingMaker.Greet(name);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData(null, "Hello, Daniel!")]
    public void NullName(string name, string expected)
    {

        string greeting = _greetingMaker.Greet(name);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("BOB", "HELLO, BOB!")]
    [InlineData("JEFF", "HELLO, JEFF!")]
    public void ExcitedName(string name, string expected)
    {


        string greeting = _greetingMaker.Greet(name);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("Bob", "Sue", "Hello, Bob and Sue!")]
    public void TwoNames(string name1,string name2, string expected)
    {

        string greeting = _greetingMaker.Greet(name1, name2);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("Hello, Bob, Sue, and Jeff!", "Bob", "Sue","Jeff")]
    [InlineData("Hello, Cole, Cooper, Rosenfield, Preston, Milford, and Jeffries!", "Cole", "Cooper", "Rosenfield", "Preston", "Milford", "Jeffries")]
    public void MultipleNames(string expected, string name, params string[] moreNames)
    {

        string greeting = _greetingMaker.Greet(name, moreNames);

        Assert.Equal(expected, greeting);
    }


    [Theory]
    [InlineData("Hello, Bob, Jim, AND SUE!", "Bob", "SUE","Jim" )]
    [InlineData("HELLO, COLE, COOPER, ROSENFIELD, PRESTON, MILFORD, AND JEFFRIES!", "COLE", "COOPER", "ROSENFIELD", "PRESTON", "MILFORD", "JEFFRIES")]
    public void MixedShouting(string expected, string name, params string[] moreNames)
    {

        string greeting = _greetingMaker.Greet(name, moreNames);

        Assert.Equal(expected, greeting);
    }


    [Theory]
    [InlineData("Hello, Bob, Mike, and Karl!", "Bob", "Mike, Karl")]
    [InlineData("HELLO, COLE, COOPER, ROSENFIELD, PRESTON, MILFORD, AND JEFFRIES!", "COLE", "COOPER", "ROSENFIELD", "PRESTON", "MILFORD", "JEFFRIES")]
    public void SplitComma(string expected, string name, params string[] moreNames)
    {


        string greeting = _greetingMaker.Greet(name, moreNames);

        Assert.Equal(expected, greeting);
    }


    [Theory]
    [InlineData("Hello, Same, Carl, J****n, Bill, and B***y!", "Sam", "Carl", "Jayden", "Bill", "Buffy")]
    public void BadNames(string expected, string name, params string[] moreNames)
    {


        string greeting = _greetingMaker.Greet(name, moreNames);

        Assert.Equal(expected, greeting);
    }


}

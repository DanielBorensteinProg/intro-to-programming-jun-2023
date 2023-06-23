
using Moq;

namespace StringCalculator;

public class StringCalculatorTests
{
    private readonly StringCalculator _calculator;

    public StringCalculatorTests()
    {
        this._calculator = new StringCalculator(new Mock<ILogger>().Object, new Mock<IWebService>().Object);
    }

    [Fact]
    public void EmptyStringReturnsZero()
    {
        var result = _calculator.Add("");
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("188", 188)]
    public void SingleDigit(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("8,2", 10)]
    [InlineData("10,5", 15)]
    [InlineData("999,100", 1099)]
    public void TwoDigits(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9,100", 145)]
    public void Arbitrary(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1\n2\n3", 6)]

    public void NewLines(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }
}

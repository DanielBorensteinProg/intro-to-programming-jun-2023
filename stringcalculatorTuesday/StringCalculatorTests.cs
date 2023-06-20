namespace StringCalculator;



public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();



        var result = calculator.Add("");



        Assert.Equal(0, result);
    }



    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("50", 50)]
    public void SingleDigit(string numbers, int expected)
    {
        var calculator = new StringCalculator();



        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3", 6)]
    [InlineData("0,1,2,3,4", 10)]
    public void MultipleDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();



        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    public void MultipleDigitsNewDelimeter(string numbers, int expected)
    {
        var calculator = new StringCalculator();



        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    public void MultipleDigitsDifferentDelimeter(string numbers, int expected)
    {
        var calculator = new StringCalculator();



        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

}
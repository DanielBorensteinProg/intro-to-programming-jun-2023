
using Moq;

namespace StringCalculator;
public class StringCalculator2Tests
{
    private readonly StringCalculator _calculator;
    private readonly Mock<ILogger> _loggerMock;
    private readonly Mock<IWebService> _webServiceMock;
    public StringCalculator2Tests()
    {
        _loggerMock =  new Mock<ILogger>();
        _webServiceMock = new Mock<IWebService>();
        _calculator = new StringCalculator(_loggerMock.Object, _webServiceMock.Object);
    }
    [Theory]
    [InlineData("123")]
    [InlineData("1,2")]
    public void LogsToALogger(string numbers)
    {
        //When
        var answer = _calculator.Add(numbers);
        // Then I want to make sure the logger got called.
        _loggerMock.Verify(m => m.Write(answer.ToString()));
        
    }

    [Fact]
    public void WhenLoggerThrowsTheWebServiceIsCalled()
    {
        _loggerMock.Setup(m => m.Write(It.IsAny<string>())).Throws(new Exception());
        
        _calculator.Add("99");
        // It should call the web service with a message.

        // Verify that the web service was called with a message.
        _webServiceMock.Verify(m => m.Notify("Error writing to logger"), Times.Once);

    }

    [Fact]
    public void IfThereIsNoExceptionTheWebServiceIsNotNotified()
    {
        

        _calculator.Add("99");
        // It should call the web service with a message.

        // Verify that the web service was called with a message.
        _webServiceMock.Verify(m => m.Notify(It.IsAny<string>()), Times.Never);
    }
}

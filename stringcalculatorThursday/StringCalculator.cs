
namespace StringCalculator;

public class StringCalculator
{

    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {
        int result = 0;

        if (numbers == "") { result = 0; }
        else
        {

            result = numbers.Split(',', '\n').Select(int.Parse).Sum();
        }
        try
        {
            _logger.Write(result.ToString());
        }
        catch (Exception)
        {
            _webService.Notify("Error writing to logger");
           

        }
        return result;
    }
}

public interface ILogger
{
    void Write(string message);
}

public interface IWebService
{
    void Notify(string message);
}
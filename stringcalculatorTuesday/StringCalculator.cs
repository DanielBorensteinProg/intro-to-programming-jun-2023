namespace StringCalculator;



public class StringCalculator
{



    public int Add(string numbers)
    {
        if (numbers.Length >= 6)
        {
            if (numbers[0] == '/' && numbers[1] == '/'){
                numbers.Replace(numbers[2].ToString(), ",");
                numbers = numbers.Substring(5);
                Console.WriteLine(numbers);
            }

        }
        numbers = numbers.Replace("\n", ",");
        if (numbers == "")
        {
            return 0;
        }
        else
        {
            return StringOfNumbersToList(numbers).Sum();
        }
    }

    private List<int> StringOfNumbersToList(string stringOfNumbers)
    {
        List<int> numbersList = new List<int>();
        string[] numbersArray = stringOfNumbers.Split(',');
        foreach (string number in numbersArray)
        {
            numbersList.Add(int.Parse(number));
        }
        return numbersList;
    }
}
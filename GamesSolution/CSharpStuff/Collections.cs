
namespace CSharpStuff;
public class Collections
{
    [Fact]
    public void ListsOfThings()
    {
        // Generic - "Parametric Polymorphism" - 
        var luckyNumbers = new List<int>();
        luckyNumbers.Add(9);
        luckyNumbers.Add(20);

        Assert.Equal(9, luckyNumbers[0]);
        Assert.Equal(20, luckyNumbers[1]);

        //bool wasThrown = false;

        //try
        //{
        //    Assert.Equal(99, luckyNumbers[2]);
        //}
        //catch (ArgumentOutOfRangeException)
        //{

        //    wasThrown = true;
        //}

        //Assert.True(wasThrown);

        Assert.Throws<ArgumentOutOfRangeException>(() => luckyNumbers[2]);
    }

    [Fact]
    public void EnumeratingAList()
    {
        var luckyNumbers = new List<int>() {  9, 20 };
      

        int total = 0;

        foreach(int currentNumber in luckyNumbers)
        {
            total += currentNumber;
        }
        Assert.Equal(29, total);

        
    }

    [Fact]
    public void Dictionary()
    {
        var scores = new Dictionary<string, int>()
        {
            { "Jim", 220 },
            { "Sue", 300 }
        }; // Initializer

        //scores.Add("Jim", 220);
        //scores.Add("Sue", 300);

        Assert.Equal(220, scores["Jim"]);

        Assert.Throws<ArgumentException>(() => scores.Add("Jim", 300));

        scores["Jim"] = 300;

        Assert.Equal(300, scores["Jim"]);

        Assert.True(scores.ContainsKey("Jim"));
        Assert.False(scores.ContainsKey("Barb"));

        foreach(string name in scores.Keys)
        {
            // the names would be Jim, then Sue
        }

        foreach(int score in scores.Values)
        {
            // 22, 300
        }

        foreach(var pair in scores)
        {
           
        }

        Assert.Equal(2, scores.Count);

    }
}

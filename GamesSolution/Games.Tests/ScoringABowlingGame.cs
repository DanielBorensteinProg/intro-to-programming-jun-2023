

namespace Games.Tests;
public class ScoringABowlingGame
{

    private readonly List<Player> _expectedWinners;
    private readonly List<Player> _expectedLosers;
    private readonly ScoreReport _report;

    public ScoringABowlingGame()
    {
        // Given 
        var game = new BowlingGame();
        var p1 = new Player("Jeff", 212);
        var p2 = new Player("Stacey", 287);
        game.AddPlayer(p1.Name, p1.score);
        game.AddPlayer(p2.Name, p2.score);

         _expectedWinners = new List<Player> { p2 };
         _expectedLosers = new List<Player>() { p1 };

        var scorer = new GameScorer();

        // When I ask for the score
        _report = scorer.GenerateScoreReportFor(game);
    }

    [Fact]
    public void HasCorrectWinners()
    {
        Assert.Equal(_expectedWinners, _report.Winners);
        
    }

    [Fact]
    public void HasCorrectLosers()
    {
        Assert.Equal(_expectedLosers, _report.Losers);
    }

    [Fact]
    public void HasCorrectAverage()
    {
        Assert.Equal(249.5, _report.Average);
    }

}

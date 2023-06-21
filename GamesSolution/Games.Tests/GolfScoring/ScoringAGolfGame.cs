using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Tests.GolfScoring;

public class ScoringAGolfGame
{

    private readonly List<Player> _expectedWinners;
    private readonly List<Player> _expectedLosers;
    private readonly ScoreReport _report;

    public ScoringAGolfGame()
    {
        // Given 
        var game = new GolfGame();
        var p1 = new Player("Jeff", 98);
        var p2 = new Player("Stacey", 52);
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
        Assert.Equal(75, _report.Average);
    }

}

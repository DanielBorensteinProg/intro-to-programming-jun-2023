namespace Games.Tests;
public class ScoringAnInvalidGame
{
    [Fact]
    public void GamesMustHaveAtLeastTwoPlayers()
    {
        var game = new BowlingGame();
        game.AddPlayer("Jeff", 99);



        var scorer = new GameScorer();



        Assert.Throws<InvalidGameException>(() => scorer.GenerateScoreReportFor(game));




    }
}
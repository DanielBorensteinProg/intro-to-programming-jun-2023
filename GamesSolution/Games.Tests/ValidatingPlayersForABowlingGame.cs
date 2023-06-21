

namespace Games.Tests;
public class ValidatingPlayersForABowlingGame
{
    [Fact]
    public void DuplicateNamesAreNotAllowed()
    {

        // Given
        var game = new BowlingGame();

      
        game.AddPlayer("Jim", 120);
        game.AddPlayer("Sue", 200);


        // Then / When
        Assert.Throws<PlayerAlreadyAddedToGameException>(() => game.AddPlayer(" jim ", 200));

       
        
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(301)]
    public void InvalidScoresThrowAnException(int invalidScore)
    {
        var game = new BowlingGame();

        Assert.Throws<InvalidBowlingScoreException>(() =>
            game.AddPlayer("Jim", invalidScore)
        );

    }
}

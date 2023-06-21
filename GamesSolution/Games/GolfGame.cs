namespace Games;

public class GolfGame : Game
{
    protected override void GuardForValidScore(int score)
    {
        if(score < 0) { throw new InvalidGolfScoreException(); }
    }
}
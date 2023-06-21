namespace Games;

public abstract class InvalidGameScoreException : ArgumentOutOfRangeException { }
public class InvalidBowlingScoreException : InvalidGameScoreException
{
}

public class InvalidGolfScoreException : InvalidGameScoreException { }
namespace Games;

public class BowlingGame
{
    // "Primitive Obsession"
    private readonly List<Player> _players = new(); // intention revealing than Dictionary<string, int>
    
    public void AddPlayer(string name, int score)
    {
        GuardForValidScore(score);
        GuardForPlayerAlreadyExisting(name);

        _players.Add(new Player(name, score));


    }

    private void GuardForPlayerAlreadyExisting(string name)
    {
        if (PlayerExists(name))
        {
            throw new PlayerAlreadyAddedToGameException();
        }
    }

    private static void GuardForValidScore(int score)
    {
        if (score < 0 || score > 300) { throw new InvalidBowlingScoreException(); }
    }

    private bool PlayerExists(string name)
    {
        return _players.Any(p => p.Name.Trim().ToLowerInvariant() == name.Trim().ToLowerInvariant());
    }

    internal List<Player> GetPlayers()
    {
        return _players;
    }
  
}

public record Player(string Name, int score);
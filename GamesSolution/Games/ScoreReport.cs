namespace Games;

public record ScoreReport
{
    public required List<Player> Winners { get; init; } = new();
    public required List<Player> Losers { get; init; } 
    public required double Average { get; init; }

    public string Message { get; init; } = string.Empty;
}
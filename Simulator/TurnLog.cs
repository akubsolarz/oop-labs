namespace Simulator;

public class TurnLog
{
    /// <summary>
    /// Text representation of moving object in this turn.
    /// CurrentMappable.ToString()
    /// </summary>
    public required string Mappable { get; init; }

    /// <summary>
    /// Text representation of move in this turn.
    /// CurrentMoveName
    /// </summary>
    public required string Move { get; init; }

    /// <summary>
    /// Dictionary of symbols on the map in this turn.
    /// Stored ONLY for occupied cells to save space.
    /// If many objects on one cell => 'X'.
    /// </summary>
    public required Dictionary<Point, char> Symbols { get; init; }
}
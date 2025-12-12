namespace Simulator.Maps;

public interface Imapable
{
    Point Position { get; }
    Map? Map { get; }
    char MapSymbol { get; }

    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point startingPosition);
}

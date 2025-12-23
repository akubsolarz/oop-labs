using Simulator.Maps;

namespace Simulator;

public class Animals : Imapable
{
    protected Map? _map;
    protected Point _point;

    private string _description = "Unknown";
    public string Description
    {
        get => _description;
        set => _description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    
    public Point Position => _point;
    public Map? Map => _map;

    
    public virtual char MapSymbol => 'A';

    public void InitMapAndPosition(Map map, Point startingPosition)
    {
        if (!map.Exist(startingPosition))
            throw new ArgumentOutOfRangeException(nameof(startingPosition));

        _map = map;
        _point = startingPosition;
        map.Add(this, startingPosition);
    }

    
    public void Go(Direction direction)
    {
        if (_map == null) return;

        Point from = _point;
        Point to = NextPosition(direction);

        _map.Move(this, from, to);
        _point = to;
    }

    // domyślny ruch 1 pole
    protected virtual Point NextPosition(Direction direction)
    {
        return _map!.Next(_point, direction);
    }

    public override string ToString()
        => $"{GetType().Name.ToUpper()}: {Info}";
}
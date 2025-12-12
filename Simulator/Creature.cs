using Simulator.Maps;

namespace Simulator;

public abstract class Creature : Imapable
{
    private Map? _map;

    private Point _point;

    public Point Position => _point;
    public Map? Map => _map;

    private string _name = "Unknown";
    private int _level = 1;
    public string Name
    {
        get => _name;
        set => _name = Validator.Shortener(value, 3, 25, '#');
    }
    public int Level
    {
        get => _level;
        set => _level = Validator.Limiter(value, 1, 10);

    }

    public void InitMapAndPosition(Map map, Point startingPosition)
    {
        if (map == null)
            throw new ArgumentNullException(nameof(map));

        if (!map.Exist(startingPosition))
            throw new ArgumentOutOfRangeException(nameof(startingPosition), "point out of map");

        _map = map;
        _point = startingPosition;
        map.Add(this, startingPosition);

    }
    public abstract int Power { get; }


    public Creature(string name)
    {
        Name = name;
        Level = 1;
    }
    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void Upgrade()
    {
        Level++;
    }
    public virtual char MapSymbol => '?';
    public void Go(Direction direction)
    {
        if (_map == null) return;

        Point nextPoint = _map.Next(_point, direction);

        _map.Move(this, _point, nextPoint);
        _point = nextPoint;
    }


    public abstract string Greating();

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Info}";
    }
    public static string Slogan() => "creatures are great !!!";

    public abstract string Info { get; }


}


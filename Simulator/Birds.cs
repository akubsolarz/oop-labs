namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public Birds() { }

    public Birds(string description, uint size, bool canFly = true)
    {
        Description = description;
        Size = size;
        CanFly = canFly;
    }

    public override char MapSymbol => CanFly ? 'B' : 'b';

    public override string Info
    {
        get
        {
            string fly = CanFly ? "fly+" : "fly-";
            return $"{Description} ({fly}) <{Size}>";
        }
    }

    protected override Point NextPosition(Direction direction)
    {
        if (_map == null) return _point;

        if (CanFly)
        {
            // 2 pola w zadanym kierunku
            var step1 = _map.Next(_point, direction);
            var step2 = _map.Next(step1, direction);
            return step2;
        }
        else
        {
            // 1 pole po skosie
            return _map.NextDiagonal(_point, direction);
        }
    }
}
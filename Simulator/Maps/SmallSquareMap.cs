namespace Simulator.Maps;

public class SmallSquareMap : Map
{

    /// <summary>
    /// mala mapa kwadratowa 5-20.
    /// </summary>
    public int Size { get; }

    private readonly Rectangle ractan;


    public SmallSquareMap(int size)
    {

        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar  musi być w przedziale 5-20.");
        Size = size;
        ractan = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    /// <summary>
    /// Sprawdza, czy punkt leży na  mapie.
    /// </summary>
    public override bool Exist(Point p) => ractan.Contains(p);

    /// <summary>
    /// Zwraca kolejny punkt w kierunku d lub zwraca obecny punkt.
    /// </summary>
    public override Point Next(Point p, Direction d)
    {

        var next = p.Next(d);
        return Exist(next) ? next : p;
    }

    /// <summary>
    /// Zwraca następny punkt po skosie lub zwraca obecny punkt.
    /// </summary>
    public override Point NextDiagonal(Point p, Direction d)
    {

        var next = p.NextDiagonal(d);
        return Exist(next) ? next : p;
    }
}
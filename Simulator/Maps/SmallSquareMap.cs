namespace Simulator.Maps;

public class SmallSquareMap : Map
{

    /// <summary>
    /// mala mapa kwadratowa 5-20.
    /// </summary>
    public int Size { get; }

    public SmallSquareMap(int size) : base(size, size)
    {

        if (size > 20)
            throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar  nie może być większy od 20.");
        Size = size;

    }
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
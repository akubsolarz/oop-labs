using Simulator;
using System.Collections.ObjectModel;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Dictionary<Point, List<Creature>> _points = new();
    public readonly int SizeX;
    public readonly int SizeY;
    private readonly Rectangle ractan;

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Rozmiar  musi być większy od 5.");
        if (sizeY < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Rozmiar  musi być większy od 5.");
        SizeX = sizeX;
        SizeY = sizeY;
        ractan = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => ractan.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">p to miejsce na mapie.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    /// <summary>
    /// dokończ
    ///
    /// </summary>
    /// <param name="creature"></param>
    /// <param name="p"></param>
    public void Add(Creature creature, Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p), "Punkt poza mapą.");

        if (!_points.TryGetValue(p, out var list))
        {
            list = new List<Creature>();
            _points[p] = list;
        }
        _points[p].Add(creature);

    }
    /// <summary>
    /// Remove Creature
    /// </summary>
    /// <param name="creature"></param>
    public void Remove(Creature creature, Point p)
    {
        if (_points.TryGetValue(p, out var list))
        {
            list.Remove(creature);
            if (list.Count == 0)
                _points.Remove(p);
        }
    }

    public void Move(Creature creature, Point pointOld, Point pointNew)
    {
        Remove(creature, pointOld);
        Add(creature, pointNew);
    }
    /// <summary>
    /// dokończ
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public List<Creature> At(Point p)
    {
        if (_points.TryGetValue(p, out var list))
            return list;

        return new List<Creature>();
    }

    public List<Creature> At(int x, int y) => At(new Point(x, y));
}

namespace Simulator;

public class Rectangle
{
    public readonly int X1;
    public readonly int Y1;
    public readonly int X2;
    public readonly int Y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        (X1, X2) = (Math.Min(x1, x2), Math.Max(x1, x2));
        (Y1, Y2) = (Math.Min(y1, y2), Math.Max(y1, y2));

        if (X1 == X2 || Y1 == Y2)
            throw new ArgumentException("nie chcemy chudych prostokątów");
    }

    public Rectangle(Point p1, Point p2)
        : this(p1.X, p1.Y, p2.X, p2.Y) { }

    public bool Contains(Point p)
        => p.X >= X1 && p.X <= X2 && p.Y >= Y1 && p.Y <= Y2;

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";
}
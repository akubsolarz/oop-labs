using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Next_Up_IncreasesY()
    {
        var p = new Point(1, 1);
        var n = p.Next(Direction.Up);
        Assert.Equal(new Point(1, 2).ToString(), n.ToString());
    }

    [Fact]
    public void Next_Right_IncreasesX()
    {
        var p = new Point(3, 3);
        var n = p.Next(Direction.Right);
        Assert.Equal(new Point(4, 3).ToString(), n.ToString());
    }

    [Fact]
    public void NextDiagonal_Up_Right()
    {
        var p = new Point(0, 0);
        var n = p.NextDiagonal(Direction.Up);
        Assert.Equal(new Point(1, 1).ToString(), n.ToString());
    }

    [Theory]
    [InlineData(Direction.Right, 1, -1)]
    [InlineData(Direction.Down, -1, -1)]
    [InlineData(Direction.Left, -1, 1)]
    [InlineData(Direction.Up, 1, 1)]
    public void NextDiagonal_Check(Direction d, int x, int y)
    {
        var p = new Point(0, 0);
        var result = p.NextDiagonal(d);
        Assert.Equal(new Point(x, y).ToString(), result.ToString());
    }
}
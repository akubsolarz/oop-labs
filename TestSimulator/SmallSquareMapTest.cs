using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTest
{
    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_Throws_IfSizeInvalid(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(20)]
    public void Constructor_AcceptsValidSizes(int size)
    {
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Fact]
    public void Exist_ReturnsTrue_ForPointInside()
    {
        var map = new SmallSquareMap(5);
        Assert.True(map.Exist(new Point(0, 0)));
        Assert.True(map.Exist(new Point(4, 4)));
    }

    [Fact]
    public void Exist_ReturnsFalse_ForPointOutside()
    {
        var map = new SmallSquareMap(5);
        Assert.False(map.Exist(new Point(5, 0)));
        Assert.False(map.Exist(new Point(-1, 1)));
    }

    [Fact]
    public void Next_MoveInsideMap()
    {
        var map = new SmallSquareMap(6);
        var result = map.Next(new Point(2, 2), Direction.Up);
        Assert.Equal(new Point(2, 3).ToString(), result.ToString());
    }

    [Fact]
    public void Next_StopsAtBoundary()
    {
        var map = new SmallSquareMap(6);
        var result = map.Next(new Point(0, 0), Direction.Left);
        Assert.Equal(new Point(0, 0).ToString(), result.ToString());
    }

    [Fact]
    public void NextDiagonal_WorksInside()
    {
        var map = new SmallSquareMap(6);
        var result = map.NextDiagonal(new Point(2, 2), Direction.Up);
        Assert.Equal(new Point(3, 3).ToString(), result.ToString());
    }

    [Fact]
    public void NextDiagonal_StopsAtBoundary()
    {
        var map = new SmallSquareMap(6);
        var result = map.NextDiagonal(new Point(0, 0), Direction.Down);
        Assert.Equal(new Point(0, 0).ToString(), result.ToString());
    }
}

using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_UnSortedCoordinates()
    {
        var r = new Rectangle(5, 5, 1, 1);
        Assert.Equal(1, r.X1);
        Assert.Equal(5, r.X2);
        Assert.Equal(1, r.Y1);
        Assert.Equal(5, r.Y2);
    }
    [Fact]
    public void Constructor_SortedCoordinates()
    {
        var r = new Rectangle(1, 3, 5, 7);
        Assert.Equal(1, r.X1);
        Assert.Equal(3, r.Y1);
        Assert.Equal(5, r.X2);
        Assert.Equal(7, r.Y2);
    }

    [Fact]
    public void Constructor_Throws_ForThinRectangle_X()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 4, 1, 10));
    }

    [Fact]
    public void Constructor_Throws_ForThinRectangle_Y()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(4, 1, 10, 1));
    }

    [Fact]
    public void Contains_ReturnsTrue_ForPointInside()
    {
        var r = new Rectangle(3, 3, 7, 7);
        Assert.True(r.Contains(new Point(4, 5)));
    }

    [Fact]
    public void Contains_ReturnsTrue_ForPointOnBorder()
    {
        var r = new Rectangle(3, 3, 7, 7);
        Assert.True(r.Contains(new Point(3, 3)));
        Assert.True(r.Contains(new Point(7, 7)));
    }

    [Fact]
    public void Contains_ReturnsFalse_ForPointOutside()
    {
        var r = new Rectangle(3, 3, 7, 7);
        Assert.False(r.Contains(new Point(9, 10)));
        Assert.False(r.Contains(new Point(-1, 0)));
    }
}
namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        if (String.IsNullOrWhiteSpace(input))
        {
            return new List<Direction>();
        }
        var directions = new List<Direction>();

        foreach (char c in input.ToUpperInvariant())
        {
            switch (c)
            {
                case 'U': directions.Add(Direction.Up); break;
                case 'D': directions.Add(Direction.Down); break;
                case 'L': directions.Add(Direction.Left); break;
                case 'R': directions.Add(Direction.Right); break;
                default: break;
            }
        }
        return directions;
    }
}

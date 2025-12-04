namespace Simulator;

public abstract class Creature
{
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

    public string Go(Direction direction)
    {
        string dir = direction.ToString().ToLower();
        return $"{Name} goes {dir}.";
    }

    public string[] Go(Direction[] directions)
    {
        if (directions == null || directions.Length == 0)
            return new[] { $"{Name} stands still." };

        return directions.Select(d => Go(d)).ToArray();
    }

    public string[] Go(string input)
    {
        Direction[] directions = DirectionParser.Parse(input);
        return Go(directions);
    }

    public abstract string Greating();

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Info}";
    }
    public static string Slogan() => "creatures are great !!!";

    public abstract string Info {  get; }


}


namespace Simulator
{
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

        public void Go(Direction direction)
        {
            String dir = direction.ToString().ToLower();
            Console.WriteLine($"{Name} goes {dir}.");
        }

        public void Go(Direction[] directions)
        {
            if (directions == null || directions.Length == 0)
            {
                Console.WriteLine($"{Name} Stands still.");
                return;
            }

            foreach (var d in directions)
                Go(d);
        }

        public void Go(string input)
        {
            Direction[] directions = DirectionParser.Parse(input);
            Go(directions);
        }
        public abstract void SayHi();

        public static void Slogan() => Console.WriteLine("creatures are great !!!");

        public string Info => $"{Name} [{Level}]";


    }
}


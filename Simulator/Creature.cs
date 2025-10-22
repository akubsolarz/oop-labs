namespace Simulator
{
    public class Creature
    {
        public string Name { get; }
        private int _level;

        public int Level
        {
            get => _level;
            set { _level = value > 0 ? value : 1; }
        }

        public Creature()
        {
            Name = "Unknown";
            Level = 0;
        }
        public Creature(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

        public static void Slogan() => Console.WriteLine("creatures are great !!!");

        public string Info => $"{Name} [{Level}]";


    }
}

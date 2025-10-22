namespace Simulator
{
    public class Creature
    {
        private string _name = "Unknown";
        private int _level = 1;
        public string Name 
        { 
            get => _name;
            set => _name = StandardImie(value);
        }
        public int Level
        {
            get => _level;
            set => _level = StandardLevel(value);
           
        }

        public Creature() { }
        
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

        public void Upgrade()
        {
            if (_level < 10)
                _level++;
        }
        private static string StandardImie(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Unknown";
               
            name=name.Trim();

            if(name.Length>25)
                name = name.Substring(0, 25).TrimEnd();

            while(name.Length < 3)
                name += "#";

            if (char.IsLower(name[0]))
                name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }

        private static int StandardLevel(int level)
        {
            if (level < 1) return 1;
            if (level > 10) return 10;
            return level;
        }

        public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

        public static void Slogan() => Console.WriteLine("creatures are great !!!");

        public string Info => $"{Name} [{Level}]";


    }
}

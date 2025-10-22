namespace Simulator
{
    public class Animals
    {
        private string _description = "Unknown";
        public string Description
        {
            get => _description; 
            set => _description = StandardDesc(value); 
        }

        private static string StandardDesc(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Unknown";

            name = name.Trim();

            if (name.Length > 15)
                name = name.Substring(0, 15).TrimEnd();

            while (name.Length < 3)
                name += "#";

            if (char.IsLower(name[0]))
                name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }
        public uint Size { get; set; } = 3;

        public string Info => $"{Description}<{Size}>";
    }
}

namespace Simulator
{
    public class Animals
    {
        private string _description = "Unknown";
        public string Description
        {
            get => _description; 
            set => _description = Validator.Shortener(value, 3, 15, '#'); 
        }
        public uint Size { get; set; } = 3;

        public string Info => $"{Description}<{Size}>";
    }
}

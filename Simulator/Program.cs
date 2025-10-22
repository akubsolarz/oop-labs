namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator!\n");

            Creature c = new Creature("shrek", 7);

            c.SayHi();
            
            Console.WriteLine(c.Info);
            Creature.Slogan();

            Animals a = new() { Size = 3, Description = "Dogs" };
            Console.WriteLine($"{a.Description}, {a.Size}");  // Rats, 3

            Console.WriteLine(a.Info);

            Console.WriteLine("Koniec");

        }
    }
}

using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");



        TestValidators();





    }
    static void TestValidators()
    {
        Creature c = new Orc("   Shrek    ", 20);
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new Orc(" ", -5);
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new Elf("  donkey ",7);
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new Elf("Puss in Boots – a clever and brave cat.");
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new Elf("a                            troll name", 5);
            c.Upgrade();
            Console.WriteLine(c.Info);

            var a = new Animals() { Description = "   Cats " };
    Console.WriteLine(a.Info);

            a = new () { Description = "Mice           are great", Size = 40 };
Console.WriteLine(a.Info);
        }
    
}


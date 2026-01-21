using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Starting Simulator!\n");

        List<Creature> creatures =

[
     new Elf("Elrond", 5, 7),
             new Orc("Gorgul", 4, 6),
             new Elf("Legolas", 6, 8),
             new Orc("Thrall", 5, 7),
             new Elf("Tauriel", 4, 5),
             new Orc("Azog", 6, 9)
];

        creatures.ForEach(c => Console.WriteLine($"{c,-20} power: {c.Power}"));

        Console.WriteLine("\nSort by power\n");

        creatures.Sort((c1, c2) => c2.Power - c1.Power);
        creatures.ForEach(c => Console.WriteLine($"{c,-20} power: {c.Power}"));


        Console.WriteLine("\nSort by name\n");

        creatures.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
        creatures.ForEach(c => Console.WriteLine($"{c,-20} power: {c.Power}"));


    }

}


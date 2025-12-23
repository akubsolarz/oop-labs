using SimConsole;
using Simulator;
using Simulator.Maps;

Console.WriteLine("Wybierz symulację:");
Console.WriteLine("1) Sim1 ");
Console.WriteLine("2) Sim2 ");

var key = Console.ReadKey(true).KeyChar;
Console.WriteLine();

switch (key)
{
    case '1':
        Sim1();
        break;
    case '2':
        Sim2();
        break;
    default:
        Console.WriteLine("zły wybór");
        break;
}
static void Sim1()
{
    SmallSquareMap map = new(5);
    List<Imapable> creatures = new() { new Orc("Gorbag"), new Elf("Elandor") };
    List<Point> points = new() { new Point(2, 2), new Point(3, 1) };
    //podstawowy
    //string moves_set1 = "dlrludl";
    //inne dane wejściowe
    string moves_set2 = "ulrlddrl";


    Simulation simulation = new(map, creatures, points, moves_set2);
    MapVisualizer visualizer = new(map);

    
    visualizer.Draw();

    while (!simulation.Finished)
    {
        Console.WriteLine("\nPress any key for next move...");
        Console.ReadKey(true); 
        simulation.Turn();     
        visualizer.Draw();     
    }

    Console.WriteLine("Simulation finished!");
}
static void Sim2()
{
    Map map = new SmallTorusMap(8, 6);

    var creatures = new List<Imapable>
    {
        new Elf("Elandor"),
        new Orc("Gorbag"),

        // króliki
        new Animals() { Description = "Rabbits" , Size = 30},

        // orły
        new Birds("orły", 10, canFly: true),

        // strusie
        new Birds("strusie", 10, canFly: false),
    };

    var points = new List<Point>
    {
        new Point(0, 0),
        new Point(7, 5),
        new Point(1, 1),
        new Point(4, 2),
        new Point(6, 4),
    };

    string moves_set20 = "ulrldduuulllurrruddd"; 

    Simulation simulation = new(map, creatures, points, moves_set20);
    MapVisualizer visualizer = new(map);

    visualizer.Draw();

    while (!simulation.Finished)
    {
        Console.WriteLine("\nPress any key for next move...");
        Console.ReadKey(true);
        simulation.Turn();
        visualizer.Draw();
    }

    Console.WriteLine("Simulation finished!");
}
using SimConsole;
using Simulator;
using Simulator.Maps;

Console.WriteLine("Wybierz symulację:");
Console.WriteLine("1) Sim1 ");
Console.WriteLine("2) Sim2 ");
Console.WriteLine("3) Sim3 ");

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
    case '3':
        Sim3();
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
static void Sim3()
{
    Map map = new SmallTorusMap(8, 6);

    var creatures = new List<Imapable>
    {
        new Elf("Elandor"),
        new Orc("Gorbag"),
        new Animals { Description = "Rabbits", Size = 30 },
        new Birds("orły", 10, canFly: true),
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

    string moves = "ulrldduuulllurrruddd"; 

    
    var sim = new Simulation(map, creatures, points, moves);
    var log = new SimulationLog(sim);
    var visualizer = new LogVisualizer(log);

    // ruchy strusie
    int[] moveset_S = { 5, 10, 15, 20 };
    // ruchy orłów
    int[] moveset_O = { 4, 9, 14, 19 };
    // ruchy orca
    int[] moveset_OR = { 2, 7, 12, 17 };
    // ruchy elfa
    int[] moveset_E = { 1, 6, 11, 16 };
    // ruchy królików
    int[] moveset_R = { 3, 8, 13, 18 };



    foreach (int t in moveset_S)
    {
        
        visualizer.Draw(t);

        Console.WriteLine();
        Console.WriteLine("Press any key to show next move...");
        Console.ReadKey(true);
    }
}
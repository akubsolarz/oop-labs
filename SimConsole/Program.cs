using SimConsole;
using Simulator;
using Simulator.Maps;

SmallSquareMap map = new(5);
List<Creature> creatures = new() { new Orc("Gorbag"), new Elf("Elandor") };
List<Point> points = new() { new Point(2, 2), new Point(3, 1) };
//podstawowy
string moves_set1 = "dlrludl";
//inne dane wejściowe
string moves_set2 = "ulrlddrl";


Simulation simulation = new(map, creatures, points, moves_set2);
MapVisualizer visualizer = new(map);

// Rysuj początek
visualizer.Draw();
Console.WriteLine("Press any key for next move...");

while (!simulation.Finished)
{
    Console.ReadKey(true); // czekamy na klawisz

    simulation.Turn();     // wykonujemy jeden ruch
    visualizer.Draw();     // odświeżamy mapę
}

Console.WriteLine("Simulation finished!");
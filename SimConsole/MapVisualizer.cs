using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)  => _map = map;


    public void Draw()
    {

        int width = _map.SizeX;
        int height = _map.SizeY;

        // Górna ramka
        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
            Console.Write(Box.Horizontal);
        Console.Write(Box.TopRight);
        Console.WriteLine();

        // Wiersze mapy
        for (int y = 0; y < height; y++)
        {
            Console.Write(Box.Vertical);

            for (int x = 0; x < width; x++)
            {
                var creatures = _map.At(x, y);

                char symbol =
                    creatures.Count == 0 ? ' ' :
                    creatures.Count == 1 ? creatures[0].MapSymbol :
                    'X';

                Console.Write(symbol);
            }

            Console.Write(Box.Vertical);
            Console.WriteLine();
        }

        // Dolna ramka
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
            Console.Write(Box.Horizontal);
        Console.Write(Box.BottomRight);
        Console.WriteLine("\n Press any key for next move...");
    }
}

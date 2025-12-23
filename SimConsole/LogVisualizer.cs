using Simulator;

namespace SimConsole;

internal class LogVisualizer
{
    private readonly SimulationLog _log;

    public LogVisualizer(SimulationLog log)
        => _log = log ?? throw new ArgumentNullException(nameof(log));

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
            throw new ArgumentOutOfRangeException(nameof(turnIndex));

        var turn = _log.TurnLogs[turnIndex];

        
        Console.WriteLine($"Turn: {turnIndex}/{_log.TurnLogs.Count - 1}");
        Console.WriteLine($"Moved: {turn.Mappable}");
        Console.WriteLine($"Move : {turn.Move}");
        Console.WriteLine();

        int width = _log.SizeX;
        int height = _log.SizeY;

      
        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(x == width - 1 ? Box.TopRight : Box.TopMid);
        }
        Console.WriteLine();

        for (int y = 0; y < height; y++)
        {
            
            Console.Write(Box.Vertical);
            for (int x = 0; x < width; x++)
            {
                var p = new Point(x, y);
                char c = turn.Symbols.TryGetValue(p, out var sym) ? sym : ' ';
                Console.Write(c);
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

           
            if (y < height - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < width; x++)
                {
                    Console.Write(Box.Horizontal);
                    Console.Write(x == width - 1 ? Box.MidRight : Box.Cross);
                }
                Console.WriteLine();
            }
        }

        
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(x == width - 1 ? Box.BottomRight : Box.BottomMid);
        }
        Console.WriteLine();
    }
}
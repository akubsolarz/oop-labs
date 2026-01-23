using Simulator.Maps;

namespace Simulator;

public class SimulationLog
{
    private Simulation _simulation { get; }

    public int SizeX { get; }
    public int SizeY { get; }
    public List<TurnLog> TurnLogs { get; } = [];

    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {

        TurnLogs.Add(new TurnLog
        {
            //ruch 0
            Mappable = "Start Symulacji",
            Move = "Start Symulacji",
            Symbols = SnapshotSymbols(_simulation.Map),
            FightMessage = _simulation.LastFightMessage
        });

        while (!_simulation.Finished)
        {
            string mappableText = _simulation.CurrentCreature.ToString();
            string moveText = _simulation.CurrentMoveName;
            Point before = _simulation.CurrentCreature.Position;
            int displayY = (_simulation.Map.SizeY - 1) - before.Y;

            _simulation.Turn();

            TurnLogs.Add(new TurnLog
            {
                Mappable = $"{mappableText} (pos: ({before.X}, {displayY}))",
                Move = moveText,
                Symbols = SnapshotSymbols(_simulation.Map),
                FightMessage = _simulation.LastFightMessage
            });
        }
    }

    private static Dictionary<Point, char> SnapshotSymbols(Map map)
    {
        var dict = new Dictionary<Point, char>();

        for (int y = 0; y < map.SizeY; y++)
        {
            for (int x = 0; x < map.SizeX; x++)
            {
                var list = map.At(x, y);
                if (list.Count == 0) continue;

                char symbol = list.Count == 1 ? list[0].MapSymbol : 'X';
                dict[new Point(x, y)] = symbol;
            }
        }

        return dict;
    }
}
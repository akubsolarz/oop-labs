using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }
    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Imapable> Creatures { get; }
    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }
    /// <summary>
    /// Cyclic list of creatures moves.
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves,
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }
    /// <summary>
    /// Has all moves been done?
    /// </summary>

    public bool Finished { get; private set; } = false;
    /// <summary>
    /// Index of next move.
    /// </summary>

    private int turnIndex = 0;
    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Imapable CurrentCreature => Creatures[turnIndex % Creatures.Count];
    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[turnIndex % Moves.Length].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Imapable> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creature list is empty.");

        if (positions == null || creatures.Count != positions.Count)
            throw new ArgumentException("Number != positions.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        // Add creatures at point
        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation finished.");

        Imapable creature = CurrentCreature;

        List<Direction> parsed = DirectionParser.Parse(CurrentMoveName);

        if (parsed.Count > 0)
        {
            
            Direction direction = parsed[0];
            creature.Go(direction);
        }
        

        
        turnIndex++;

       
        if (turnIndex >= Moves.Length)
            Finished = true;
    }
}
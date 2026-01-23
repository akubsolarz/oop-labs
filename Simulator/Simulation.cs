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
        LastFightMessage = null;

        Imapable creature = CurrentCreature;

        List<Direction> parsed = DirectionParser.Parse(CurrentMoveName);

        if (parsed.Count > 0)
        {

            Direction direction = parsed[0];
            creature.Go(direction);
            ResolveFightAt(creature.Position);
        }

        turnIndex++;


        if (turnIndex >= Moves.Length)
            Finished = true;
    }
    // Sprawdza i rozstrzyga walkę na danym polu mapy
    private void ResolveFightAt(Point p)
    {
        // ttworzy listę wszystkich stworów na tym polu
        var opponents = Map.At(p);

        //sprawdza czy są przynajmniej 2 istoty na polu
        if (opponents.Count < 2) return;

        // Wybierz tylko (Elf, Orc)
        var creatures = opponents.OfType<Creature>().ToList();

        // Jeśli nie ma żadnej Creature = brak walki
        if (creatures.Count == 0) return;

        // sprawdza czy na polu znajduje się zwierzęta
        bool Animals = opponents.Any(o => o is Animals || o is Birds);

        //PRZYPADEK 1: (Elf/Orc) zawsze wygrywa ze zwierzętami
        if (Animals)
        {
            if (CurrentCreature is Creature winner)
            {
                // bonus dla zwycięzcy
                GiveWinBonus(winner);

                // kara dla wszystkich zwierząt na tym polu
                foreach (var animal in opponents.OfType<Animals>())
                {
                    animal.LoseFight(); // Size--
                }

                LastFightMessage = $"{winner.Name} won the fight (+1 stat, animals -1 size)";
            }
            return;
        }

        //PRZYPADEK 2: (Elf vs Orc)
        if (creatures.Count >= 2)
        {
            var c1 = creatures[0];
            var c2 = creatures[1];

            // Pierwsza istota wygrywa
            if (c1.WinsAgainst(c2))
            {
                GiveWinBonus(c1);
                LastFightMessage = $"{c1.Name} won the fight (+1 stat)";
            }
            // Druga istota wygrywa
            else if (c2.WinsAgainst(c1))
            {
                GiveWinBonus(c2);
                LastFightMessage = $"{c2.Name} won the fight (+1 stat)";
            }
            else
            {
                LastFightMessage = $"{c1.Name} zremisował z {c2.Name}";
            }
        }
    }

    // Przyznaje bonus zwycięzcy walki
    private static void GiveWinBonus(Creature winner)
    {
        switch (winner)
        {
            case Orc o:
                o.WinFight();     // Orc dostaje +1 Rage
                break;

            case Elf e:
                e.WinFight();     // Elf dostaje +1 Agility
                break;
        }
        winner.RegisterWin();
    }

    // Przechowuje komunikat o walce dla bieżącej tury
    public string? LastFightMessage { get; private set; }
}
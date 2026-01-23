using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace WebSim.Pages; 

public class IndexModel : PageModel
{
    public SimulationLog Log { get; private set; } = null!;
    public TurnLog Current { get; private set; } = null!;

    [BindProperty(SupportsGet = true)]
    public int Turn { get; set; } = 0;

    public void OnGet()
    {
        Map map = new SmallTorusMap(8, 6);

        var creatures = new List<Imapable>
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 30 },
            new Birds("Eagles", 10, canFly: true),
            new Birds("Ostriches", 10, canFly: false),
        };

        var points = new List<Point>
        {
            new(0, 0),
            new(7, 5),
            new(1, 1),
            new(4, 2),
            new(6, 4),
        };

        string moves = "rlrlrlrlrlrlrlrlrlrllduuuudrll";

        var sim = new Simulation(map, creatures, points, moves);
        Log = new SimulationLog(sim);

        if (Turn < 0) Turn = 0;
        if (Turn >= Log.TurnLogs.Count) Turn = Log.TurnLogs.Count - 1;

        Current = Log.TurnLogs[Turn];
    }
}
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;
using Newtonsoft.Json;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    public Simulation Simulation { get; private set; }
    public string[,] MapGrid { get; private set; }
    public bool SimulationFinished => Simulation.Finished;

    public int Turn { get; private set; } = 1;

    public SimulationTurnLog CurrentLog { get; private set; }

    public SimulationHistory History { get; private set; }

    private void InitializeSimulation()
    {
        // Initialize simulation
        SmallTorusMap map = new(8, 6);
        List<IMappable> creatures = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 6 },
            new Birds { Description = "Eagles", Size = 4, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
        };

        List<Point> points = new()
        {
            new(2, 2),
            new(3, 1),
            new(3, 2),
            new(6, 5),
            new(5, 5)
        };

        Simulation = new(map, creatures, points, "dlrludlruddurlr");
        History = new SimulationHistory(Simulation);
        CurrentLog = History.TurnLogs.FirstOrDefault()!;
    }

    public void OnGet()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 1;

        if (History == null)
        {
            InitializeSimulation();
        }

        UpdateMapGrid();
    }

    public void OnPostNextTurn()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 1;

        if (History == null)
        {
            InitializeSimulation();
        }

        if (Turn < History.TurnLogs.Count - 1)
        {
            Turn++;
            HttpContext.Session.SetInt32("Turn", Turn);
            CurrentLog = History.TurnLogs[Turn];
        }

        UpdateMapGrid();
    }

    public void OnPostPreviousTurn()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 1;

        if (History == null)
        {
            InitializeSimulation();
        }

        if (Turn > 0)
        {
            Turn--;
            HttpContext.Session.SetInt32("Turn", Turn);
            CurrentLog = History.TurnLogs[Turn];
        }

        UpdateMapGrid();
    }

    private void UpdateMapGrid()
    {
        MapGrid = new string[History.SizeX, History.SizeY];

        foreach (var symbolEntry in CurrentLog.Symbols)
        {
            var position = symbolEntry.Key;
            MapGrid[position.X, position.Y] = symbolEntry.Value.ToString();
        }
    }
}

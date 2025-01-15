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

    public string jsonString { get; private set; } = "";

   

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
    }

    public void OnGet()
    {

        Turn = HttpContext.Session.GetInt32("Turn") ?? 1;

        if (Simulation == null)
        {
            InitializeSimulation();
            jsonString = JsonConvert.SerializeObject(Simulation);
        }

        jsonString = HttpContext.Session.GetString("SimulationString") ?? string.Empty;

        UpdateMapGrid();
    }

    public void OnPostNextTurn()
    {

        Turn = HttpContext.Session.GetInt32("Turn") ?? 1;
        jsonString = HttpContext.Session.GetString("SimulationString") ?? string.Empty;
        
        HttpContext.Session.SetString("SimulationString", jsonString);

        if (Simulation == null)
        {
            InitializeSimulation();
            var jsonString = JsonConvert.SerializeObject(Simulation);
        }


       
            
        Simulation.Turn();
        Turn++;
        HttpContext.Session.SetInt32("Turn", Turn);


        UpdateMapGrid();

        
    }

    private void UpdateMapGrid()
    {
        MapGrid = new string[Simulation.Map.SizeX, Simulation.Map.SizeY];
        foreach (var creature in Simulation.Creatures)
        {
            var pos = creature.GetPos();
            MapGrid[pos.X, pos.Y] = creature.ToString();
        }
    }
}

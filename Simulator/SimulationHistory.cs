using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0


    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        for (; !_simulation.Finished; _simulation.Turn())
        {
            var currentMappable = _simulation.CurrentCreature;
            var currentMove = _simulation.CurrentMoveName;
            var symbolsPos = new Dictionary<Point, char>();

            for (int row = 0; row < SizeY; row++)
            {
                for (int col = 0; col < SizeX; col++)
                {
                    var mapCell = _simulation.Map.At(col, row);
                    if (mapCell.Count > 1)
                    {
                        symbolsPos[new Point(col, row)] = 'X';
                    }
                    else if (mapCell.Count == 1)
                    {
                        symbolsPos[new Point(col, row)] = mapCell[0].Symbol;
                    }
                }
            }

            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = currentMappable.ToString(),
                Move = currentMove,
                Symbols = symbolsPos
            });
        }
    }

}

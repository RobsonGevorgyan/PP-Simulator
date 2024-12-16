using Simulator;
using System.ComponentModel;
using System.Xml.Linq;

public class Orc : Creature
{
    private int rageCounter = 1;
    private int _rage;
    public int Rage
    {
        get { return _rage; }
        init
        {
            if (_rage < 0)
            {
                value = 0;
            }
            if (_rage > 10)
            {
                value = 10;
            }
            else
            {
                value = _rage;
            }
            _rage = value;
        }
    }
    public override int Power
    {
        get { return 7 * Level + 3 * Rage; }
    }

    public Orc()
    {

    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        if (rageCounter == 2)
        {
            if (Level < 10)
            {
                Level++;
                rageCounter = 1;
            }
            else
            {
                rageCounter = 1;
            }
        }
        else
        {
            rageCounter++;
        }
        
    }

}
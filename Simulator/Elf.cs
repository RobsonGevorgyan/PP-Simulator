using Simulator;
using System;
using System.Xml.Linq;

public class Elf : Creature
{
    private int agilityCounter = 1;
    private int _agility;
    public int Agility
    {
        get { return _agility; }
        init
        {
            if (_agility < 0)
            {
                value = 0;
            }
            if (_agility > 10)
            {
                value = 10;
            }
            else
            {
                value = _agility;
            }
            _agility = value;
        }
    }

    public override int Power
    {
        get { return 8 * Level + 2 * Agility; }
    }
    public Elf()
    {

    }
    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        if (agilityCounter == 3)
        {
            if (Level < 10)
            {
                Level++;
                agilityCounter = 1;
            }
            else
            {
                agilityCounter = 1;
            }
        }
        else
        {
            agilityCounter++;
        }
    }
}
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
        init => _agility = Validator.Limiter(value, 0, 10);
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

    public override string Info => $"[{Level}][{Agility}]";
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

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
    );
}
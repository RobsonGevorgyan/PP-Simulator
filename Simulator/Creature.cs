namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;


    public abstract int Power { get; }
    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        set => _level = Validator.Limiter(value, 1, 10);
    }

    
    public Creature(string name) : this(name, 1) { }

    
    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {

    }

   
    public abstract string Info
    {
        get;
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Name} {Info}";
    }

    public virtual void SayHi()
    {
        Console.WriteLine($"Hi! My name is {Name} and I am level {Level}.");
    }


    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
    }

    public void Go(Direction direction)
    {
        string directionString = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionString}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        var parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }
}

namespace Simulator;

public class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

    // Właściwości z init z walidacją
    public string Name
    {
        get => _name;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _name = "Unknown";
            }
            else
            {
                value = value.Trim();

                if (value.Length < 3)
                {
                    value = value.PadRight(3, '#');
                }
                else if (value.Length > 25)
                {
                    value = value.Substring(0, 25).TrimEnd();
                    if (value.Length < 3)
                    {
                        value = value.PadRight(3, '#');
                    }
                }

                if (char.IsLower(value[0]))
                {
                    value = char.ToUpper(value[0]) + value.Substring(1);
                }

                _name = value;
            }
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            if (value < 1 || value > 10)
            {
                value=10;
            }
            _level = value;
        }
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

    // Właściwość tylko do odczytu Info
    public string Info => $"Name: {Name}, Level: {Level}";

    // Metoda SayHi()
    public void SayHi()
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

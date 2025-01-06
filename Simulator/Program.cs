using System.Security.Cryptography.X509Certificates;

namespace Simulator;
    internal class Program
    {
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }
            
        
        
       
    
    static void Lab5a()
    {
        var x = new Point(2, 2);

        var y = new Point(3, 4);
        var z = new Point(17, 18);


        var a = new Rectangle(1,1,8,8);
        Console.WriteLine(a.ToString());
        Console.WriteLine(a.Contains(x));


        var d = new Rectangle(4, 3, 2, 1);
        Console.WriteLine(d.ToString());
        Console.WriteLine(d.Contains(x));

        var e = new Rectangle(y, z);
        Console.WriteLine(e.ToString());
        Console.WriteLine(e.Contains(x));

        try
        {
            var b = new Rectangle(1, 2, 1, 3);
            Console.WriteLine(b.ToString());
            Console.WriteLine(b.Contains(x));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        try


        {
            var c = new Rectangle(1, 2, 3, 2);
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.Contains(x));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }



    }



}


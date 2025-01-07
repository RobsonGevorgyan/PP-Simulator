using System.Security.Cryptography.X509Certificates;
using Simulator.Maps;

namespace Simulator;
    internal class Program
    {
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        lab5b();
    }





    static void Lab5a()
    {
        var x = new Point(2, 2);

        var y = new Point(3, 4);
        var z = new Point(17, 18);


        var a = new Rectangle(1, 1, 8, 8);
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
    static void lab5b()
    {

        var a1 = new Point(3, 3);
        var b1 = new SmallSquareMap(5);
        var c1 = Direction.Down;
        Console.WriteLine(b1.Exist(a1));
        Console.WriteLine(b1.Next(a1, c1));
        Console.WriteLine(b1.NextDiagonal(a1, c1));


        try
        {
            var a2 = new Point(24, 8);
            var b2 = new SmallSquareMap(21);
            var c2 = Direction.Up;
            Console.WriteLine(b2.Exist(a2));
            Console.WriteLine(b2.Next(a2, c2));
            Console.WriteLine(b2.NextDiagonal(a2, c2));
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            var a3 = new Point(5, 5);
            var b3 = new SmallSquareMap(5);
            var c3 = Direction.Up;
            Console.WriteLine(b3.Exist(a3));
            Console.WriteLine(b3.Next(a3, c3));
            Console.WriteLine(b3.NextDiagonal(a3, c3));
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    



}


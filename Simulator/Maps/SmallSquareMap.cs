using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public int Size { get; private set; }

        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
            }
            Size = size;
        }


        public override bool Exist(Point p)
        {
            
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
        }

        public override Point Next(Point p, Direction d)
        {
            var z = new Point(p.X, p.Y);
            z = z.Next(d);
            

            if (!Exist(z))
            {
                return p; 
            }

            return (z);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var z = new Point(p.X, p.Y);
            z = z.NextDiagonal(d);


            if (!Exist(z))
            {
                return p;
            }

            return (z);
        }
    }
}

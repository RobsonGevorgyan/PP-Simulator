using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; private set; }

    public SmallTorusMap(int size)
    {
        throw new NotImplementedException();
    }
    public override bool Exist(Point p)
    {
        throw new NotImplementedException();
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
}

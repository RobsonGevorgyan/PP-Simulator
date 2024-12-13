using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    using Simulator;
    using System;
    using System.Collections.Generic;

    public static class DirectionParser
    {
        public static Direction[] Parse(string directions)
        {
            var result = new List<Direction>();

            foreach (var ch in directions.ToUpper())
            {
                switch (ch)
                {
                    case 'U':
                        result.Add(Direction.Up);
                        break;
                    case 'R':
                        result.Add(Direction.Right);
                        break;
                    case 'D':
                        result.Add(Direction.Down);
                        break;
                    case 'L':
                        result.Add(Direction.Left);
                        break;
                }
            }

            return result.ToArray();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Birds : Animals
{
    public bool CanFly { get; init; } = true;

    public override string Info
        => $"(fly{(CanFly ? "+" : "-")}) <{Size}>";

}

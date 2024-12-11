using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

    internal class Creature
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public Creature(string Name, int Level=1)
        {
            Name = "trol";
            Level = 1;
        }

        public Creature()
        {
        }

        public string Info => $"{Name} [{Level}]";
        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }


    }


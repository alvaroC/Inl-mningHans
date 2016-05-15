using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1_1
{
    //Denna klass skapar en punkt utifrån xy-koordinater. XY är egenskaper 
    class Punkt
    {
        public int X
        { get; set; }

        public int Y
        { get; set; }

        public Punkt()
        { }

        public Punkt(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

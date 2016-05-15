using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1_1
{
    //Denna klass skapar en linje utifrån två punkter. Punkt är en annan klass och det egenskap som tillhör linjem
    class Linje
    {
        private Punkt p00, p11, p000;       
        public Linje(Punkt p0, Punkt p1)
        {
            p00 = new Punkt(p0.X, p0.Y);
            p11 = new Punkt(p1.X, p1.Y);            
        }        
        public Punkt Position()
        {
            p000 = new Punkt(p00.X, p00.Y);
            return p000;
        }
        public double Storlek()
        {
            double d;
            d= Math.Sqrt((p11.Y - p00.Y) * (p11.Y - p00.Y) + (p11.X - p00.X) * (p11.X - p00.X));            
            return d;
        }        
    }
}

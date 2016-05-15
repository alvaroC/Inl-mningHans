using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1_1
{
    class Program
    {
        static void Utskrift(string text, Linje linje)
        {
            double längd = linje.Storlek();
            Punkt startPos = linje.Position();

            Console.WriteLine("\n" + text);
            Console.WriteLine("==========================");
            Console.WriteLine("Längd= " + längd);
            Console.WriteLine("Position: " + startPos.X + "," + startPos.Y);

        }
        static void Main(string[] args)
        {
            Punkt p0 = new Punkt();
            Punkt p1 = new Punkt(-10, -10);

            Console.WriteLine("Punkten p0, position = (" + p0.X + ", " + p0.Y + ")");
            Console.WriteLine("Punkten p1, position = (" + p1.X + ", " + p1.Y + ")");

            Linje linjen = new Linje(p0, p1);

            Utskrift("Utskrift 1 av linjen", linjen);

            p1.X = 0;
            Utskrift("Utskrift 2 av linjen", linjen);

            Punkt startposition = linjen.Position();

            startposition.Y = 5;

            Utskrift("Utskrift 3 av linjen", linjen);            
        }
    }
}

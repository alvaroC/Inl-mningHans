using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kajsasdilemma_console
{
    class Program
    {
        static void meny()
        {
            Console.WriteLine("\n******* Kajsas program (v.1.0) ******\n* [A] Lägg till din notis           *");
            Console.WriteLine("* [B] Bläddra igenom notiser        *");
            Console.WriteLine("* [C] Ändra en notismarkering       *");
            Console.WriteLine("* [D] Kasta en specifik notis       *");
            Console.WriteLine("* [E] Kasta alla inaktuella notiser *");
            Console.WriteLine("* [F] Spara innehållet i lådan      *");
            Console.WriteLine("* [X] Avsluta                       *\n*************************************");
        }
                
        static void Main(string[] args)
        {
            bool _loop = true;
            bool spara = true; //Är _false_ om man gör någon ändring. (lägger till notis, ändrar etc.)
            Reglista RegOb = new Reglista();
            RegOb.DataFil = "data.bin"; //Sökväg till datafilen (data.bin)

            // Vi öppnar lådan i början av programmet och skapar i samband med detta nya instanser utav de äldre sparade notiserna
            // i data.bin 
            RegOb.ÖppnaLåda();           

            while (_loop == true)
            {
                meny();
                switch (Console.ReadLine())
                {
                    case "a":
                    case "A":
                        Console.Clear();
                        Console.WriteLine("Ange en ny notis: ");
                        string nyttinnehåll = Console.ReadLine();
                        if (string.IsNullOrEmpty(nyttinnehåll))
                        {
                            Console.WriteLine("Du måste skriva någonting!");
                        }
                        else
                        {
                            RegOb.LäggTillNotis(nyttinnehåll, Convert.ToString(DateTime.Now));
                            spara = false;
                        }
                        break;

                    case "B":
                    case "b":
                        Console.Clear();
                            RegOb.Bläddra();
                        break;

                    case "C":
                    case "c":
                        Console.WriteLine("Ange notisens ID-nummer: ");
                        try { int notisID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ange den nya markeringen (-1 för att ta bort markering): ");
                        int __nyMarkering = Convert.ToInt32(Console.ReadLine());
                        RegOb.ÄndraNotisMarkering(notisID, __nyMarkering);
                        spara = false;
                        } catch { Console.WriteLine("Ange endast siffror. Felkod #10"); }
                        break;

                    case "D":
                    case "d":
                        Console.WriteLine("Ange notisens ID-nummer: ");
                        try
                        {
                            int _notisID = Convert.ToInt32(Console.ReadLine());
                            RegOb.RaderaNotis(_notisID);
                            spara = false;
                        }
                        catch
                        {
                            Console.WriteLine("Ange endast siffror. Felkod #20");
                        }
                        break;

                    case "E":
                    case "e":
                        spara = false;
                        RegOb.RaderaInaktuellaNotiser();
                        break;

                    case "F":
                    case "f":
                        spara = true;
                        RegOb.SparaTillLådan();
		                break;

                    case "X":
                    case "x":
                        if (spara == false)
                        {
                            Console.WriteLine("Vill du verkligen avsluta? Du har ej sparat. Y/N");
                            switch (Console.ReadLine())
                            {
                                case "Y":
                                case "y":
                                    _loop = false;
                                    Console.WriteLine("Välkommen åter.");
                                    break;
                                case "N":
                                case "n":
                                    Console.Clear();
                                    break;
                            }
                        }
                        else
                        {
                            _loop = false;
                            Console.WriteLine("Välkommen åter.");
                        }
                        
                        break;
                }
            }
        }
    }
}

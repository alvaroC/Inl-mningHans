using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace kajsasdilemma_console
{
    //Klassen Reglista är en register för att alla papperlappar som skapas. En viktig egenskap är klassen Notis plus alla de metoder som behövs för att 
    //hantera registern
    class Reglista
    {
        private List<Notis> RegListan;
        public Reglista()
        {
            //Skapar en lista utav notiser
            RegListan = new List<Notis>();
        }
        public string DataFil { get; set; }

        public void LäggTillNotis(string innehåll, string datum)
        {
            RegListan.Add(new Notis(innehåll, datum));
        }

        public void Bläddra()
        {
            if (RegListan.Count == 0)
               Console.WriteLine("Kan inte bläddra igenom notiserna. Lådan är tom!");
            else
            {
                Console.WriteLine("Öppnar upp lådan...\nID     Datum                   Innehåll [prioritet]");
                int i = 0;
                foreach (var element in RegListan)
                {
                    Console.WriteLine("("+i+")" + " :: " + element);
                    i++;
                }
            }
        }

        public void RaderaNotis(int val)
        {
            RegListan.RemoveAt(val);
            //Raderar en specifik notis
        }

        public void RaderaInaktuellaNotiser()
        {
            /* Raderar alla inaktuella notiser.
             * Dvs. Notiser vars prioritetsmarkering
             * är = 0. */
            try
            {
                int Count = RegListan.Count;
                for (int i = 0; i < Count; i++)
                {
                    if (RegListan[i].NotisMarkering == 0)
                    {
                        RegListan.RemoveAt(i);
                        Count = Count - 1;
                        i--;
                    }
                }
            }
            catch { Console.WriteLine("Någonting gick fel... Felkod #100"); }
        }

        public void ÄndraNotisMarkering(int val, int nyMarkering)
        {
            RegListan.ElementAt(val).NotisMarkering = nyMarkering;
        }

        public void SparaTillLådan()
        {
            /* Sparar alla notiser till data.bin */
            try
            {
                using (Stream stream = File.Open(this.DataFil, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, this.RegListan);
                }
            }
            catch //(IOException)
            {
                Console.WriteLine("Någonting gick fel! Felkod #1010");
            }
        }
        public void ÖppnaLåda()
        {
            /* Öppnar data.bin filen som innehåller all sparad data */
            try
            {
                using (Stream stream = File.Open(this.DataFil, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var SparadeObjekt = (List<Notis>)bin.Deserialize(stream);
                    RegListan = SparadeObjekt;
                    //foreach (var element in SparadeObjekt)
                    //{
                    //    RegListan.Add(new Notis(element.NotisInnehåll, element.NotisDatum, element.NotisMarkering));
                    //    //instanserar de tidigare objekten(notiser)sparade i "data.bin"
                    //}
                }
            }
            catch //(IOException)
            {
                Console.WriteLine("data.bin (din låda) kunde ej hittas...\nOm detta är första gången du kör ditt\nprogram, lägg till din första notis\noch spara!");
            }
        }
    }
}

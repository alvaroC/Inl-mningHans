using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kajsasdilemma_console
{
    [Serializable()]

    //Klassen Notis skapar innehåll för varje papperslapp som skapas. Föruton innehåll är andra viktiga egenskaper: datum, diverse markering. 
    class Notis
    {
        public string NotisInnehåll { get; set; }
        public string NotisDatum { get; set; }

        private int notismarkering;
        public int NotisMarkering
        {
            get { return notismarkering; }
            set
            {
                if (value <= 3 && value >= -1)
                {
                    notismarkering = value;
                }
                else
                {
                    notismarkering = -1;
                }
            }
        }

        /*Constructor 1, vid tillägg av nya notiser.*/
        public Notis(string innehåll, string datum /*, int prioMarkering*/) //Skriver en notis vid instansering utav objektet.
        {
            NotisInnehåll = innehåll;
            NotisDatum = datum;
            //NotisMarkering = prioMarkering;
            NotisMarkering = -1;
        }

        /*Constructor 2, vid inläsning av notiser sparade i data.bin (inkl. prioritetsmarkering)*/
        public Notis(string innehåll, string datum, int prioMarkering) //Skriver en notis vid instansering utav objektet. (inkl. dess tidigare prioritetsmarkering)
        {
            NotisInnehåll = innehåll;
            NotisDatum = datum;
            NotisMarkering = prioMarkering;
        }
        public override string ToString()
        {
            if (this.NotisMarkering == -1)
            {
                return "[" + NotisDatum + "] - " + NotisInnehåll;
            }
            else
            {
                return "[" + NotisDatum + "] - " + NotisInnehåll + " [" + NotisMarkering + "]";
            }
        }
    }
}

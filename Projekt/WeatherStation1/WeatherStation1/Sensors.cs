using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WeatherStation1
{
    class Sensors
    {
        // Data från sensorer
        private int temperature = 0;
        private int pressure = 0;
        private int humidity = 0;

        //Propities
        public int Temperature
        {
            get
            {  return temperature;  }           
        }

        public int Pressure
        {
            get
            { return pressure; }
        }

        public int Humidity
        {
            get
            { return humidity; }
        }
        public Sensors()
        { }

        //Starata mätdata
        public void StartMesasuremnt()
        {

             Random rdnTemperature = new Random();
             Random rdnPressure = new Random();
             Random rdnHumidity = new Random();

             temperature = rdnTemperature.Next(-30, 50);
             pressure = rdnPressure.Next(100);
             humidity = rdnHumidity.Next(100);            
        }        
     }
}

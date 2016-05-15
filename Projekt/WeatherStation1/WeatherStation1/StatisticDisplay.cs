using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation1
{
    class StatisticDisplay : IObserver, IDisplay
    {
        private List<float> temperatureList = new List<float>();
        private List<float> pressureList = new List<float>();

        ISubject weatherData;
        

        //Konstruktor: Initierar en prenumeration       
        public StatisticDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);            
        }
        public void Uppdate(float temperature, float humidity, float pressure)
        {
            temperatureList.Add(temperature);
            pressureList.Add(pressure);
            Display();
        }

        public void Display()
        {
            double avgTemp = temperatureList.Average();
            double minTemp = temperatureList.Min();
            double maxTemp = temperatureList.Max();

            double avgPressure = pressureList.Average();
            double minPressure = pressureList.Min();
            double maxPressure = pressureList.Max();

            Console.WriteLine("STATISTIC:" + "\n--------------");
            Console.WriteLine("Temperature Avarage: " + avgTemp + "\nMin Temperature: " + minTemp + "\nMax Temperature: " + maxTemp);
            Console.WriteLine(" ");
            Console.WriteLine("Pressure: Avarage: " + avgPressure + "\nMin Pressure: " + minPressure + "\nMax Pressure: " + maxPressure);                  
        }
    }
}

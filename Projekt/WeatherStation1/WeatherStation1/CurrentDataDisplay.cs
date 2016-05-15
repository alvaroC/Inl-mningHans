using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation1
{
    class CurrentDataDisplay : IObserver, IDisplay
    {
        private float temperature;
        private float humidity;
        private float pressure;
       

        private ISubject weatherData;

             
        //Konstruktor: Initierar en prenumeration       
        public CurrentDataDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);          
        }

        //Implemeterar Uppdate från Inteface IObserver
        public void Uppdate(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            Display();
        }

        //Implemeterar Uppdate från Inteface IDisplay
        public void Display()
        {
            Console.WriteLine(" ");
            Console.WriteLine("CURRENT DATA:" + "\n-------------");
            Console.WriteLine("Temperature: " + temperature + "\nHumidity: " + humidity + "\nPressure: " + pressure);
            Console.WriteLine(" ");
        }
    }
}

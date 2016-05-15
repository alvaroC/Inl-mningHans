using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WeatherStation1
{
    class WeatherData : ISubject
    {
        private List<IObserver> observers;
        private float temperature = 0;
        private float humidity = 0;
        private float pressure = 0;
        private Sensors sensors;
             
        public List<IObserver> Observers
        {
            get { return observers; }
        }

        //Konstruktor
        public WeatherData()
        {
            observers = new List<IObserver>();
            sensors = new Sensors();           
        }
        //Registrerar ny prenumerant
        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);           
        }

        //Tar bort prenumerant
        public void RemoveObserver(IObserver o)
        {
            if (observers.Count > 0)
            {
                observers.Remove(o);
                Console.WriteLine("Tjänsten har tagists bort");
            }
        }

        //Notifierar alla prenumeranter när tillståndet för data (temp, humidity, pressure) har ändrats
        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
                o.Uppdate(temperature, humidity, pressure);
        }

        public void measurementsChanged()
        {
            NotifyObservers();
        }
                
        public void setMeasurements(int number)
        {
            for (int i = 0; i < number; i++)
            {
                sensors.StartMesasuremnt();

                this.temperature = sensors.Temperature;
                this.humidity = sensors.Humidity;
                this.pressure = sensors.Pressure;
                measurementsChanged();
                Thread.Sleep(10000);
                Console.Clear();
            }
        }
    }
}

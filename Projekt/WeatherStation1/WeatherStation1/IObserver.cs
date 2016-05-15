using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation1
{
    interface IObserver
    {
        void Uppdate(float temp, float humidity, float pressure);
    }
}

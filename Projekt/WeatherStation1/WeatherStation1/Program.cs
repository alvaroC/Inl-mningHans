using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            string val;
            bool prenumerationData = false;
            bool prenumerationSta = false;
            bool ok = true;         
           
            CurrentDataDisplay currentInfo = null;
            StatisticDisplay statisticInfo = null;

            //Skapar väderstationen  
            WeatherData weatherData = new WeatherData();


            while (ok)
            {
                Console.WriteLine(" ");
                Console.WriteLine("VÄLKOMMEN TILL VÄDERSTATION SIGI");
                Console.WriteLine("Prenumerera våra tjäsnter");
                Console.WriteLine("------------------------");               

                Console.WriteLine("1) Aktuellt värde information (temperatur, tryck, fuktighet");
                Console.WriteLine("2) Väderstatistik");

                Console.WriteLine("3) Väderprognos");
                Console.WriteLine("4) Starta mätningar");
                Console.WriteLine("5) Säga upp prenumeration");               
                Console.WriteLine("6) Avsluta");
                Console.WriteLine(" ");                               
                                
                val = Console.ReadLine();
                switch(val)
                {
                    case "1": //Prenumererar tjänsten: CurrentData
                        Console.Clear();
                        if (prenumerationData == false)
                        {
                            Console.WriteLine(" \n" + "DU HAR PRENUMERERAT AKTUELL VÄRDERDATA\n" + "--------------------------------------");
                            currentInfo = new CurrentDataDisplay(weatherData);
                            prenumerationData = true;                                                        
                        }
                        else
                           Console.WriteLine("\n" + "Du prenumererar redan denna tjänst");
                        
                        break;
                    case "2": //Prenumererar tjänsten: Statistik
                        Console.Clear();
                        if (prenumerationSta == false)
                        {
                            Console.WriteLine(" \n" + "DU HAR PRENUMERERAT VÄRDER STATISTIK\n" + "----------------------------------");
                            statisticInfo = new StatisticDisplay(weatherData);
                            prenumerationSta = true;                                                        
                        }
                        else
                            Console.WriteLine("\n" + "Du prenumererar redan denna tjänst");
                        break;
                    case "3": //Denna tjänsten är ej implementerad
                        Console.Clear();
                        Console.WriteLine(" \n" + "DENNA TJÄNST KOMMER SNART\n" + "--------------------------");                                       
                        break;
                    case "4": //Starta data mätning
                        Console.Clear();
                        if ( (prenumerationData == true) || (prenumerationSta == true) ) 
                        {
                            Console.WriteLine("Starta datainsamling\n" + "Hur många mätningar ska det göras?");
                            number = Convert.ToInt32(Console.ReadLine());

                            if (number > 0)
                                weatherData.setMeasurements(number);
                            else
                                Console.WriteLine("fel val");
                        }
                        else
                            Console.WriteLine("Det finns ingen prenumeration");
                        break;

                    case "5": // Ta bort tjäsnter
                        Console.Clear();
                        Console.WriteLine(" \n" + "SÄG UPP TJÄNST\n" + "-----------------");
                        Console.WriteLine("1) Aktuellt värde information");
                        Console.WriteLine("2) Väderstatistik");
                        Console.WriteLine("3) Väderprognos");
                        string service = Console.ReadLine();
                        
                        if (service == "1")
                           weatherData.RemoveObserver(currentInfo);
                        else if (service == "2")
                            weatherData.RemoveObserver(statisticInfo);
                        else if (service == "3")
                            Console.WriteLine("Denna tjänst finns inte än");
                        else
                            Console.WriteLine("fel");

                        break;                   
                    case "6": //Avsluta
                        Console.WriteLine("Tack");
                        ok = false;
                        break;
                    default:
                        Console.WriteLine("Fel val. Försök igen");
                        break;
                }
            }                                                  
        }
    }
}

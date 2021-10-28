using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeather
{
    class Program
    {
        static void Main(string[] args)
        {            
            var client = new HttpClient();
            //Console.WriteLine("Enter your API Key: ");
            //var apiKey = Console.ReadLine();
            var apiKey = "5f1d945b3d1e423ccd725811435f994f";

            while (true)
            {
                Console.WriteLine("Enter your city name: ");
                Console.WriteLine();
                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine(formattedResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose a different city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();

                if(userInput.ToLower() =="no")
                {
                    Console.WriteLine("Ok then.  Goodbye.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }

            }
        }
    }
}

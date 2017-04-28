using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace videojuego
{
    class Clima
    {
        public void ShowWeather()
        {
            string w;
            try
            {
                WebRequest wbrqst = WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select%20item.condition.text%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22buenos%20aires%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                WebResponse wbrps = wbrqst.GetResponse();
                Stream stream = wbrps.GetResponseStream();
                StreamReader sReader = new StreamReader(stream);
                JObject data = JObject.Parse(sReader.ReadToEnd());
                w = (string)data["query"]["results"]["channel"]["item"]["condition"]["text"];
                switch (w)
                {
                    case "Cloudy":
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case "Sunny":
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                }
            }
            catch
            {
                w = "Sin conexion disponible";
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

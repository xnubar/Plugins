using Newtonsoft.Json;
using Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherPlugin
{
    public class Weather : IPlugin
    {
        public string Name { get; set; } = "Weather Plugin";
        public string Key { get; set; } = "ac95590b4a166c12eb2c9c64ddf4ad34";
        public async Task<dynamic> Do(string input)
        {
            WebClient webClient = new WebClient { Encoding = Encoding.UTF8 };
            var result = webClient.DownloadString($"http://api.openweathermap.org/data/2.5/weather?q={input}&mode=json&units=metric&APPID={Key}");
            dynamic data =  JsonConvert.DeserializeObject(result);
            if (data.name!=null)
                return (data.main);
            throw new Exception("Location isn't found.");
        }
        
    }
}


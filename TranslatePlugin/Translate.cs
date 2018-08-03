using Newtonsoft.Json;
using Plugin;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.Serialization;

namespace TranslatePlugin
{
    public class Translate : IPlugin
    {
        public string Name { get; set; } = "Translate Plugin";
        private  string Key { get; } = @"trnsl.1.1.20180709T210329Z.c55a9ed112838e58.73429c8c1480ccbae784bc3f373222f27882f2fa";
        public string Lang { get; set; } = "az";
        private static string UrlTranslateLanguage { get; } = "https://translate.yandex.net/api/v1.5/tr.json/translate";
        public async Task<dynamic> Do(string input)
        {
        
            WebClient webClient = new WebClient();

            var result = webClient.DownloadString($"https://translate.yandex.net/api/v1.5/tr.json/translate?key={Key}&text={input}&lang={Lang}");

            dynamic data = JsonConvert.DeserializeObject(result);
            if (data!=null)
                return data;
            throw new Exception("No such movie found with this name");




        }
    }
}


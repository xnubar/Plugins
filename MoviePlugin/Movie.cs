using Newtonsoft.Json;
using Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoviePlugin
{
    public class Movie : IPlugin
    {
        public string Path { get; set; } = "http://www.omdbapi.com/?i=tt3896198&apikey=11125f97&";
        public string Name { get; set; } = "Movie Plugin";

        public async Task<dynamic> Do(string input)
        {

            using (WebClient webClient = new WebClient())
            {
                var result = webClient.DownloadString(Path + "t=" + input);
                dynamic data = JsonConvert.DeserializeObject(result);
                if (!data.Response.Equals("False"))
                    return data;
                throw new Exception("No such movie found with this name");
            }                  
        }
    }
}

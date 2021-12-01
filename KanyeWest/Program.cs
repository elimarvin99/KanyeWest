using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KanyeWest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var kanyeQuotes = new List<string>();
            var swansonQuotes = new List<string>();
            Console.WriteLine("How many quotes do you want to get?");
            var input = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                Console.WriteLine($"Conversation #{i}");
                var kanyeURL = "https://api.kanye.rest";
                var kanyeClient = new HttpClient();
                //send a get request to the url and get the json as a string and the result returns it to us as a string
                var kanyeResponse = kanyeClient.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                //kanyeQuotes.Add(kanyeQuote);
                Console.WriteLine($"Kanye says: {kanyeQuote}");
                Thread.Sleep(1000);

                var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
                var swansonClient = new HttpClient();
                var swansonResponse = swansonClient.GetStringAsync(swansonURL).Result;
                var ronQuote = JArray.Parse(swansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                //swansonQuotes.Add(ronQuote);
                Console.WriteLine($"Swanson replies: {ronQuote}");
                Console.WriteLine("-------------------------------------------");
                Thread.Sleep(1000);
            }

            ////Donald Trump bonus section
            //var trumpURL = "https://www.io.tronalddump.api";
            //var trumpClient = new HttpClient();
            //var trumpResponse = trumpClient.GetStringAsync(trumpURL).Result;
            ////var trumpQuote = JObject.Parse(trumpResponse).GetValue("quote").ToString();
            //Console.WriteLine($"Trumpy says: {trumpResponse}");

            //COD section
            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone-matches/Amartin743/psn"),
            //    Headers =
            //    {
            //        { "x-rapidapi-host", "call-of-duty-modern-warfare.p.rapidapi.com" },
            //        { "x-rapidapi-key", "eecd9e3415msh53b4b079f89a9ccp126a2bjsn8aac4d755253" },
            //    },
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = response.Content.ReadAsStringAsync().Result;
            //    var quote = JObject.Parse(body).ToString();
            //    Console.WriteLine(quote);
            //}



        }
    }
}

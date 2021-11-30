using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var kanyeQuotes = new List<string>();
            //var swansonQuotes = new List<string>();
            Console.WriteLine("How many quotes do you want to get?");
            var input = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
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
                Thread.Sleep(1000);
            }
            

        }
    }
}

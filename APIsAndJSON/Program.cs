using Newtonsoft.Json.Linq;
using System;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 6; i++)
            {
                KanyeQuote();
                SwansonQuote();
                Console.WriteLine();
            }

        }

        public static void KanyeQuote()
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            Console.WriteLine($"Kanye said: {kanyeQuote}");
        }

        public static void SwansonQuote()
        {
            var client = new HttpClient();
            var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var swansonResponse = client.GetStringAsync(swansonURL).Result;
            var swansonQuote = JArray.Parse(swansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            Console.WriteLine($"Swanson said: {swansonQuote}");
        }

    }
}

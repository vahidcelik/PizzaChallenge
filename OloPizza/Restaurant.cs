using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace OloPizza
{
    internal static class Restaurant
    {
        internal static IEnumerable<dynamic> PopularToppingList
        {
            get
            {
                return GetPizzaListOnline() // GetPizzaList()
                    .GroupBy(x => string.Join(", ", x.Toppings))
                    .OrderByDescending(x => x.Count())
                    .Take(20).Select(x => new { x.Key, Value = x.Count() });
            }
        }

        private static IEnumerable<Pizza> GetPizzaList()
        {
            var json = File.ReadAllText("pizzas.json");
            return JsonConvert.DeserializeObject<IEnumerable<Pizza>>(json);
        }

        private static IEnumerable<Pizza> GetPizzaListOnline()
        {
            string json = string.Empty;
            using (var client = new WebClient())
                json = client.DownloadString("http://files.olo.com/pizzas.json");

            return JsonConvert.DeserializeObject<IEnumerable<Pizza>>(json);
        }
    }
}

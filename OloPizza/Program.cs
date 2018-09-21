using System;

namespace OloPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Restaurant.PopularToppingList)
                Console.WriteLine($"{ item.Value } \t: { item.Key}");
            
            Console.ReadKey();
        }


    }
}

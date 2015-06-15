using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Business;

namespace Grosvenor.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;

            Console.WriteLine("Type your dish order or press esc to exit");
            input = Console.ReadLine();

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                if(string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must type something!");
                    continue;
                }
                Restaurant rest = new Restaurant();
                var result = rest.DishOrder(input);
                if (result != null)
                {
                    Console.WriteLine(string.Join(",", result));
                }

                Console.WriteLine("Type your dish order or press esc to exit");
                input = Console.ReadLine();

            }
        }
    }
}

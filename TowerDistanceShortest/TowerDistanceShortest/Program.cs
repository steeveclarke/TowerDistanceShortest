using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDistanceShortest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input your list of co-ordinates: ");
            string inputData = Console.ReadLine();

            var td = new TowerDistance(inputData);

            if (!td.TowerCalculation())
            {
                Console.Write($"Error: {td.ErrorMessage}");
                Console.ReadLine();
            }
            else
            {
                var tdShortest = td.TowerDistanceShortest;

                Console.Write($"{tdShortest.TowerDistanceResultName} are closest to each other");
                Console.ReadLine();
            }
        }
    }
}

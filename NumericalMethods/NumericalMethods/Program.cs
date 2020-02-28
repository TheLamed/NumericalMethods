using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var kramer = new Kramer();

            var matrix = new double[,]
            {
                { 2, 5,  4, 30  },
                { 1, 3,  2, 150 },
                { 2, 10, 9, 110 },
            };
            var list = kramer.Calculate(matrix);
            Console.WriteLine("Розв'язки: " + string.Join(", ", list));
        }
    }
}

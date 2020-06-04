using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    public class Zeidel
    {
        public void Zeid(double[][] A, double epsilon)
        {
            double x = 0, y = 0;
            double norm = 2 * epsilon;
            for (int i = 1; norm >= epsilon; ++i)
            {
                double x1 = (A[0][2] - A[0][1] * y) / A[0][0];
                double y1 = (A[1][2] - A[1][0] * x1) / A[1][1];
                norm = Math.Abs(x1 - x) + Math.Abs(y1 - y);
                x = x1;
                y = y1;
                Console.WriteLine($"Iteration {i}: x = {x,10} y = {y,10}");
            }
        }
    }

}

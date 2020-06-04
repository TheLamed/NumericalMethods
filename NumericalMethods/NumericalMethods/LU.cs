using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    public class LU
    {
        public double[,] LUFactorization(double[,] matrix, out double[,] C)
        {
            double[,] B = new double[matrix.GetLength(0), matrix.GetLength(1)];
            C = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0, j = 2; i < matrix.GetLength(0); i++, j--)
            {
                for (int l = 0; l < i + 1; l++)
                {
                    B[l, 0] = matrix[l, 0];
                    if (i > 0)
                    {
                        double sum = 0;
                        for (int k = 0; k < l; k++)
                        {
                            sum = B[i, k] * C[k, l] + sum;
                        }
                        B[i, l] = matrix[i, l] - sum;
                        sum = 0;
                    }
                }
                for (int l = 0; l < j + 1; l++)
                {
                    C[0, l] = matrix[0, l] / B[0, 0];
                    if (j < 2)
                    {
                        for (int m = 2; m > i - 1; m--)
                        {
                            double sum = 0;
                            for (int k = 0; k < i; k++)
                            {
                                sum = B[i, k] * C[k, m] + sum;
                            }
                            C[i, m] = (1 / B[i, i]) * (matrix[i, m] - sum);
                            sum = 0;
                        }
                    }
                }
            }
            return B;
        }
    }
}

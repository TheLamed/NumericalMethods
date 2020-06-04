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
            //KRAMER
            //var kramer = new Kramer();

            //var matrix = new double[,]
            //{
            //    { 2, 5,  4, 30  },
            //    { 1, 3,  2, 150 },
            //    { 2, 10, 9, 110 },
            //};
            //var list = kramer.Calculate(matrix);
            //Console.WriteLine("Розв'язки: " + string.Join(", ", list));

            //GAUSS
            //GausMethod Solution = new GausMethod(3, 3);

            //var matrix = new double[,]
            //{
            //    { 2, 5,  4, 30  },
            //    { 1, 3,  2, 150 },
            //    { 2, 10, 9, 110 },
            //};

            //Solution.RightPart[0] = matrix[0, 3];
            //Solution.RightPart[1] = matrix[1, 3];
            //Solution.RightPart[2] = matrix[2, 3];
            //for (int i = 0; i < 3; i++)
            //    for (int j = 0; j < 3; j++)
            //        Solution.Matrix[i][j] = matrix[i, j];

            //Solution.SolveMatrix();

            //Console.WriteLine(Solution.Answer[0] + ", " + Solution.Answer[1] + ", " + Solution.Answer[2]);

            //LU
            var LU = new LU();

            double[,] Arr = 
            { 
                {2, 5,  4},
                {1, 3,  2},
                {2, 10, 9}
            };

            double[,] C1;
            Arr = LU.LUFactorization(Arr, out C1);
            Show(Arr);
            Console.WriteLine();
            Show(C1);
            Console.ReadKey();
        }

        private static void Show(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("\t");
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

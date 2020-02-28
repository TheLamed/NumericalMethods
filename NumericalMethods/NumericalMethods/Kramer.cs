using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    public class Kramer
    {
        public double Delta(double[,] matrix)
        {
            var length = matrix.GetLength(0);

            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new WrongMatrixException("Matrix is not square!");

            if (matrix.GetLength(0) == 1)
                return matrix[0, 0];

            double sum = 0;

            for (int k = 0; k < length; k++)
            {
                var tmp = CreateMatrix(length - 1);

                int c = 0;

                for (int i = 0; i < length; i++)
                {
                    if (k == i)
                        continue;

                    for (int j = 0; j < length - 1; j++)
                        tmp[c, j] = matrix[i, j + 1];

                    c++;
                }

                if (k % 2 == 0)
                    sum += matrix[k, 0] * Delta(tmp);
                else
                    sum -= matrix[k, 0] * Delta(tmp);
            }

            return sum;
        }

        public List<double> Calculate(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) - 1)
                throw new WrongMatrixException("Matrix is not valid!");

            var length = matrix.GetLength(0);
            var delt = CreateMatrix(length);
            var free = new double[length];
            var list = new List<double>(length);

            for (int i = 0; i < length; i++)
                free[i] = matrix[i, length];

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    delt[i, j] = matrix[i, j];

            var delta = Delta(delt);

            for (int i = 0; i < length; i++)
            {
                var newMatrix = PutColumn(delt, free, i);
                var d = Delta(newMatrix);
                list.Add(d / delta);
            }

            return list;
        }

        private double[,] PutColumn(double[,] matrix, double[] column, int position)
        {
            var output = matrix.Clone() as double[,];

            for (int i = 0; i < column.Length; i++)
                output[i, position] = column[i];

            return output;
        }
        private double[,] CreateMatrix(int N)
        {
            return new double[N, N];
        }

    }

    #region Exceptions
    [Serializable]
    public class WrongMatrixException : Exception
    {
        public WrongMatrixException() { }
        public WrongMatrixException(string message) : base(message) { }
        public WrongMatrixException(string message, Exception inner) : base(message, inner) { }
        protected WrongMatrixException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    #endregion
}

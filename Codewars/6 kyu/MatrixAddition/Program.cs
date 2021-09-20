using System;

namespace Codewars.Six.MatrixAddition
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var matrix = MatrixAddition(Array.Empty<int[]>(), Array.Empty<int[]>());
        }

        public static int[][] MatrixAddition(int[][] a, int[][] b)
        {
            var length = a.Length;
            var resultMatrix = new int[length][];
            for (var i = 0; i < length; i++)
            {
                resultMatrix[i] = new int[length];
                for (var j = 0; j < length; j++)
                {
                    resultMatrix[i][j] = a[i][j] + b[i][j];
                }
            }
            return resultMatrix;
        }
    }
}
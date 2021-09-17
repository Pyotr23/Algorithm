using System;
using System.Numerics;

namespace Corewars.Five.OperationsOnSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 2, 1, 3, 4 };
            // var arr = new[] {21, 24, 15, 22, 1, 2};
            // var arr = new[] {5, 4, 4, 5, 5, 4, 2, 4, 7, 6, 5, 9, 8, 7, 6, 5, 4, 9, 6, 5, 7, 9, 5, 8, 9, 6, 8, 4, 9, 2, 5, 5, 3, 9, 7, 9, 2, 6, 3, 2};
            Console.WriteLine(solve(arr));
        }
        
        public static BigInteger[] solve(int[] arr) {
            var a = BigInteger.One;
            var b = BigInteger.Zero;
            for (var i = 0; i < arr.Length; i += 2)
            {
                var temp = a;
                a = BigInteger.Abs(arr[i] * a + arr[i + 1] * b);
                b = BigInteger.Abs(arr[i + 1] * temp - arr[i] * b);
            }
            return new[]{a,b};
        }
    }
}
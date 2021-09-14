using System;
using System.Linq;

namespace Codewars.Six.LastDigitSymmetry
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve(1, 1200));
        }

        private static int Solve(int min, int max) 
            => Enumerable
                .Range(min,max-min)
                .Count(x => Satisfies(x));
        
        private static bool Satisfies(long x) 
            => LastTwo(x*x) == LastTwo(x) 
               && IsTwoDigitPrime(FirstTwo(x)) 
               && IsTwoDigitPrime(FirstTwo(x*x));

        private static long FirstTwo(long x)
        {
            while (x >= 100) 
                x /= 10;
            return x;
        }
        
        private static long LastTwo(long x) => x % 100;
        
        private static bool IsTwoDigitPrime(long x) 
            =>  !(x <= 10 
                  || x % 2 == 0 
                  || x % 3 == 0 
                  || x % 5 == 0 
                  || x % 7 == 0); 
    }
}
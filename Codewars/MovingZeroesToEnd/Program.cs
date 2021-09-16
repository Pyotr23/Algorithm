using System;
using System.Linq;

namespace Corewars.Five.MovingZeroesToEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                string.Join("--", 
                    MoveZeroes(new[] { 0, 0, 0, 0, 3 }))); 
        }
        
        public static int[] MoveZeroes(int[] arr)
        {
            if (arr.Length is 0 or 1)
                return arr;

            var result = new int[arr.Length];
            
            for (int i = 0, j = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    continue;

                result[j] = arr[i];
                j++;
            }

            return result;
        }
    }
}
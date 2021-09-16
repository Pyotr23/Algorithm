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
            
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    continue;
                
                if (arr[i - 1] == 0)
                    SwapWithPrevious(arr, i);
            }

            return arr;
        }

        private static void SwapWithPrevious(int[] array, int index)
        {
            var temp = array[index];
            array[index] = array[index - 1];
            array[index - 1] = temp;

            if (index - 2 >= 0 && array[index - 2] == 0)
                SwapWithPrevious(array, index - 1);
        }
    }
}
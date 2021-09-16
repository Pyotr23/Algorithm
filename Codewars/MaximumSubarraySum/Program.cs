using System;

namespace MaximumSubarraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxSequence(new []{-2, 1, -3, 4, -1, 2, 1, -5, 4}));
        }
        
        public static int MaxSequence(int[] arr)
        {
            var sum = 0;
            var max = 0;

            foreach(var element in arr)
            {
                sum += element;
                if (sum < 0)
                {
                    sum = 0;
                    continue;
                }

                if (sum > max)
                    max = sum;
            }

            return max;
        }
    }
}
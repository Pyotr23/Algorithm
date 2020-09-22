using System;
using System.Linq;

namespace Easy
{
    public class Easy_1480_running_sum_of_1d_array
    {
        //static void Main(string[] args)
        //{
        //    var arr = new int[] { 3, 1, 2, 10, 1 };            
        //    Console.WriteLine(string.Join(", ", RunningSum(arr)));
        //    Console.ReadKey();
        //}

        public static int[] RunningSum(int[] nums)
        {
            var curr = 0;
            return nums
                .Select(num => curr += num)
                .ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    class Easy_852_peak_index_in_a__mountain_array
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 2, 1, 0 };
            Console.WriteLine(PeakIndexInMountainArray(array));
            Console.ReadKey();
        }

        public static int PeakIndexInMountainArray(int[] A)
        {
            int i = 0;
            for (; i < A.Length; i++)
            {
                if (A[i] > A[i + 1])
                    return i;
            }
            return i;
        }
    }
}

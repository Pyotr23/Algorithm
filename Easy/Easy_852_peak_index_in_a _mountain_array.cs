using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    class Easy_852_peak_index_in_a__mountain_array
    {
        //static void Main(string[] args)
        //{
        //    int[] array = { 3, 4, 5, 1 };
        //    Console.WriteLine(PeakIndexInMountainArray(array));
        //    Console.ReadKey();
        //}

        public static int PeakIndexInMountainArray(int[] A)
        {            
            int startIndex = 0;
            int endIndex = A.Length - 1;
            int middleIndex = (endIndex - startIndex) / 2;
            while (true)
            {
                if (A[middleIndex] > A[middleIndex - 1])
                {
                    if (A[middleIndex] > A[middleIndex + 1])
                        return middleIndex;
                    startIndex = middleIndex;
                    middleIndex += (endIndex - startIndex) / 2;
                    continue;
                }
                endIndex = middleIndex;
                middleIndex -= (endIndex - startIndex) / 2;
                continue;
            }            
        }

        public static int PeakIndexInMountainArrayBrutalForce(int[] A)
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

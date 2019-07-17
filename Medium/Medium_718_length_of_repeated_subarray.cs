using System;
using System.Collections.Generic;

namespace Medium
{
    class Medium_718_length_of_repeated_subarray
    {
        static void Main(string[] args)
        {
            //int[] firstArray = new int[] { 1, 2, 3, 2, 1 };
            //int[] secondArray = new int[] { 3, 2, 1, 4, 7 };
            int[] firstArray = new int[] { 3, 2, 4, 2, 5, 8 };
            int[] secondArray = new int[] { 8, 5, 2, 5, 8 };
            int answear = FindLength(firstArray, secondArray);
            Console.WriteLine(answear);
            Console.ReadKey();
        }

        static int FindLength(int[] A, int[] B)
        {
            int answear = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    int currentLength = 0;
                    while (((i + currentLength) < A.Length) 
                        && ((j + currentLength) < B.Length)
                        && (A[i + currentLength] == B[j + currentLength]))
                    {
                        currentLength++;
                        answear = Math.Max(answear, currentLength);
                    }                        
                }
            }
            return answear;
        }
    }
}

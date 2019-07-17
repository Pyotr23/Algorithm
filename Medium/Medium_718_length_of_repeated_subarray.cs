using System;
using System.Collections.Generic;

namespace Medium
{
    class Medium_718_length_of_repeated_subarray
    {
        static void Main(string[] args)
        {
            int[] firstArray = new int[] { 1, 2, 3, 2, 1 };

            Console.WriteLine("Hello World!");
        }

        static int FindLength(int[] A, int[] B)
        {
            int answear = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    int currentLength = 0;
                    while (A[i + currentLength] == B[i + currentLength])
                        answear = Math.Max(answear, currentLength);
                }
            }
            return answear;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Medium
{
    class Medium_718_length_of_repeated_subarray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int FindLength(int[] A, int[] B)
        {
            Dictionary<int, int> dictionaryA = new Dictionary<int, int>();
            int maxLength = 0;
            int currentLength = 0;
            int indexInA = 0;
            for (int i = 0; i < A.Length; i++)
            {
                dictionaryA.Add(A[i], i);
            }
            for (int i = 0; i < B.Length; i++)
            {                
                if (!dictionaryA.ContainsKey(B[i]))
                {
                    currentLength = 0;
                    continue;
                }      
                indexInA = 
                if (currentLength == 0)
                {
                    currentLength++;
                    continue;
                }

            }
        }
    }
}

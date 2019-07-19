using System;
using System.Collections.Generic;
using System.Linq;

namespace Medium
{
    class Medium_718_length_of_repeated_subarray
    {
        static void Main(string[] args)
        {
            //int[] firstArray = new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 1, 1 };
            //int[] secondArray = new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 0, 0 };
            //int[] firstArray = new int[] { 1, 2, 3, 2, 1 };
            //int[] secondArray = new int[] { 3, 2, 1, 4, 7 };
            int[] firstArray = new int[] { 3, 2, 4, 2, 5, 8 };
            int[] secondArray = new int[] { 8, 5, 2, 5, 8 };
            //int[] firstArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //int[] secondArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //    0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
            //int[] firstArray = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
            //int[] secondArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };            
            int answear = FindLength(firstArray, secondArray);
            Console.WriteLine(answear);
            Console.ReadKey();
        }

        static int FindLength(int[] A, int[] B)
        {
            int ans = 0;
            int[,] memo = new int[A.Length + 1, B.Length + 1];
            for (int i = A.Length - 1; i >= 0; --i)
            {
                for (int j = B.Length - 1; j >= 0; --j)
                {
                    if (A[i] == B[j])
                    {
                        memo[i, j] = memo[i + 1, j + 1] + 1;
                        if (ans < memo[i, j])
                            ans = memo[i, j];
                    }
                }
            }
            return ans;
        }

        static int FindLengthBinarySearch(int[] A, int[] B)
        {
            int lo = 0;
            int hi = Math.Min(A.Length, B.Length) + 1;
            while (lo < hi)
            {
                int middle = (lo + hi) / 2;
                if (Check(middle, A, B))
                    lo = middle + 1;
                else
                    hi = middle;
            }
            return lo - 1;
        }

        static bool Check(int length, int[] A, int[] B)
        {
            HashSet<string> hashSet = new HashSet<string>();
            for (int i = 0; i + length <= A.Length; ++i)
            {
                int[] subarray = A.Skip(i).Take(length).ToArray();                
                string arrayToString = string.Join("", subarray);
                hashSet.Add(arrayToString);                
            }

            for (int j = 0; j + length <= B.Length; ++j)
            {
                int[] subarray = B.Skip(j).Take(length).ToArray();
                string bSubArraytoString = string.Join("", subarray);
                if (hashSet.Contains(bSubArraytoString))
                    return true;
            }
            return false;
        }

        static int FindLengthBruteForceWithHashTable(int[] A, int[] B)
        {            
            Dictionary<int, List<int>> dictionaryB = new Dictionary<int, List<int>>();
            for (int i = 0; i < B.Length; i++)
            {
                if (!dictionaryB.ContainsKey(B[i]))
                    dictionaryB.Add(B[i], new List<int> { i });
                else
                {
                    List<int> currentList = dictionaryB[B[i]];
                    currentList.Add(i);
                    dictionaryB[B[i]] = currentList;
                }
            }

            int answear = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (dictionaryB.ContainsKey(A[i]))
                {
                    List<int> indexesList = dictionaryB[A[i]];
                    for (int x = 0; x < indexesList.Count; x++)
                    {                         
                        for (int j = indexesList[x]; j < B.Length; j++)
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
                }                
            }
            return answear;
        }

        // потерпел фиаско
        static int FindLengthBad(int[] A, int[] B)
        {
            int answear = 0;
            Dictionary<int, List<int>> dictionaryB = new Dictionary<int, List<int>>();
            for (int i = 0; i < B.Length; i++)
            {
                if (!dictionaryB.ContainsKey(B[i]))
                    dictionaryB.Add(B[i], new List<int> { i });
                else
                {
                    List<int> currentList = dictionaryB[B[i]];
                    currentList.Add(i);
                    dictionaryB[B[i]] = currentList;
                }                    
            }

            foreach (var key in dictionaryB.Keys)
            {
                List<int> list = dictionaryB[key];
                for (int j = 1, shift = 1; j < list.Count;)
                {
                    if (list[j] - list[j - 1] == shift)
                    {
                        list.RemoveAt(j);
                        shift++;
                        continue;
                    }
                    shift = 1;
                    j++;
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (!dictionaryB.ContainsKey(A[i]))
                {
                    //i++;
                    continue;
                }
                int delta = 0;   
                List<int> indexesList = dictionaryB[A[i]];
                for (int j = 0; j < indexesList.Count; j++)
                {
                    int startIndexInB = indexesList[j];
                    int currentLength = 0;
                    while (((i + currentLength) < A.Length)
                        && ((startIndexInB + currentLength) < B.Length)
                        && (A[i + currentLength] == B[startIndexInB + currentLength]))
                    {
                        currentLength++;
                    }
                    delta = Math.Max(delta, currentLength);
                    answear = Math.Max(answear, currentLength);                    
                }                
                //i += delta > 1 ? delta : 1;
            }
            return answear;
        }

        static int FindLengthBruteForce(int[] A, int[] B)
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

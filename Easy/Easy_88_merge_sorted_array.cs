using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    class Easy_88_merge_sorted_array
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 0 };
            int[] nums2 = { 1 };
            Merge(nums1, 0, nums2, 1);
            foreach (int x in nums1)
                Console.Write(x + " ");
            Console.ReadKey();
        }
        
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;                          
            for (int i = m, j = 0; i < nums1.Length; i++, j++)
            {
                nums1[i] = nums2[j];
            }            
            Array.Sort(nums1);                     
        }

        public static List<int> GetListFromArray(int[] array, int listCount)
        {
            var list = new List<int>();
            for (int i = 0; i < listCount; i++)
            {
                list.Add(array[i]);
            }
            return list;
        }
    }
}

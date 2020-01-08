using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    class Easy_88_merge_sorted_array
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 2, 5, 6 };
            //Merge(nums1, 3, nums2, 3);
            foreach (int x in nums1)
                Console.Write(x + " ");
            Console.ReadKey();
        }

        public static void FastestMerge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = 0;
            int j = 0;
            while (j < n)
            {
                if (nums2[j] < nums1[i])
                {
                    int k = m - 1;      // Индекс последнего проинициализированного элемента в изначальном nums1.
                    while (k >= i)      // Сдвиг всех значений с i по k.
                    {
                        nums1[k + 1] = nums1[k];
                        k--;
                    }
                    nums1[i] = nums2[j];
                    m++;
                    i++;
                    j++;
                    continue;
                }

                if (m <= i)
                {
                    nums1[i] = nums2[j];
                    j++;
                }
                i++;
            }
        }

        public static void MyMerge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;                          
            for (int i = m, j = 0; i < nums1.Length; i++, j++)
            {
                nums1[i] = nums2[j];
            }            
            Array.Sort(nums1);                     
        }
    }
}

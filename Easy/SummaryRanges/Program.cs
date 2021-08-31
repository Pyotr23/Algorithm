using System.Collections.Generic;

namespace Easy.SummaryRanges
{
    internal class Program
    {
        internal static void Main()
        {
        }
        
        internal static IList<string> MyVersionSummaryRanges(int[] nums)
        {
            var list = new List<string>();
            
            switch (nums.Length)
            {
                case 0:
                    return list;
                case 1:
                    list.Add(nums[0].ToString());
                    return list;
            }

            var tempString = nums[0].ToString();
            var next = nums[0] + 1;
            var start = nums[0];
            var current = 0;

            for (var i = 1; i < nums.Length; i++)
            {
                current = nums[i];

                if (next == current)
                {
                    next = current + 1;
                    continue;
                }

                if (!(start == current ||  start == nums[i - 1]))
                    tempString += $"->{nums[i - 1]}";

                list.Add(tempString);

                tempString = current.ToString();
                start = current;
                next = current + 1;
            }
            
            if (start != current)
                tempString += $"->{current}";

            list.Add(tempString);

            return list;
        }
        
        internal static IList<string> SummaryRanges(int[] nums)
        {
            var summary = new List<string>();
            
            // i отвечает за начальное значение, j бежит по массиву
            for (int i = 0, j = 0; j < nums.Length; j++) 
            {
                if (j + 1 < nums.Length && nums[j + 1] == nums[j] + 1)
                    continue;
                
                if (i == j)
                    summary.Add(nums[i].ToString());
                else
                    summary.Add(nums[i] + "->" + nums[j]);
                
                i = j + 1;
            }
            return summary;
        }
    }
}
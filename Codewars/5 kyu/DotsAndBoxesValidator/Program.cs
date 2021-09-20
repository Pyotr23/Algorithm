using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Five.DotsAndBoxesValidator
{
    internal static class Program
    {
        static void Main(string[] args)
        {
        }
        
        public static int[] DotsAndBoxes(int[][] r)
        {
            int n = (int)Math.Round(Math.Sqrt(r.Max(x => x.Max()) + 1));
            int[,] boxes = new int[n + 1, n + 1];
            int player = 1;
            foreach (var a in r)
            {
                bool oneMore = false;
                int rowFrom = a.Min() / n;
                int colFrom = a.Min() % n;
                int rowTo = a.Max() / n;
                int colTo = a.Max() % n;
                if (rowFrom == rowTo)
                {
                    boxes[rowFrom, colFrom + 1]++;
                    if (boxes[rowFrom, colFrom + 1] == 4) { boxes[rowFrom, colFrom + 1] = -player; oneMore = true; }
                    boxes[rowFrom + 1, colFrom + 1]++;
                    if (boxes[rowFrom + 1, colFrom + 1] == 4) { boxes[rowFrom + 1, colFrom + 1] = -player; oneMore = true; }
                }
                else
                {
                    boxes[rowFrom + 1, colFrom]++;
                    if (boxes[rowFrom + 1, colFrom] == 4) { boxes[rowFrom + 1, colFrom] = -player; oneMore = true; }
                    boxes[rowFrom + 1, colFrom + 1]++;
                    if (boxes[rowFrom + 1, colFrom + 1] == 4) { boxes[rowFrom + 1, colFrom + 1] = -player; oneMore = true; }
                }
                if (!oneMore)
                    player = 3 - player;
            }
            int sum1 = 0, sum2 = 0;
            for (int i = 1; i < n; i++)
            for (int j = 1; j < n; j++) if (boxes[i, j] == -1) sum1++; else sum2++;
            return new int[] { sum1, sum2 };
        }
    }
}
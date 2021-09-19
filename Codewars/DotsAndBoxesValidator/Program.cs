using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Five.DotsAndBoxesValidator
{
    internal static class Program
    {
        private struct Box
        {
            private List<int[]> Sizes { get; };  
            
            private Box(int upperLeftCorner, int upperRightCorner, int lowerLeftCorner, int lowerRightCorner)
            {
                Sizes = new List<int[]>
                {
                    new[] {upperLeftCorner, upperRightCorner},
                    new[] {upperRightCorner, lowerRightCorner},
                    new[] {lowerLeftCorner, lowerRightCorner},
                    new[] {upperLeftCorner, lowerLeftCorner}
                };
            }
        }
        
        static void Main(string[] args)
        {
            var moves = new[]
            {
                new[]{0,1}, 
                new[]{7,8}, 
                new[]{1,2}, 
                new[]{6,7}, 
                new[]{0,3},
                new[]{8,5}, 
                new[]{3,4}, 
                new[]{4,1}, 
                new[]{4,5}, 
                new[]{2,5}, 
                new[]{7,4}, 
                new[]{3,6}
            };
            Console.WriteLine(GetBoardSize(moves));
        }
        
        public static int[] DotsAndBoxes(int[][] r)
        {
            return null;
        }

        private static int GetBoardSize(IEnumerable<int[]> moves)
        {
            var max = moves
                .SelectMany(m => m)
                .Max();
            return (int) Math.Sqrt(max + 1);
        }
    }
}
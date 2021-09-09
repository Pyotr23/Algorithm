using System.Collections.Generic;
using System.Linq;

namespace Codewars.Five.DirectionsReduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = dirReduc(new[] {"NORTH", "WEST", "SOUTH", "EAST"});
            // var result = dirReduc(new[] {"NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"});
        }
        
        public static string[] dirReduc(string[] arr)
        {
            var directions = new Dictionary<string, string>
            {
                {"NORTH", "SOUTH"},
                {"SOUTH", "NORTH"},
                {"WEST", "EAST"},
                {"EAST", "WEST"}
            };
            
            var stack = new Stack<string>();
            
            foreach (var direction in arr)
            {
                if (stack.Count == 0)
                {
                    stack.Push(direction);
                    continue;
                }
                
                var oppositeDirection = directions[direction];
                 
                if (stack.Peek() == oppositeDirection)
                {
                    stack.Pop();
                    continue;
                }
                
                stack.Push(direction);
            }

            return stack.Reverse().ToArray();
        }
    }
}
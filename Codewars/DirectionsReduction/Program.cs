using System.Collections.Generic;
using System.Linq;

namespace Codewars.Five.DirectionsReduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = dirReduc(new[] {"NORTH", "WEST", "SOUTH", "EAST"});
            result = dirReduc(new[] {"NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"});
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

            var list = new LinkedList<string>();
            
            foreach (var direction in arr)
            {
                if (list.Count == 0)
                {
                    
                    list.AddLast(direction);
                    continue;
                }
                
                var oppositeDirection = directions[direction];
                 
                if (list.Last?.Value == oppositeDirection)
                {
                    list.RemoveLast();
                    continue;
                }
                
                list.AddLast(direction);
            }

            return list.ToArray();
        }
    }
}
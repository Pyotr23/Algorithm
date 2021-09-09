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
            
            var list = new List<string>();
            
            foreach (var direction in arr)
            {
                if (list.Count == 0)
                {
                    
                    list.Add(direction);
                    continue;
                }
                
                var oppositeDirection = directions[direction];
                 
                if (list.Last() == oppositeDirection)
                {
                    list.RemoveAt(list.Count - 1);
                    continue;
                }
                
                list.Add(direction);
            }

            return list.ToArray();
        }
    }
}
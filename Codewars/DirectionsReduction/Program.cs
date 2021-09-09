using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Five.DirectionsReduction
{
    class Program
    {
        static void Main(string[] args)
        {
            dirReduc(new[] {"NORTH", "WEST", "SOUTH", "EAST"});
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
            var dictionary = new Dictionary<string, List<int>>();
            for (var i = 0; i < arr.Length; i++)
            {
                var direction = arr[i];
                var oppositeDirection = directions[direction];
                if (dictionary.ContainsKey(oppositeDirection))
                {
                    var oppositeIndexes = dictionary[oppositeDirection];
                    oppositeIndexes.RemoveAt(0);
                }
                
                if (dictionary.ContainsKey(direction))
                {
                    var indexes = dictionary[direction];
                    indexes.Add(i);
                }
                else
                {
                    dictionary.Add(direction, new List<int> { i });
                }
            }

            return null;
        }
    }
}
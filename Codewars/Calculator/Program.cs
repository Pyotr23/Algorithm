using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Three.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // const string example = "2 / 2 + 3 * 4 - 6";
            const string example = "2 / 2 + 3 * 4 - 6";
            Evaluate(example);
            Console.WriteLine("Hello World!");
        }
        
        public static double Evaluate(string expression)
        {
            var operations = new[] {'/', '*', '+', '-'};
            expression = string.Concat(expression.Split(' '));
            var priorityOperations = expression
                .Split('+', '-')
                .Where(o => o.Any(s => operations.Contains(s)))
                .ToArray();
            for (var i = 0; i < priorityOperations.Length; i++)
            {
                var operation = priorityOperations[i];
                if (operation.Contains('/'))
                {
                    var numbers = operation
                        .Split('/')
                        .Select(int.Parse)
                        .ToArray();
                    var result = numbers[0] / numbers[1];
                    expression = expression.Replace(operation, result.ToString());
                }
                else
                {
                    var numbers = operation
                        .Split('*')
                        .Select(int.Parse)
                        .ToArray();
                    var result = numbers[0] * numbers[1];
                    expression = expression.Replace(operation, result.ToString());
                }
            }
            var stack = new Stack<char>();
            // foreach (var letter in expression)
            // {
            //     // if (!operations.Contains(letter))
            //     // {
            //     //     stack
            //     // }
            //     if (letter == '*' || letter == '/')
            //         
            //     if (operations.Contains(letter))
            //         operationSequence.Push(letter);
            // }

            return 0;
        }
        
        
    }
}
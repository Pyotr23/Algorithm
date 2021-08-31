using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy._682_baseball_game
{
    class Easy_682_baseball_game
    {
        //static void Main(string[] args)
        //{
        //    var arr = new string[] { "5", "-2", "4", "C", "D", "9", "+", "+" };
        //    Console.WriteLine(CalPoints(arr));
        //    Console.ReadKey();
        //}

        public static int CalPoints(string[] ops)
        {
            var sum = 0;
            var stack = new Stack<int>();
            int newValue;
            foreach (var operation in ops)
            {
                switch (operation)
                {
                    case "+":
                        int lastValue = stack.Pop();
                        newValue = lastValue + stack.Peek();
                        sum += newValue;
                        stack.Push(lastValue);
                        stack.Push(newValue);
                        break;
                    case "D":
                        newValue = stack.Peek() * 2;
                        stack.Push(newValue);
                        sum += newValue;
                        break;
                    case "C":                        
                        sum -= stack.Pop();
                        break;
                    default:
                        newValue = int.Parse(operation);
                        stack.Push(newValue);
                        sum += newValue;
                        break;
                }
            }
            return sum;
        }
    }
}

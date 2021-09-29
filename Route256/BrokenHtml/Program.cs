using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Route256.FourStar.BrokenHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            const string openedTagPattern = "^<[^/][A-Z]*>$";
            var openedTagRegex = new Regex(openedTagPattern);
            
            const string closedTagPattern ="^</[A-Z]*>$";
            var closedTagRegex = new Regex(closedTagPattern);

            // var queue = new Queue<string>(new string[] { "1", "4", "<X>", "<Y>", "</Y>", "</X>" });
            // var queue = new Queue<string>(new string[] { "1", "5", "<HTML>", "<biba>", "</BIBA>", "</KUKA>", "</HTML>" });
            var queue = new Queue<string>(new string[] { "1", "6", "<HTML>", "<TAG>", "<button>", "</BUTTON>", "<TAG>", "</HTML>" });

            var setCount = int.Parse(queue.Dequeue());
            for (var i = 0; i < setCount; i++)
            {
                var tagCount = int.Parse(queue.Dequeue());
                var stack = new Stack<string>();
                var errorCount = 0;
                var errorTag = string.Empty;
                for (var j = 0; j < tagCount; j++)
                {
                    var tag = queue.Dequeue().ToUpper();

                    if (openedTagRegex.IsMatch(tag))
                    {
                        stack.Push(tag);
                        continue;
                    }

                    if (!closedTagRegex.IsMatch(tag))
                    {
                        if (++errorCount > 1)
                            break;
                        continue;
                    }

                    var lastOpenedTag = stack.Pop();
                    if (lastOpenedTag.Insert(1, "/") == tag)
                        continue;

                    if (++errorCount > 1)
                        break;

                    string penultimateOpenedTag;
                    if (!stack.TryPeek(out penultimateOpenedTag))
                    {
                        errorTag = tag;
                        stack.Push(lastOpenedTag);
                        continue;
                    }
                    
                        

                    if (penultimateOpenedTag.Insert(1, "/") == tag)
                    {
                        errorTag = penultimateOpenedTag;
                        continue;
                    }

                    errorTag = lastOpenedTag;
                    stack.Push(lastOpenedTag);
                }

                if (stack.Count == 0 && errorCount == 0)
                {
                    Console.WriteLine("CORRECT");
                    continue;
                }
                 
                if (stack.Count == 0 && errorCount == 1)
                {
                    Console.WriteLine("ALMOST " + errorTag);
                    continue;
                }
                
                Console.WriteLine("INCORRECT");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Route256.FourStar.BrokenHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // var queue = new Queue<string>(new string[] { "1", "4", "<X>", "<Y>", "</Y>", "</X>" });
            // var queue = new Queue<string>(new string[] { "1", "5", "<HTML>", "<biba>", "</BIBA>", "</KUKA>", "</HTML>" });
            // var queue = new Queue<string>(new string[] { "1", "6", "<HTML>", "<TAG>", "<button>", "</BUTTON>", "<TAG>", "</HTML>" });
            // var queue = new Queue<string>(new string[] { "1", "1", "<HTML>" });
            // var queue = new Queue<string>(new string[] { "1", "5", "</KUKA>", "<HTML>", "<biba>", "</BIBA>", "</HTML>" });
            var queue = new Queue<string>(new string[] { "1", "5", "<X>", "<Y>", "</X>", "</Y>", "</X>" });

            var setCount = int.Parse(queue.Dequeue());
            for (var i = 0; i < setCount; i++)
            {
                var tagCount = int.Parse(queue.Dequeue());
                var stack = new Stack<string>();
                var errorCount = 0;
                var errorTag = string.Empty;
                for (var j = 0; j < tagCount; j++)
                {
                    if (errorCount > 1)
                        break;
                    
                    var tag = queue.Dequeue().ToUpper();

                    if (!tag.StartsWith("</"))
                    {
                        stack.Push(tag);
                        continue;
                    }

                    string lastTag;
                    if (!stack.TryPeek(out lastTag))
                    {
                        errorTag = tag;
                        errorCount++;
                        continue;
                    }
                    
                    stack.Pop();

                    if (lastTag == tag.Remove(1, 1))
                        continue;

                    errorCount++;
                    
                    string penultimateOpenedTag;
                    if (stack.TryPeek(out penultimateOpenedTag) && penultimateOpenedTag == tag.Remove(1, 1))
                    {
                        errorTag = lastTag;
                        stack.Pop();
                        continue;
                    }
                    
                    stack.Push(lastTag);
                    errorTag = tag;
                }

                if (stack.Count == 0 && errorCount == 0)
                {
                    Console.WriteLine("CORRECT");
                    continue;
                }
                 
                if (stack.Count + errorCount == 1)
                {
                    if (stack.Count == 1)
                        errorTag = stack.Pop();
                    Console.WriteLine("ALMOST " + errorTag);
                    continue;
                }
                
                Console.WriteLine("INCORRECT");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Medium_1019_next_greater_node_in_linked_list
    {
        static void Main(string[] args)
        {
            var listNode = new ListNode(1)
            {
                next = new ListNode(7)
                {
                    next = new ListNode(5)
                    {
                        next = new ListNode(1)
                        {
                            next = new ListNode(9)
                            {
                                next = new ListNode(2)
                                {
                                    next = new ListNode(5)
                                    {
                                        next = new ListNode(1)
                                    }
                                }
                            }
                        }
                    }
                }
            };
            NextLargerNodes(listNode);
            Console.ReadKey();            
        }

        private static int[] NextLargerNodes(ListNode head)
        {
            List<int> answearList = new List<int>();
            while (head != null)
            {
                var currentList = head;
                int max = 0;
                while (currentList != null)
                {
                    max = Math.Max(max, currentList.val);
                    currentList = currentList.next;
                }
                head = head.next;
                answearList.Add(max);
            }
            return answearList.ToArray();
        }
    }
}

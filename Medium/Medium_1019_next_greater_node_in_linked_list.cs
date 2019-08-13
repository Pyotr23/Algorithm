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
            var listNode = new ListNode(9)
            {
                next = new ListNode(7)
                {
                    next = new ListNode(6)
                    {
                        next = new ListNode(7)
                        {
                            next = new ListNode(6)
                            {
                                next = new ListNode(9)
                                //{
                                //    next = new ListNode(5)
                                //    {
                                //        next = new ListNode(1)
                                //    }
                                //}
                            }
                        }
                    }
                }
            };
            int[] array = NextLargerNodes(listNode);
            foreach(var x in array)
                Console.Write(x);
            Console.ReadKey();            
        }

        private static int[] NextLargerNodes(ListNode head)
        {
            List<int> answearList = new List<int>();
            int prevHeadValue = 0;
            int nextMax = 0;
            while (head != null)
            {
                var currentList = head;
                int localMax = 0;
                int first = currentList.val;
                if (localMax == 0 || localMax == first)
                {
                    while (currentList != null)
                    {
                        if (currentList.val > first)
                        {
                            localMax = currentList.val;
                            break;
                        }
                        //if (currentList.next != null && currentList.next.val )
                        currentList = currentList.next;
                    }
                }                
                head = head.next;
                answearList.Add(localMax == first ? 0 : localMax);
            }
            return answearList.ToArray();
        }

        private static int[] NextLargerNodesMemory(ListNode head)
        {
            List<int> answearList = new List<int>();
            while (head != null)
            {
                var currentList = head;
                int max = 0;
                int first = currentList.val;
                while (currentList != null)
                {
                    if (currentList.val > first)
                    {
                        max = currentList.val;
                        break;
                    }
                    currentList = currentList.next;
                }
                head = head.next;
                answearList.Add(max == first ? 0 : max);
            }
            return answearList.ToArray();
        }
    }
}

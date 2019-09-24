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
        //static void Main(string[] args)
        //{            
        //    var listNode = GetListNode(new List<int>() { 2, 7, 4, 3, 5 });
        //    int[] answear = NextLargerNodes(listNode);
        //    foreach(var x in answear)
        //        Console.Write($"{x} ");
        //    Console.ReadKey();            
        //}

        private static int[] NextLargerNodes(ListNode head)
        {
            List<int> answearList = new List<int>();
            var increasingListNode = GetIncreasingListNode(head);
            int prev = int.MaxValue;
            while (head != null)
            {                
                int max = 0;
                if (increasingListNode != null)
                {
                    if (increasingListNode.val == head.val && increasingListNode.val > prev)
                        increasingListNode = increasingListNode.next;
                    var currentIncreasing = increasingListNode;
                    while (currentIncreasing != null)
                    {
                        if (currentIncreasing.val > head.val)
                        {
                            max = currentIncreasing.val;
                            break;
                        }
                        currentIncreasing = currentIncreasing.next;
                    }
                }
                prev = head.val;
                head = head.next;
                answearList.Add(max);
            }
            return answearList.ToArray();
        }

        private static ListNode GetIncreasingListNode(ListNode lNode)
        {
            var tempListNode = lNode;
            var nodesList = new List<int>();
            while (tempListNode.next != null)
            {
                if (tempListNode.next.val > tempListNode.val)
                    nodesList.Add(tempListNode.next.val);
                tempListNode = tempListNode.next;
            }
            return GetListNode(nodesList);
        }        

        // Решение с минимальным использованием памяти, но очень медленное
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

        private static ListNode GetListNode(List<int> list)
        {
            ListNode listNode = null;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                ListNode tempListNode = new ListNode(list[i])
                {
                    next = listNode
                };
                listNode = tempListNode;
            }
            return listNode;
        }

        private static ListNode GetListNode(int[] array)
        {
            ListNode listNode = null;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                ListNode tempListNode = new ListNode(array[i])
                {
                    next = listNode
                };
                listNode = tempListNode;
            }
            return listNode;
        }

        private static void PrintListNode(ListNode listNode)
        {
            var tempListNode = listNode;
            while (tempListNode != null)
            {
                Console.Write($"{tempListNode.val} -> ");
                tempListNode = tempListNode.next;
            }
        }
    }
}

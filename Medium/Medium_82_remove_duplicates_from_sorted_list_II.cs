using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    class Medium_82_remove_duplicates_from_sorted_list_II
    {
        static void Main(string[] args)
        {            
            var listNode = GetListNode(new int[] { 1, 1, 2, 3 });
            PrintList(listNode);
            Console.WriteLine();
            var reverseListNode = ReverseList(listNode);
            PrintList(reverseListNode);
            Console.WriteLine();
            var deleted = DeleteDuplicates(reverseListNode);
            PrintList(deleted);
            Console.ReadKey();
        }

        public static ListNode DeleteDuplicates(ListNode reverseListNode)
        {
            ListNode answearListNode = null;
            int lastDeletedValue = reverseListNode.val - 1;
            while (reverseListNode != null)
            {
                if (reverseListNode.next != null && reverseListNode.next.val == reverseListNode.val)
                {
                    lastDeletedValue = reverseListNode.val;
                    reverseListNode = reverseListNode.next;
                    reverseListNode = reverseListNode.next;
                    continue;
                }  
                if (reverseListNode.val == lastDeletedValue)
                {
                    reverseListNode = reverseListNode.next;
                    continue;
                }
                lastDeletedValue = reverseListNode.val;
                var temp = answearListNode;
                answearListNode = new ListNode(reverseListNode.val)
                {
                    next = temp
                };
                reverseListNode = reverseListNode.next;
            }
            return answearListNode;
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

        public static ListNode ReverseList(ListNode head)
        {
            return ReverseList(head, null);
        }

        public static ListNode ReverseList(ListNode input, ListNode answear)
        {
            if (input == null)
                return answear;
            ListNode temp = input;
            input = input.next;
            temp.next = answear;
            answear = temp;
            return ReverseList(input, answear);
        }

        static void PrintList(ListNode head)
        {
            var tempListNode = head;
            while (tempListNode != null)
            {
                Console.Write($"{tempListNode.val} -> ");
                tempListNode = tempListNode.next;
            }
        }
    }    
}

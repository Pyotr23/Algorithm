using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    class Medium_82_remove_duplicates_from_sorted_list_II
    {
        static void Main(string[] args)
        {            
            var listNode = GetListNode(new int[] { 1, 2, 3, 3, 4, 4, 5 });
            PrintList(listNode);
            Console.WriteLine();
            var reverseListNode = ReverseList(listNode);
            PrintList(reverseListNode);
            Console.ReadKey();
        }

        //public static ListNode DeleteDuplicates(ListNode head)
        //{
        //    var tempCurrentList = head;
        //    while (head != null)
        //    {
        //        if (head.next != null && head.next.val != head.val)
        //        {
        //            head = head.next;
        //        }                
        //    }
        //}

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

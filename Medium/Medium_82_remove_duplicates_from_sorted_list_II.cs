using System;
using System.Collections.Generic;
using System.Text;

namespace Medium
{
    class Medium_82_remove_duplicates_from_sorted_list_II
    {
        static void Main(string[] args)
        {            
            var listNode = GetListNode(new int[] { 1, 1, 1, 2, 3 });
            PrintList(listNode);
            Console.WriteLine();            
            var deleted = DeleteDuplicates(listNode);
            PrintList(deleted);
            Console.WriteLine();
            var listNode2 = GetListNode(new int[] { 1, 2, 3, 3, 4, 4, 5 });
            PrintList(listNode2);
            Console.WriteLine();
            var deleted2 = DeleteDuplicates(listNode2);
            PrintList(deleted2);
            Console.ReadKey();
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return null;
            ListNode previous = head;
            ListNode current = head; 
            ListNode start = null;            
            while (current != null && current.next != null)
            {
                if (current.val == current.next.val)
                {
                    if (start == null)
                        start = current;                    
                    current = current.next;
                }
                else 
                {
                    if (start == null)
                        previous = current;
                    else 
                    {                        
                        if (previous == start)
                        {
                            previous = current.next;
                            head = current.next;
                        }
                        else
                            previous.next = current.next;
                        start = null;                        
                    }
                    current = current.next;
                }
            }

            //if (start != null && current.val == start.val)
            //{
            //    if (head == start)
            //        return null;
            //    else
            //        previous.next = null;
            //}
            return head;
        }

        public static ListNode DeleteDuplicatesMy(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            head = ReverseList(head);
            ListNode answearListNode = null;
            int lastDeletedValue = head.val - 1;
            while (head != null)
            {
                if (head.next != null && head.next.val == head.val)
                {
                    lastDeletedValue = head.val;
                    head = head.next;
                    head = head.next;
                    continue;
                }  
                if (head.val == lastDeletedValue)
                {
                    head = head.next;
                    continue;
                }
                lastDeletedValue = head.val;
                var temp = answearListNode;
                answearListNode = new ListNode(head.val)
                {
                    next = temp
                };
                head = head.next;
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

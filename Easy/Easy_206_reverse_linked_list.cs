using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Easy_206_reverse_linked_list
    {
        //static void Main(string[] args)
        //{
        //    var listNode = new ListNode(1)
        //    {
        //        next = new ListNode(2)
        //        {
        //            next = new ListNode(3)
        //            {
        //                next = new ListNode(4)
        //                {
        //                    next = new ListNode(5)
        //                }
        //            }
        //        }
        //    };
        //    ListNode list = ReverseList(listNode);
        //    Console.WriteLine();
        //    PrintList(list);
        //    Console.ReadKey();
        //}

        public static ListNode ReverseListIterate(ListNode head)
        {            
            ListNode reverseList = null;
            while (head != null)
            {
                ListNode temp = head;
                Console.Write($"{head.val} -> ");
                head = head.next;
                temp.next = reverseList;
                reverseList = temp;                   
            }
            return reverseList;
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
            while (head != null)
            {
                Console.Write($"{head.val} -> ");
                head = head.next;
            }
        }
    }   
    

}

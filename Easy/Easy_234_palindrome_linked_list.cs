using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{    
    class Easy_234_palindrome_linked_list
    {
        //static void Main(string[] args)
        //{
        //    var listNode = new ListNode(1)
        //    {
        //        next = new ListNode(2)
        //        {
        //            //next = new ListNode(2)
        //            //{
        //                next = new ListNode(1)
        //                //{
        //                //    next = new ListNode(5)
        //                //}
        //            //}
        //        }
        //    };
        //    Console.WriteLine(IsPalindrome(listNode));
        //    Console.ReadKey();
        //}

        public static bool IsPalindrome(ListNode head)
        {
            ListNode slowNode = null;
            ListNode fastNode = null;
            while (!(fastNode == null || fastNode?.next == null) || (slowNode == null))
            {
                if (slowNode == null)
                {
                    slowNode = head;
                    fastNode = head.next;
                    continue;
                }
                slowNode = slowNode.next;
                fastNode = fastNode.next.next;
            }
            ListNode reverse = ReverseList(slowNode.next);
            while (reverse != null)
            {
                if (head.val != reverse.val)
                    return false;
                head = head.next;
                reverse = reverse.next;
            }
            return true;
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
    }
}

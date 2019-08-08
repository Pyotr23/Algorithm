using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{    
    class Easy_234_palindrome_linked_list
    {
        static void Main(string[] args)
        {
            var listNode = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(1)
                        //{
                        //    next = new ListNode(5)
                        //}
                    }
                }
            };
            IsPalindrome(listNode);
            Console.ReadKey();
        }

        public static void IsPalindrome(ListNode head)
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{    
    class Easy_21_merge_two_sorted_lists
    {
        static void Main(string[] args)
        {
            var mergedListNode = MergeTwoLists(new ListNode(new List<int> { 1, 2, 4 }), new ListNode(new List<int> { 1, 3, 4 }));
            mergedListNode.PrintListNode();
            Console.ReadKey();
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode answearListNode = new ListNode(l1.val) { next = new ListNode(l2.val) };
            answearListNode.next.next = MergeTwoInOneLists(l1.next, l2.next);
            return answearListNode;
        }

        private static ListNode MergeTwoInOneLists(ListNode first, ListNode second)
        {
            if (first == null && second == null)
                return null;
            var nextNode = new ListNode(first.val) { next = new ListNode(second.val) };
            nextNode.next.next = MergeTwoInOneLists(first.next, second.next);
            return nextNode;            
        }
    }
}

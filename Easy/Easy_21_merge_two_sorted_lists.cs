using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{    
    class Easy_21_merge_two_sorted_lists
    {
        static void Main(string[] args)
        {
            //var mergedListNode = MergeTwoLists(new ListNode(new List<int> { 1, 2, 4 }), new ListNode(new List<int> { 1, 3, 4 }));
            var mergedListNode = MergeTwoLists(new ListNode(new List<int> { 5 }), new ListNode(new List<int> { 1, 2, 4 }));
            mergedListNode.PrintListNode();
            Console.ReadKey();
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {            
            if (l1 == null && l2 == null)
                return null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode nextNode;
            if (l1.val <= l2.val)
            {
                nextNode = new ListNode(l1.val);
                nextNode.next = MergeTwoLists(l1.next, l2);
            }
            else
            {
                nextNode = new ListNode(l2.val);
                nextNode.next = MergeTwoLists(l1, l2.next);
            }
            return nextNode;
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

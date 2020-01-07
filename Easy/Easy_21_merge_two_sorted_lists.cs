using System;
using System.Collections.Generic;
using System.Text;

namespace Easy
{    
    class Easy_21_merge_two_sorted_lists
    {
        static void Main(string[] args)
        {
            var listNode = new ListNode(1) { next = new ListNode(3) { next = new ListNode(5) } };
            listNode.PrintListNode();

            var secondList = new ListNode(new List<int> { 2, 4, 6 });
            secondList.PrintListNode();
            Console.ReadKey();
        }

        //public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        //{

        //}
    }
}

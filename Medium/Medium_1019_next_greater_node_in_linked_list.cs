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
        static void Main(string[] args)
        {
            var listNode = new ListNode(10)
            {
                next = new ListNode(8)
                {
                    next = new ListNode(6)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(2)
                            {
                                next = new ListNode(3)
                                {
                                    next = new ListNode(4)
                                    {
                                        next = new ListNode(5)
                                        {
                                            next = new ListNode(4)
                                            {
                                                next = new ListNode(3)
                                                {
                                                    next = new ListNode(2)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var bigValueListNode = GetListNode(listNode);
            PrintListNode(bigValueListNode);
            Console.ReadKey();            
        }

        private static Queue<int> GetQueue(ListNode lNode)
        {
            var tempListNode = lNode;
            var queue = new Queue<int>();           
            while (tempListNode.next != null && tempListNode.next.next != null)
            {
                if (tempListNode.next.val > tempListNode.val)
                    queue.Enqueue(tempListNode.next.val);
                tempListNode = tempListNode.next;
            }
            return queue;
        }

        private static ListNode GetListNode(ListNode lNode)
        {
            var tempListNode = lNode;
            var nodesList = new List<int>();
            while (tempListNode.next != null && tempListNode.next.next != null)
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

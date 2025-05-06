using DSAPatterns.ArraysAndStrings.TwoPointersSameDirection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.LinkedLists
{
    internal class ProblemsAndSolutions
    {
        //Reverese a Linked List
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode prev = null;
            ListNode current = head;
            while (current != null)
            {
                ListNode next = current.next; // Save next node
                current.next = prev;          // Reverse the pointer
                prev = current;               // Move prev forward
                current = next;               // Move current forward
            }

            return prev; // New head
        }

        public ListNode ReverseListRecursive(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode temp = ReverseListRecursive(head.next);
            head.next.next = head;
            head.next = null;

            return temp;
        }

        //Reverse Linked List II
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            ListNode dummy = new ListNode(0); // created dummy node
            dummy.next = head;
            ListNode prev = dummy; // intialising prev pointer on dummy node

            for (int i = 0; i < left - 1; i++)
                prev = prev.next; // adjusting the prev pointer on it's actual index

            ListNode curr = prev.next; // curr pointer will be just after prev
                                       // reversing
            for (int i = 0; i < right - left; i++)
            {
                ListNode forw = curr.next; // forw pointer will be after curr
                curr.next = forw.next;
                forw.next = prev.next;
                prev.next = forw;
            }
            return dummy.next;
        }

        //Reverese nodes in K Group
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k == 1) return head;

            int count = 0;
            var cur = head;
            while (cur != null && count < k)
            {
                cur = cur.next;
                count++;
            }

            if (count != k) return head;

            var curr = head;
            ListNode prev = null;
            ListNode next = null;
            for (int i = 0; i < k; i++)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            head.next = ReverseKGroup(curr, k);

            return prev;
        }
    }
}

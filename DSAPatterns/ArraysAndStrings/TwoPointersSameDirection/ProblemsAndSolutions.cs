using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.TwoPointersSameDirection
{
    internal class ProblemsAndSolutions
    {
        //Remove duplicates
        public int RemoveDuplicates(int[] nums)
        {
            int j = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            return j;
        }

        //Linked List Cycle
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode faster = head.next.next;
            ListNode slower = head.next;

            while (faster != null && faster.next != null)
            {
                faster = faster.next.next;
                slower = slower.next;

                if (faster == slower)
                    return true;
            }

            return false;
        }

        //Middle of linked list
        public ListNode MiddleNode(ListNode head)
        {
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}

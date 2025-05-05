using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.MonotonicStack
{
    internal class MonotonicStack
    {
        //Daily Temperatures
        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] answers = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int prevIndex = stack.Pop();
                    answers[prevIndex] = i - prevIndex;
                }
                stack.Push(i);
            }

            return answers;
        }

        //Largest Rectangle in Histogram
        public int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;

            // Calculate the left smaller index by maintaining a monotone increasing stack
            Stack<int[]> stack = new Stack<int[]>(); // int[] stores the index and value for   each element
            int[] leftSmaller = new int[n]; // Computed smaller left indices will be stored here
            for (int i = 0; i < n; i++)
            {
                int curr = heights[i];
                // Pop elements out of the stack until we find a smaller element in the left of current element
                while (stack.Count > 0 && curr <= stack.Peek()[1])
                    stack.Pop();
                // The boundary of the current element will be the next element right adjacent to the smaller element.
                // If there is no left boundary then we make it as 0
                leftSmaller[i] = stack.Count > 0 ? stack.Peek()[0] + 1 : 0;
                stack.Push(new int[] { i, curr });
            }

            // Calculate the right smaller index
            stack = new Stack<int[]>();   // Re-initializing the stack
            int[] rightSmaller = new int[n]; // Computed smaller right indices will be stored here

            for (int i = n - 1; i >= 0; i--)
            {
                int curr = heights[i];
                // Pop elements out of the stack until we find a smaller element in the right of current element
                while (stack.Count > 0 && curr <= stack.Peek()[1])
                    stack.Pop();
                // The boundary of the current element will be the next element left adjacent to the smaller element.
                // If there is no right boundary then we consider the last element index as the end boundary
                rightSmaller[i] = stack.Count > 0 ? stack.Peek()[0] - 1 : n - 1;
                stack.Push(new int[] { i, curr });
            }

            int maxArea = 0;
            for (int i = 0; i < n; i++)
            {
                int currArea = (rightSmaller[i] - leftSmaller[i] + 1) * heights[i];
                maxArea = Math.Max(maxArea, currArea);
            }
            return maxArea;
        }

        //Next greater element
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int n2 = nums2.Length;
            int[] ans = new int[n2];   // Stores next greater for each index in nums2
            Stack<int> stack = new Stack<int>();

            // Step 1: Precompute next greater elements for nums2
            for (int i = n2 - 1; i >= 0; i--)
            {
                // Remove elements smaller than or equal to current
                while (stack.Count > 0 && nums2[i] > stack.Peek())
                {
                    stack.Pop();
                }
                // Set next greater if exists
                ans[i] = stack.Count == 0 ? -1 : stack.Peek();
                // Push current element to stack
                stack.Push(nums2[i]);
            }

            // Step 2: Map nums1 values to their next greater values in nums2
            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (nums2[j] == nums1[i])
                    {
                        res[i] = ans[j];
                        break;
                    }
                }
            }

            return res;
        }
    }
}

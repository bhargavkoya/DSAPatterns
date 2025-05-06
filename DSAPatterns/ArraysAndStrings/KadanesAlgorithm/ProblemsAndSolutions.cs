using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.KadanesAlgorithm
{
    internal class ProblemsAndSolutions
    {
        //Maximum Subarray
        public int MaxSubArray(int[] nums)
        {
            int curMax = 0, finalMax = int.MinValue;
            if (nums.Length == 1) return nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                curMax = Math.Max(nums[i], curMax + nums[i]);
                finalMax = Math.Max(finalMax, curMax);
            }
            return finalMax;
        }

        //Maximum Sum Circular Subarray
        public int MaxSubarraySumCircular(int[] nums)
        {
            int curMax = 0, curMin = 0, sum = 0, maxSum = nums[0], minSum = nums[0];
            foreach (int num in nums)
            {
                curMax = Math.Max(curMax, 0) + num;
                maxSum = Math.Max(maxSum, curMax);
                curMin = Math.Min(curMin, 0) + num;
                minSum = Math.Min(minSum, curMin);
                sum += num;
            }
            return sum == minSum ? maxSum : Math.Max(maxSum, sum - minSum);
        }

        //K Concatenation Maximum Sum
        public int KConcatenationMaxSum(int[] arr, int k)
        {
            int mod = 1000000007;
            int n = arr.Length;
            long presum = 0, premax = 0, sufsum = 0, sufmax = 0, cursum = 0, curmax = 0;
            for (int i = 0; i < n; i++)
            {

                // prefix sum
                presum += arr[i];
                premax = Math.Max(premax, presum);

                //suffix sum
                sufsum += arr[n - 1 - i];
                sufmax = Math.Max(sufmax, sufsum);

                //Kadane's Algorithm
                cursum = Math.Max(0, cursum) + arr[i];
                curmax = Math.Max(curmax, cursum);

            }
            long max = Math.Max(curmax, premax + sufmax + Math.Max(0, presum * (k - 2))); // prefix sum(presum) will be the sum of the complete array after entire traversal...
            return (int)((k == 1 ? curmax : max) % mod);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.PrefixSumOrDifferenceArray
{
    internal class ProblemsAndSolutions
    {
        //Subarray sum equals to K
        public int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            int sum = 0, ans = 0;
            map.Add(sum, 1);
            foreach (var it in nums)
            {
                sum += it;
                int find = sum - k;
                if (map.ContainsKey(find))
                {
                    ans += map[find];
                }
                if (map.ContainsKey(sum))
                    map[sum]++;
                else
                    map.Add(sum, 1);
            }
            return ans;
        }

        //Find Pivot Index
        public int PivotIndex(int[] nums)
        {
            int total = 0;
            foreach (var n in nums)
            {
                total += n;
            }

            int leftTotal = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int rightTotal = total - leftTotal - nums[i];
                if (rightTotal == leftTotal)
                {
                    return i;
                }
                leftTotal += nums[i];
            }
            return -1;
        }

        //Range sum query Immuatable
        public class NumArray
        {
            private int[] prefixNums;
            public NumArray(int[] nums)
            {
                prefixNums = new int[nums.Length + 1];
                prefixNums[0] = nums[0];
                for (int i = 1; i < nums.Length + 1; i++)
                {
                    prefixNums[i] = prefixNums[i - 1] + nums[i - 1];
                }
            }

            public int SumRange(int left, int right)
            {
                return prefixNums[right + 1] - prefixNums[left];
            }
        }
    }
}

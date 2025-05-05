using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.InPlaceArrayRearrangement
{
    internal class ProblemsAndSolutions
    {
        //Find all disappered numbers in an array
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                {
                    continue;
                }
                nums[index] *= -1;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }
            return result;
        }

        //Find duplicate
        public int FindDuplicate(int[] nums)
        {
            int slow = nums[0];
            int fast = nums[0];

            while (true)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];

                if (slow == fast)
                {
                    break;
                }
            }

            int slow2 = nums[0];

            while (slow != slow2)
            {
                slow = nums[slow];
                slow2 = nums[slow2];
            }

            return slow;
        }

        //Find missing positive
        public int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            //filtering positive values
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0)
                {
                    nums[i] = n + 1;
                }
            }
            //marking the presented values with negative sign
            for (int i = 0; i < nums.Length; i++)
            {
                int num = Math.Abs(nums[i]);
                if (num > n)
                {
                    continue;
                }
                nums[num - 1] = -Math.Abs(nums[num - 1]);
            }
            //if any value is positive then the missing value is index+1
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] >= 0)
                {
                    return j + 1;
                }
            }
            return nums.Length + 1;
        }
    }
}

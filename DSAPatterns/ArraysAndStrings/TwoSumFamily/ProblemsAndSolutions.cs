using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.TwoSumFamily
{
    internal class ProblemsAndSolutions
    {
        //2 sum
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    return new int[] { dict[diff], i };
                }
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            return new int[] { 0, 0 };
        }

        //3 Sum
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            Array.Sort(nums);

            for (int currIndex = 0; currIndex < nums.Length; currIndex++)
            {
                int currNumber = nums[currIndex];
                if (currIndex > 0 && nums[currIndex - 1] == currNumber)
                {
                    continue;
                }

                int left = currIndex + 1, right = nums.Length - 1;
                while (left < right)
                {
                    int target = currNumber + nums[left] + nums[right];
                    if (target == 0)
                    {
                        res.Add(new List<int>() { currNumber, nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (target > 0)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return res;
        }

        //4 Sum
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length < 4)
            {
                return result;
            }
            Array.Sort(nums);

            long targetLong = target;
            for (int i = 0; i < nums.Length - 3; ++i)
            {
                if (i != 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < nums.Length - 2; ++j)
                {
                    if (j != i + 1 && nums[j] == nums[j - 1]) continue;

                    long expect = targetLong - nums[i] - nums[j];
                    if (expect < int.MinValue || expect > int.MaxValue) continue;

                    int l = j + 1, r = nums.Length - 1;
                    while (l < r)
                    {
                        long sum = nums[l] + nums[r];
                        if (sum == expect)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[l], nums[r] });
                            while (l < r && nums[l] == nums[l + 1])
                            {
                                ++l;
                            }
                            while (l < r && nums[r] == nums[r - 1])
                            {
                                --r;
                            }
                            ++l;
                            --r;
                        }
                        else if (sum < expect)
                        {
                            ++l;
                        }
                        else
                        {
                            --r;
                        }
                    }
                }
            }
            return result;
        }
    }
}

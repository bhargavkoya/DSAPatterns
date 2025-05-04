using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.BinarySearchStandard
{
    internal class ProblemsAndSolutions
    {
        //Binary Search
        public int Search(int[] nums, int target)
        {
            int st = 0, end = nums.Length - 1;

            while (st <= end)
            {
                int mid = st + (end - st) / 2;

                if (target > nums[mid])
                    st = mid + 1;
                else if (target < nums[mid])
                    end = mid - 1;
                else
                    return mid;
            }
            return -1;
        }

        //Find First and Last Position of Element in Sorted Array
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2] { -1, -1 };
            result[0] = BinarySearch(nums, target, true);
            result[1] = BinarySearch(nums, target, false);
            return result;
        }

        private int BinarySearch(int[] nums, int target, bool isSearchingLeft)
        {
            int left = 0, right = nums.Length - 1, idx = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    idx = mid;
                    if (isSearchingLeft)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }
            return idx;
        }

        //Search Insert Position
        public int SearchInsert(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1, pos = 0, item = 0;
            while (start <= end)
            {
                pos = start + (end - start) / 2;
                item = nums[pos];
                if (item == target)
                {
                    return pos;
                }
                if (target < item)
                {
                    end = pos - 1;
                }
                else
                {
                    start = pos + 1;
                }
            }

            return start;
        }
    }
}

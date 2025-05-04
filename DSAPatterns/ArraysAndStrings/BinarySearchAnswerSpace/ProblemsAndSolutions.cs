using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.BinarySearchAnswerSpace
{
    internal class ProblemsAndSolutions
    {
        //Split array largest sum
        public int SplitArray(int[] nums, int k)
        {
            int max = 0; long sum = 0;
            foreach (int num in nums)
            {
                max = Math.Max(num, max);
                sum += num;
            }
            if (k == 1) return (int)sum;

            long l = max; long r = sum;
            while (l <= r)
            {
                long mid = (l + r) / 2;
                if (IsValid(mid, nums, k))
                {
                    r = mid - 1; //if the possibilities are more than m then we need to lower r
                }
                else
                {
                    l = mid + 1; //if the possibilities are less than m then we need to increase l
                }
            }
            return (int)l;
        }

        private bool IsValid(long target, int[] nums, int k)
        {
            int count = 1;
            long total = 0;
            foreach (int num in nums)
            {
                total += num;
                if (total > target)
                {
                    total = num;
                    count++;
                    if (count > k)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Koko eating bananas
        public int MinEatingSpeed(int[] piles, int h)
        {
            int low = 1;
            int high = int.MinValue;
            for (int i = 0; i < piles.Length; i++)
            {
                high = Math.Max(high, piles[i]);
            }
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (blackbox(mid, piles, h))
                {
                    high = mid;
                }
                else
                    low = mid + 1;
            }
            return low;
        }

        public bool blackbox(int maxpiles, int[] piles, int h)
        {
            int hours = 0;
            foreach (int i in piles)
            {
                int time = i / maxpiles;
                hours += time;
                if (i % maxpiles != 0) hours++;
            }
            if (hours <= h)
                return true;
            return false;
        }

        //Find the smallest divisor given a threshold
        public int SmallestDivisor(int[] nums, int threshold)
        {
            int maxNum = 0;
            foreach (int num in nums)
            {
                if (num > maxNum)
                {
                    maxNum = num;
                }
            }

            int low = 1;
            int high = maxNum;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int sum = 0;
                foreach (int num in nums)
                {
                    sum += (num + mid - 1) / mid;
                    if (sum > threshold)
                    {
                        break;
                    }
                }

                if (sum <= threshold)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.HashingForLookup
{
    internal class ProblemsAndSolutions
    {
        //Two Sum
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

        //Contains duplicate
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> final = new HashSet<int>();
            foreach (var i in nums)
            {
                if (final.Contains(i)) return true;
                final.Add(i);
            }
            return false;
        }

        //Ransom Note
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> magaMap = new Dictionary<char, int>();
            foreach (var m in magazine)
            {
                if (magaMap.ContainsKey(m))
                {
                    magaMap[m] += 1;
                }
                else
                {
                    magaMap.Add(m, 1);
                }
            }

            foreach (var r in ransomNote)
            {
                if (!magaMap.ContainsKey(r) || magaMap[r] <= 0)
                {
                    return false;
                }
                magaMap[r] = magaMap[r] - 1;
            }

            return true;
        }
    }
}

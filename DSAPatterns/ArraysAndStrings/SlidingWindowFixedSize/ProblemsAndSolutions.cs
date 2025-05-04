using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.SlidingWindowFixedSize
{
    internal class ProblemsAndSolutions
    {
        //Maximum Average Subarray I
        public double FindMaxAverage(int[] nums, int k)
        {
            double sum = 0;
            for (int i = 0; i < k; i++)
                sum = sum + nums[i];
            double res = sum;
            for (int i = k; i < nums.Length; i++)
            {
                sum = sum + nums[i] - nums[i - k];
                res = Math.Max(res, sum);
            }
            return res / k;
        }

        //Subarray sum equals k
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

        //Maximum number of vowels in a substring of given length
        public int MaxVowels(string s, int k)
        {
            int n = s.Length;
            int i = 0;
            int count = 0;
            for (; i < k; i++)
            { // First window of size k
                if (isVowel(s[i]))
                    count++;
            }
            int ans = count;
            for (; i < n; i++)
            { // Remaining n-k windows
                if (isVowel(s[i])) // If new character is vowel the increment count
                    count++;
                if (isVowel(s[i - k])) // If previous character is vowel then decrement count
                    count--;
                ans = Math.Max(ans, count);
            }
            return ans;
        }

        public bool isVowel(char c)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                return true;
            return false;
        }
    }
}

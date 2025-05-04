using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.SlidingWindowDynamicSize
{
    internal class ProblemsAndSolutions
    {
        //Longest substring without repeating characters
        public int LengthOfLongestSubstring(string s)
        {
            int start = 0;
            int end = 0;
            int max = 0;

            HashSet<Char> hs = new HashSet<Char>();
            while (end < s.Length)
            {
                if (!hs.Contains(s[end]))
                {
                    hs.Add(s[end]);
                    end++;
                    max = Math.Max(end - start, max);
                }
                else
                {
                    hs.Remove(s[start]);
                    start++;
                }
            }
            return max;
        }

        //Minimum window substring
        public string MinWindow(string s, string t)
        {
            int[] need = new int[128];
            int[] window = new int[128];

            foreach (var charT in t)
            {
                need[charT]++;
            }

            int minLength = s.Length + 1, left = 0, count = 0, start = -1;

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                window[c]++;

                //increment the count if the character count in window does not match with need
                if (window[c] <= need[c])
                {
                    count++;
                }

                //shrink the window as much as possible to get min window once the char count matches in both window and need
                while (count == t.Length)
                {
                    //update the min window size if smaller found
                    if (right - left + 1 < minLength)
                    {
                        minLength = right - left + 1;
                        start = left;
                    }

                    // try to shrink from the left
                    char leftChar = s[left];
                    if (window[leftChar] <= need[leftChar]) count--;
                    window[leftChar]--;
                    left++;
                }
            }

            return start < 0 ? "" : s.Substring(start, minLength);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.AnagramGrouping
{
    internal class ProblemsAndSolutions
    {
        //Group Anagrams
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> anagramGroups = new Dictionary<string, IList<string>>(StringComparer.Ordinal);

            foreach (string str in strs)
            {
                char[] freq = new char[26];

                foreach (char c in str)
                {
                    int index = c - 'a';
                    freq[index] = (char)(freq[index] + 1);
                }

                string hash = new String(freq);

                if (anagramGroups.TryGetValue(hash, out IList<string> anagrams))
                {
                    anagrams.Add(str);
                }
                else
                {
                    anagramGroups.Add(hash, new List<string> { str });
                }
            }

            return anagramGroups.Values.ToList();
        }

        //Valid Anagram
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                arr[(int)s[i] - 'a'] += 1;
            }
            for (int j = 0; j < t.Length; j++)
            {
                arr[(int)t[j] - 'a'] -= 1;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        //
    }
}

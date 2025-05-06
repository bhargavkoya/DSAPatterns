using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.StringReversalTechniques
{
    internal class ProblemsAndSolutions
    {
        // Problem 1: Reverse a string in place
        public void ReverseString(char[] s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;

                left++;
                right--;
            }
        }

        // Problem 2: Reverse words in a sentence
        public string ReverseWords(string s)
        {
            string[] words = s.Split(" ");
            int left = 0;
            int right = words.Length - 1;

            while (left < right)
            {
                string temp = words[left];
                words[left] = words[right];
                words[right] = temp;
                left++;
                right--;
            }

            StringBuilder result = new StringBuilder();
            foreach (String word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (result.Length > 0)
                    {
                        result.Append(" ");
                    }
                    result.Append(word);
                }
            }

            return result.ToString();
        }


    }
}

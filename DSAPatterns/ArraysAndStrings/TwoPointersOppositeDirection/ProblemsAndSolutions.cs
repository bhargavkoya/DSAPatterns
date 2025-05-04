using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.TwoPointersOppositeDirection
{
    internal class ProblemsAndSolutions
    {
        //TWO Sum II
        public int[] TwoSum(int[] numbers, int target)
        {
            int[] res = new int[2];
            int left = 0, right = numbers.Length - 1;
            while (left < right)
            {
                if (numbers[left] + numbers[right] == target)
                {
                    break;
                }

                if (numbers[left] + numbers[right] > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            res[0] = left + 1;
            res[1] = right + 1;

            return res;
        }

        //Is valid palindrome
        public bool IsPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;

            while (left < right)
            {
                while (left < right && !Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !Char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                if (char.ToLower(s[left]) != char.ToLower(s[right])) return false;
                left++;
                right--;
            }

            return true;
        }


    }
}

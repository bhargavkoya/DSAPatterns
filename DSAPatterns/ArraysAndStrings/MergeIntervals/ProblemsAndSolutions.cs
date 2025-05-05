using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPatterns.ArraysAndStrings.MergeIntervals
{
    internal class ProblemsAndSolutions
    {
        //Merge Intervals
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0])); // Sort array to avoid following test cases.

            List<int[]> result = new();
            int[] prev = intervals[0];//take first array in previous variable
            result.Add(prev); // add first array to result. we will update this result over time and since its reference                                 type it will automatically make changes

            for (int i = 1; i < intervals.Length; i++) // start loop with first index, we took care of 0th index above
            {
                int[] current = intervals[i]; // grab current array in current variable

                if (prev[1] >= current[0]) // The line is overlapping when right pointer of left-line is greater than left                                               pointer of right-line. e.g. [1,3],[2,6]
                {
                    prev[1] = Math.Max(prev[1], current[1]); //Since we have to merge overlapping lines, all we have to do                                                            is take max of right pointer, array is sorted so left                                                                  pointer is already at its place
                }
                else
                {
                    // now we have merged [1,3] [2,6] => [1,6], so the result that was holding [1,3] got overridden by [1,6] 
                    prev = current; // we need to add current array to result to repeat the process, so assign [8,10] as                                        prev
                    result.Add(prev);// result will have [1,6] [8,10]
                }
            }
            return result.ToArray();

        }

        //Insert Interval
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int n = intervals.Length;
            List<int[]> res = new List<int[]>();

            int i = 0;
            //Add elements to res until we find index for mew interval
            while (i < n && intervals[i][1] < newInterval[0])
            {
                res.Add(intervals[i]);
                i++;
            }

            //update new interval with curr one while doing merge
            while (i < n && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }

            res.Add(newInterval);

            while (i < n)
            {
                res.Add(intervals[i]);
                i++;
            }

            return res.ToArray();
        }

        //Non-overlapping intervals
        public int EraseOverlapIntervals(int[][] intervals)
        {
            int res = 0;

            Array.Sort(intervals, (a, b) => a[1] - b[1]);
            int prev_end = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (prev_end > intervals[i][0])
                {
                    res++;
                }
                else
                {
                    prev_end = intervals[i][1];
                }
            }

            return res;
        }
    }
}

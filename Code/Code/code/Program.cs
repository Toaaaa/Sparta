using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/340212
        /// </summary>

        public class Solution
        {
            public long GetTotalTime(int level, int[] diffs, int[] times, long limit)
            {
                long totalTime = 0;
                for (int i = 0; i < diffs.Length; i++)
                {
                    int curTime = times[i];
                    int prevTime = (i == 0) ? 0 : times[i - 1];

                    if (diffs[i] <= level)
                    {
                        totalTime += curTime;
                    }
                    else
                    {
                        int mistakes = diffs[i] - level;
                        totalTime += (long)(curTime + prevTime) * mistakes + curTime;
                    }

                    // limit 를 초과시 조기 종료
                    if (totalTime > limit)
                        return totalTime;
                }

                return totalTime;
            }

            public int solution(int[] diffs, int[] times, long limit)
            {
                int left = 1;
                int right = 100000;
                int answer = right;

                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    long totalTime = GetTotalTime(mid, diffs, times, limit);

                    if (totalTime <= limit)
                    {
                        answer = mid;
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return answer;
            }

        }
    }
}

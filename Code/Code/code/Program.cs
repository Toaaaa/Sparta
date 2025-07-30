using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/152996
        /// </summary>

        public class Solution
        {
            public long solution(int[] weights)
            {
                long answer = 0;
                var count = new Dictionary<int, long>();

                foreach (int w in weights)
                {
                    if (!count.ContainsKey(w)) count[w] = 0;

                    count[w]++;
                }

                var ratios = new Tuple<int, int>[]
                {
                    Tuple.Create(1, 1),
                    Tuple.Create(2, 3),
                    Tuple.Create(3, 4),
                    Tuple.Create(1, 2),
                    Tuple.Create(3, 2),
                    Tuple.Create(4, 3),
                };


                foreach (var ratio in ratios)
                {
                    int a = ratio.Item1;
                    int b = ratio.Item2;

                    foreach (int w in count.Keys)
                    {
                        long wCount = count[w];
                        if ((w * b) % a != 0) continue; // 불가능한 케이스 건너뛰기

                        int target = (w * b) / a;
                        if (!count.ContainsKey(target)) continue; // 등록된 값에 없으면 건너뛰기

                        if (w == target)
                        {
                            answer += wCount * (wCount - 1) / 2;
                        }
                        else if (w < target)
                        {
                            answer += wCount * count[target];
                        }
                    }
                }

                return answer;
            }
        }
    }
}

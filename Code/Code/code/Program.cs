using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/132265
        /// </summary>

        public class Solution
        {
            public int solution(int[] topping)
            {
                int n = topping.Length;
                int answer = 0;

                // 오른쪽 토핑 개수 카운트
                Dictionary<int, int> rightCount = new Dictionary<int, int>();
                foreach (int t in topping)
                {
                    if (rightCount.ContainsKey(t)) rightCount[t]++;
                    else rightCount[t] = 1;
                }

                HashSet<int> leftSet = new HashSet<int>();
                int leftDistinct = 0;
                int rightDistinct = rightCount.Count;

                for (int i = 0; i < n - 1; i++)
                {
                    int t = topping[i];

                    // 왼쪽에 추가
                    if (leftSet.Add(t))
                        leftDistinct++;

                    // 오른쪽에서 제거
                    rightCount[t]--;
                    if (rightCount[t] == 0)
                        rightDistinct--;

                    // 비교
                    if (leftDistinct == rightDistinct)
                        answer++;
                }

                return answer;
            }

            static void Main(string[] args)
            {
                Solution solution = new Solution();

                int answer = solution.solution([1, 2, 3, 1, 4]);
                Console.WriteLine(answer);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/12987
        /// </summary>

        public class Solution
        {
            // 1. Dictionary 만 사용한 풀이
            public int solution(int[] A, int[] B)
            {
                int answer = 0;
                Dictionary<int, int> dictA = new Dictionary<int, int>();
                for(int i = 0; i < B.Length; i++)
                {
                    if (dictA.ContainsKey(B[i]))
                        dictA[B[i]]++;
                    else
                        dictA.Add(B[i], 1);
                }
                for (int i = 0; i < A.Length; i++)
                {
                    if (dictA.Count == 0) break;

                    var key = dictA.Keys.FirstOrDefault(k => k > A[i]);

                    if (key == 0) dictA.Remove(dictA.Keys.First()); // A[i]보다 큰 값이 없으면 가장 작은 값 대입
                    else
                    {
                        answer++;
                        if (dictA[key] == 1)
                            dictA.Remove(key);
                        else
                            dictA[key]--;
                    }
                }
                return answer;
            }


            // 2. SortedDictionary + SortedSet 사용한 풀이 (시간 복잡도 고려)
            public int solution2(int[] A, int[] B)
            {
                int answer = 0;
                SortedDictionary<int, int> dictA = new SortedDictionary<int, int>();
                SortedSet<int> keys = new SortedSet<int>();

                for (int i = 0; i < B.Length; i++)
                {
                    if (dictA.ContainsKey(B[i]))
                        dictA[B[i]]++;
                    else
                        dictA.Add(B[i], 1);

                    keys.Add(B[i]);
                }

                for (int i = 0; i < A.Length; i++)
                {
                    if (dictA.Count == 0) break;

                    int key;

                    // A[i]보다 큰 값 찾기
                    var view = keys.GetViewBetween(A[i] + 1, int.MaxValue);
                    if (view.Count > 0)
                    {
                        key = view.Min;
                        answer++;
                    }
                    else
                        key = keys.Min; // A[i]보다 큰 값이 없으면 가장 작은 값 대입

                    if (dictA[key] == 1)
                    {
                        dictA.Remove(key);
                        keys.Remove(key);
                    }
                    else
                        dictA[key]--;
                }
                return answer;
            }



            static void Main(string[] args)
            {
                Solution solution = new Solution();

                //int answer = solution.solution(437674,3);
                //Console.WriteLine(answer);
            }
        }
    }
}

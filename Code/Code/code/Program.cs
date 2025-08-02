using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/135807
        /// </summary>

        public class Solution
        {
            public int solution(int[] arrayA, int[] arrayB)
            {
                int answer = 0;
                HashSet<int> setA = new HashSet<int>();
                HashSet<int> setB = new HashSet<int>();
                arrayA = arrayA.OrderBy(x => x).ToArray();
                arrayB = arrayB.OrderBy(x => x).ToArray();


                GetDiv(arrayA[0], setA);
                GetDiv(arrayB[0], setB);

                for (int i = 1; i < arrayA.Length; i++)
                {
                    foreach (var item in setA.ToArray())
                    {
                        if (arrayA[i] % item != 0)
                            setA.Remove(item);
                    }
                    foreach (var item in setB.ToArray())
                    {
                        if (arrayB[i] % item != 0)
                            setB.Remove(item);
                    }
                }

                // 크로스 체크
                int maxA = 0;
                foreach (var div in setA)
                {
                    if (arrayB.All(x => x % div != 0))
                        maxA = Math.Max(maxA, div);
                }

                int maxB = 0;
                foreach (var div in setB)
                {
                    if (arrayA.All(x => x % div != 0))
                        maxB = Math.Max(maxB, div);
                }

                answer = Math.Max(maxA, maxB);
                return answer;
            }


            public void GetDiv(int num,HashSet<int> h)
            {
                for (int i = 1; i * i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        h.Add(i);
                        h.Add(num / i);
                    }
                }
            }


            static void Main(string[] args)
            {
                Solution solution = new Solution();
                int ans = solution.solution([12, 16], [6, 18]);
                Console.WriteLine(ans);
            }
        }
    }
}

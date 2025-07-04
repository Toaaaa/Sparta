using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/12921
        /// </summary>

        public class Solution
        {
            public int solution(int n)
            {
                if (n < 2) return 0;

                bool[] isPrime = new bool[n + 1];
                for (int i = 2; i <= n; i++) isPrime[i] = true;

                for (int i = 2; i * i <= n; i++)
                {
                    if (!isPrime[i]) continue;

                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }

                int answer = 0;
                for (int i = 2; i <= n; i++)
                {
                    if (isPrime[i]) answer++;
                }
                return answer;
            }
        }
    }
}

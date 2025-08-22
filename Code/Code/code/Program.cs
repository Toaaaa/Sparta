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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/12980
        /// </summary>

        public class Solution
        {
            public int solution(int n)
            {
                int answer = 0;
                answer++;

                while (n > 1)
                {
                    if(n % 2 == 0)
                    {
                        n /= 2;
                    }
                    else
                    {
                        n -= 1;
                        answer++;
                    }
                }

                return answer;
            }

            static void Main(string[] args)
            {
                Solution solution = new Solution();

                int answer = solution.solution(5000);
                Console.WriteLine(answer);
            }
        }
    }
}

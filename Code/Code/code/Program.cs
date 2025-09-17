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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/12971
        /// </summary>

        public class Solution
        {
            public int solution(int[] sticker)
            {
                int n = sticker.Length;
                if (n == 1) return sticker[0];

                // 1. 첫 번째 스티커 선택
                int[] dp1 = new int[n];
                dp1[0] = sticker[0];
                dp1[1] = Math.Max(sticker[0], sticker[1]);
                for (int i = 2; i < n - 1; i++)
                {
                    dp1[i] = Math.Max(dp1[i - 1], dp1[i - 2] + sticker[i]);
                }

                // 2. 첫 번째 스티커 선택하지 않음
                int[] dp2 = new int[n];
                dp2[0] = 0;
                dp2[1] = sticker[1];
                for (int i = 2; i < n; i++)
                {
                    dp2[i] = Math.Max(dp2[i - 1], dp2[i - 2] + sticker[i]);
                }

                return Math.Max(dp1[n - 2], dp2[n - 1]);
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

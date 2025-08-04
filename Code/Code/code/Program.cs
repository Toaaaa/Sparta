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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/389479
        /// </summary>

        public class Solution
        {
            public int solution(int[] players, int m, int k)
            {
                
                Queue<int> serverQ = new Queue<int>();
                int currentServer = 0;
                int cumuSever = 0;
                for(int i = 0; i < players.Length; i++)
                {
                    // 유지 시간 이후부터는 계속 시간 지난 서버 제거
                    if (i - k >= 0) currentServer -= serverQ.Dequeue();

                    int total = 0;
                    // 총 유저수가 서버의 가용량을 넘어설때
                    if (players[i] >= (currentServer+1) * m)
                    {
                        while (players[i] >= (currentServer + 1) * m)
                        {
                            currentServer++;
                            cumuSever++;
                            total++;
                        }
                    }
                    serverQ.Enqueue(total);
                }
                return cumuSever;
            }


            static void Main(string[] args)
            {
                Solution solution = new Solution();
                int ans = solution.solution([0, 2, 3, 3, 1, 2, 0, 0, 0, 0, 4, 2, 0, 6, 0, 4, 2, 13, 3, 5, 10, 0, 1, 5], 3,5);
                Console.WriteLine(ans);
            }
        }
    }
}

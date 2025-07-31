using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/148653
        /// </summary>

        public class Solution
        {
            public int solution(int storey)
            {
                int answer = 0;
                while (storey / 10 > 0)
                {
                    Stone(ref storey ,storey % 10, ref answer);
                    storey /= 10;
                }
                LastStone(storey, ref answer);
                return answer;
            }

            void Stone(ref int ori,int num, ref int ans)
            {
                if(num == 0)
                {
                    return;
                }
                if(num <= 4)
                {
                    ans += num;
                    return;
                }
                if(num == 5)
                {
                    if (ori / 10 != 0)
                    {
                        if((ori /10) % 10 >= 5)
                        {
                            ans += 5;
                            ori += 10;
                        }
                        else
                        {
                            ans += 5;
                        }
                    }
                    else
                    {
                        ans += 5;
                    }
                    return;
                }
                if(num >= 6)
                {
                    ans += 10 - num;
                    ori += 10;
                    return;
                }
            }

            void LastStone(int num, ref int ans)
            {
                if (num == 0)
                {
                    return;
                }
                if (num <= 5)
                {
                    ans += num;
                    return;
                }  
                if (num >= 6)
                {
                    ans += 11 - num;
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int result = solution.solution(45);
            System.Console.WriteLine(result);
        }
    }
}

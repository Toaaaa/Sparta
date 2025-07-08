using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/87390
        /// </summary>

        public class Solution
        {
            public int[] solution(int n, long left, long right)
            {
                int length = (int)(right - left + 1); // right - left 는 10^5 보다 작아서 int 변환 가능.
                int[] answer = new int[length];

                for (int i = 0; i < length; i++)
                {              
                    answer[i] = GetValue(n, left + i);
                }
                return answer;
            }
            public int GetValue(int n, long index)
            {
                long row = index / n;
                long col = index % n;

                return (int)Math.Max(row, col) + 1;
            }

        }
    }
}

using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/12927
        /// </summary>

        public class Solution
        {
            public long solution(int n, int[] works)
            {
                if(n >= works.Sum()) return 0; // 모든 작업을 완료할 수 있는 경우, 0 반환

                while (n > 0)
                {
                    int max = works.Max();
                    if (max == 0) break; // 모든 작업이 완료된 경우

                    works = DecreaseMax(max, works);
                    n--;
                }

                long answer = 0;
                for(int i = 0; i < works.Length; i++)
                {
                    answer += (long)Math.Pow(works[i], 2); // 오버플로우 방지 long 캐스팅
                }
                return answer;
            }

            public int[] DecreaseMax(int max,int[] work)
            {
                int index = Array.IndexOf(work, max);

                work[index] = max - 1;

                return work;
            }
        }
    }
}

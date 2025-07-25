using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/118667
        /// </summary>

        public class Solution
        {
            public long solution(int[] queue1, int[] queue2)
            {
                Queue<int> q1 = new Queue<int>(queue1);
                Queue<int> q2 = new Queue<int>(queue2);
                long answer = 0;
                long diff = 0; // queue1가 더 큰만큼 +, 작으면 - 로 표시. diff 가 0이면 둘의 합이 같아지는 순간.
                long sum1 = queue1.Select(x => (long)x).Sum();
                long sum2 = queue2.Select(x => (long)x).Sum();

                diff = (sum1 - sum2); // 두 큐의 합이 같아지는 순간을 찾기 위해서.

                // 두 수의 합의 홀수는 불가능한 경우.
                if((sum1 + sum2) % 2 != 0) return -1;

                while (diff != 0)
                {
                    if(diff > 0) // queue1이 더 크면 queue1에서 하나 꺼내서 queue2에 넣음.
                    {
                        answer++; // 큐를 옮길 때마다 카운트 증가.
                        if(q1.Count == 0) return -1; // queue1이 비어있으면 불가능한 경우.
                        int num = q1.Dequeue();
                        q2.Enqueue(num);
                        diff -= (long)num * 2; // queue1에서 꺼낸 수를 두 번 빼줌.
                    }
                    else // queue2가 더 크면 queue2에서 하나 꺼내서 queue1에 넣음.
                    {
                        answer++; // 큐를 옮길 때마다 카운트 증가.
                        if(q2.Count == 0) return -1; // queue2가 비어있으면 불가능한 경우.
                        int num = q2.Dequeue();
                        q1.Enqueue(num);
                        diff += (long)num * 2; // queue2에서 꺼낸 수를 두 번 더해줌.
                    }

                    if(answer > (queue1.Length + queue2.Length) *2) return -1;
                }
                return answer;
            }
        }
    }
}

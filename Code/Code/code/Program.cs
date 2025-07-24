using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42862
        /// </summary>

        public class Solution
        {
            public int solution(int n, int[] lost, int[] reserve)
            {
                int answer = 0;
                List<bool> wearhave = new List<bool>(new bool[n]);
                List<bool> reservehave = new List<bool>(new bool[n]);

                for(int i = 0; i < n; i++) wearhave[i] = true; //다 있다고 가정
                foreach (int i in lost) wearhave[i - 1] = false; // 그 중 없는 경우 표시
                foreach (int i in reserve) reservehave[i - 1] = true; // 여벌이 있는 경우 표시

                for(int i= 0; i < wearhave.Count; i++)
                {
                    // 만약 현재 학생이 "체육복 or 여분"을 가지고 있다면
                    if (wearhave[i] || reservehave[i])
                    {
                        answer++;
                        continue;
                    }
                    // 만약 현재 학생이 "체육복 & 여분"을 가지고 있지 않다면
                    if (!wearhave[i])
                    {
                        // 양옆의 낮은사람 => 높은사람 순으로 확인하고, 가지고 있는 사람중 낮은 번호의 사람에게 빌린다
                        if (i > 0)
                        {
                            if(i == n - 1) // i 가 마지막 순번인 경우
                            {
                                // 낮은 쪽만 확인
                                if (wearhave[i -1] && reservehave[i - 1])
                                {
                                    wearhave[i] = true; // 빌림
                                    reservehave[i - 1] = false; // 여벌이 있는 사람은 여벌을 잃음
                                    answer++;
                                }
                            }
                            else 
                            {
                                // 양옆 확인
                                if (wearhave[i - 1] && reservehave[i - 1]) // 왼쪽 사람이 여벌이 있는 경우
                                {
                                    wearhave[i] = true; // 빌림
                                    reservehave[i - 1] = false; // 여벌이 있는 사람은 여벌을 잃음
                                    answer++;
                                }
                                else if (wearhave[i + 1] && reservehave[i + 1]) // 오른쪽 사람이 여벌이 있는 경우
                                {
                                    wearhave[i] = true; // 빌림
                                    reservehave[i + 1] = false; // 여벌이 있는 사람은 여벌을 잃음
                                    answer++;
                                }
                            }
                        }
                        else // i 가 0번인 경우
                        {
                            if (wearhave[1] && reservehave[1])
                            {
                                wearhave[i] = true; // 빌림
                                reservehave[1] = false; // 여벌이 있는 사람은 여벌을 잃음
                                answer++;
                            }
                        }
                    }
                }

                return answer;
            }
        }
    }
}

using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/388351
        /// </summary>

        public class Solution
        {
            public int solution(int[] schedules, int[,] timelogs, int startday)
            {
                int answer = 0;
                bool[] late = new bool[schedules.Length];

                // schedules HHMM -> 분 변환
                for (int i = 0; i < schedules.Length; i++)
                {
                    schedules[i] = GetTime(schedules[i]);
                }

                // timelogs HHMM -> 분 변환
                for (int i = 0; i < timelogs.GetLength(0); i++)
                {
                    int[] row = GetRow(timelogs, i);
                    for (int j = 0; j < row.Length; j++)
                    {
                        timelogs[i, j] = GetTime(row[j]);
                    }
                }

                for (int i = 0; i < 7; i++)
                {
                    int weekday = (startday + i - 1) % 7 + 1; // 1~7
                    if (weekday == 6 || weekday == 7) continue;

                    for (int j = 0; j < schedules.Length; j++)
                    {
                        // 이미 지각한 경우는 건너뛰기
                        if (late[j]) continue;

                        int log = timelogs[j, i]; 
                        if (log - schedules[j] > 10)
                        {
                            late[j] = true;
                        }
                    }
                }

                for (int i = 0; i < late.Length; i++)
                {
                    if (!late[i]) answer++;
                }
                return answer;
            }

            public int GetTime(int hhmm)
            {
                return (hhmm / 100) * 60 + (hhmm % 100);
            }

            public int[] GetRow(int[,] arr, int rowIndex)
            {
                int cols = arr.GetLength(1);
                int[] row = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    row[j] = arr[rowIndex, j];
                }
                return row;
            }

        }
    }
}

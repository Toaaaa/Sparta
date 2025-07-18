using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/340213
        /// </summary>

        public class Solution
        {
            public string solution(string video_len, string pos, string op_start, string op_end, string[] commands)
            {
                // 시작전 스킵 체크
                int videoTime = GetTime(video_len);
                int startTime = GetTime(op_start);
                int endTime = GetTime(op_end);
                int posTime = GetTime(pos);

                if (IsBetween(startTime, endTime, posTime)) pos = op_end;
                foreach (var command in commands)
                {
                    if(command == "next")
                    {
                        posTime += 10;
                    }
                    else
                    {
                        posTime -= 10;
                    }

                    if(posTime < 0) posTime = 0; // 시간이 음수일 때는 0으로 초기화
                    if (IsBetween(startTime, endTime, GetTime(pos))) pos = op_end; // 스킵 구간 일때
                    if(posTime >= videoTime) pos = video_len; // 영상 끝에 도달했을 때
                }

                return ToTime(posTime);
            }

            public bool IsBetween(int start, int end, int pos)
            {
                if(start <= pos && pos <= end) return true;
                else return false;
            }

            public int GetTime(string time)
            {
                var times = time.Split(':');
                int minute = int.Parse(times[1]);
                int second = int.Parse(times[2]);

                return  minute * 60 + second;
            }
            public string ToTime(int time)
            {
                int minute = time / 60;
                int second = time % 60;

                return $"{minute:D2}:{second:D2}";
            }
        }
    }
}

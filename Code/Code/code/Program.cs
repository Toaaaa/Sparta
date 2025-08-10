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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/155651?language=csharp
        /// </summary>

        public class Solution
        {
            public int solution(string[,] book_time)
            {
                // book_time을 입장 시간 순으로 정렬
                int length = book_time.GetLength(0);
                var timeList = new List<Tuple<string, string>>();

                for (int i = 0; i < length; i++)
                {
                    timeList.Add(Tuple.Create(book_time[i, 0], book_time[i, 1]));
                }

                var sorted = timeList.OrderBy(t => TimeToMinutes(t.Item1)).ToArray();

                // 방 배정 시작
                Dictionary<int,int> rooms = new Dictionary<int, int>(); // key : 방번호, value : 끝나는 시간 << 비교시에는 시작하는 시간으로 비교하여 내용물 교체.
                rooms.Add(0, 0); // 방번호 0번은 00:00에 미리 등록

                for (int i = 0; i < sorted.GetLength(0); i++)
                {
                    int startTime = TimeToMinutes(sorted[i].Item1); // 시작 시간
                    int endTime = TimeToMinutes(sorted[i].Item2); // 끝나는 시간

                    // 방번호를 찾기
                    int roomNumber = -1;
                    for(int j = 0; j < rooms.Count; j++)
                    {
                        if ((rooms[j] + 10) - startTime <= 0)
                        {
                            roomNumber = j; // 해당 방 번호를 저장
                            break;
                        }
                    }

                    // 사용 가능한 방이 없다면 새 방을 추가
                    if (roomNumber == -1) roomNumber = rooms.Count;

                    rooms[roomNumber] = endTime;
                }

                return rooms.Count;
            }

            int TimeToMinutes(string time)
            {
                string[] parts = time.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);
                return hours * 60 + minutes;
            }


            static void Main(string[] args)
            {
                Solution solution = new Solution();
                //int ans = solution.solution([["15:00", "17:00"], ["16:40", "18:20"], ["14:20", "15:20"], ["14:10", "19:20"], ["18:20", "21:20"]]);
                //Console.WriteLine(ans);
            }
        }
    }
}

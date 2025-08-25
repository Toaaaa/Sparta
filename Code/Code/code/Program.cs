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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/1844
        /// </summary>

        public class Solution
        {
            public int solution(int[,] maps)
            {
                int n = maps.GetLength(0);
                int m = maps.GetLength(1);

                int[,] visited = new int[n, m]; // 이동 횟수를 기록하는 배열
                Queue<(int x, int y)> q = new Queue<(int, int)>();
                q.Enqueue((0, 0));
                visited[0, 0] = 1;

                int[] dx = new int[] { 0, 0, 1, -1 }; // 상하우좌
                int[] dy = new int[] { 1, -1, 0, 0 }; // 상하우좌

                while (q.Count > 0)
                {
                    var (x, y) = q.Dequeue();

                    for (int dir = 0; dir < 4; dir++)
                    {
                        int nx = x + dx[dir];
                        int ny = y + dy[dir];

                        if (nx >= 0 && ny >= 0 && nx < n && ny < m)
                        {
                            if (maps[nx, ny] == 1 && visited[nx, ny] == 0)
                            {
                                visited[nx, ny] = visited[x, y] + 1;
                                q.Enqueue((nx, ny));
                            }
                        }
                    }
                }

                return visited[n - 1, m - 1] == 0 ? -1 : visited[n - 1, m - 1];
                // queue를 다 돌렸는데도 도착지점에 도달 못했으면 -1 리턴 그게 아니면 이동 횟수 리턴.
            }

            static void Main(string[] args)
            {
                Solution solution = new Solution();
                //string dirs = "ULURRDLLU";

                //int answer = solution.solution(dirs);
                //Console.WriteLine(answer);
            }
        }
    }
}

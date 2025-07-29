using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42746
        /// </summary>

        public class Solution
        {
            public int solution(int n, int[,] wires)
            {
                int minDif = int.MaxValue;

                for (int i = 0; i < wires.GetLength(0); i++)
                {
                    // 1. 인접 리스트 초기화
                    List<int>[] graph = new List<int>[n + 1];
                    for (int j = 0; j <= n; j++)
                        graph[j] = new List<int>();

                    // 2. 전선 i를 끊고, 나머지는 그래프 구성
                    for (int j = 0; j < wires.GetLength(0); j++)
                    {
                        if (j == i) continue; // i번째 전선을 끊음

                        int a = wires[j, 0];
                        int b = wires[j, 1];
                        graph[a].Add(b);
                        graph[b].Add(a);
                    }

                    // 3. 임의의 노드에서 시작하여 연결된 송전탑 수 계산
                    bool[] visited = new bool[n + 1];
                    int groupCount = DFS(1, graph, visited); // 1번 송전탑부터 탐색

                    // 4. 나머지 송전탑은 n - groupCount
                    int diff = Math.Abs(groupCount - (n - groupCount));
                    minDif = Math.Min(minDif, diff);
                }

                return minDif;
            }

            int DFS(int node, List<int>[] graph, bool[] visited)
            {
                visited[node] = true;
                int count = 1;

                foreach (int neighbor in graph[node])
                {
                    if (!visited[neighbor])
                    {
                        count += DFS(neighbor, graph, visited);
                    }
                }
                return count;
            }

        }
    }
}

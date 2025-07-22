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
            public string[] solution(string[] players, string[] callings)
            {
                // players 배열을 각 Dictionary 전환
                Dictionary<string, int> playerIndex = new Dictionary<string, int>();
                Dictionary<int, string> playerRank = new Dictionary<int, string>();
                for (int i = 0; i < players.Length; i++)
                {
                    playerIndex[players[i]] = i;
                }
                for (int i = 0; i < players.Length; i++)
                {
                    playerRank[i] = players[i];
                }

                // callings 배열을 순회하며 선수의 순위를 변경
                for (int i = 0; i < callings.Length; i++)
                {
                    // 추월 전 선수의 순위
                    int before = playerIndex[callings[i]];
                    // 추월 당하는 선수의 이름
                    string loser = playerRank[before - 1];
                    // 순위 변경 (playerIndex 업데이트)
                    playerIndex[callings[i]] = before - 1;
                    playerIndex[loser] = before;
                    // 순위 변경 후 playerRank 업데이트
                    playerRank[before - 1] = callings[i];
                    playerRank[before] = loser;
                }
                // 변경이 끝난 Dictionary를 배열로 전환
                string[] answer = playerRank.Values.ToArray();
                return answer;
            }
        }
    }
}

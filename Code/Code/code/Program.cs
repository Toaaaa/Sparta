using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42579
        /// </summary>

        public class Solution
        {
            public int[] solution(string[] genres, int[] plays)
            {
                int[] answer = new int[] { };
                List<Tuple<string,int,int>> list = new List<Tuple<string,int,int>>(); // Tuple<장르 ,재생횟수, 고유번호>
                Dictionary<string,int> genreDict = new Dictionary<string,int>(); // 장르별 총합 재생횟수
                Dictionary<string, int> checkdDict = new Dictionary<string, int>(); // 장르별 누적 채택 횟수

                for(int i = 0; i < genres.Length; i++)
                {
                    list.Add(new Tuple<string,int, int>(genres[i],plays[i], i));

                    if (genreDict.ContainsKey(genres[i]))
                        genreDict[genres[i]] += plays[i];
                    else
                    {
                        genreDict.Add(genres[i], plays[i]);
                        checkdDict.Add(genres[i], 2);
                    }
                }
                list.Sort((a, b) => b.Item2.CompareTo(a.Item2)); // 재생횟수 내림차순 정렬
                var sortedGenre = genreDict.OrderByDescending(x => x.Value).Select(x => x.Key).ToList(); // 장르별 재생횟수 내림차순으로 list에 받아오기


                List<int> ans = new List<int>();
                for (int i = 0; i < sortedGenre.Count; i++)
                {
                    for (int j = 0; j < genres.Length; j++)
                    {
                        if (list[j].Item1 == sortedGenre[i] && checkdDict[sortedGenre[i]] > 0)
                        {
                            ans.Add(list[j].Item3);
                            checkdDict[sortedGenre[i]]--;
                            if(checkdDict[sortedGenre[i]] == 0) break;
                        }
                    }
                }

                answer = ans.ToArray();
                return answer;
            }

            static void Main(string[] args)
            {
                Solution solution = new Solution();

                //int answer = solution.solution(437674,3);
                //Console.WriteLine(answer);
            }
        }
    }
}

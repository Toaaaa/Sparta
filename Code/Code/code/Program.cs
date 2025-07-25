using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42578
        /// </summary>

        public class Solution
        {
            public int solution(string[,] clothes)
            {
                int answer = 1;
                HashSet<string> types = new HashSet<string>(); // 옷의 종류
                Dictionary<string, int> typeCount = new Dictionary<string, int>(); // 옷 종류별 개수

                for(int i = 0; i < clothes.GetLength(0); i++)
                {
                    string type = clothes[i, 1];
                    types.Add(type);
                    
                    if (typeCount.ContainsKey(type))
                    {
                        typeCount[type]++;
                    }
                    else
                    {
                        typeCount[type] = 1;
                    }
                }

                if(types.Count == 1)
                {
                    // 옷 종류가 하나뿐인 경우
                    answer = typeCount[types.First()];
                }
                else
                {
                    // 옷 종류가 여러개일 경우 조합식 계산 - 아무것도 안입은 경우(1개)
                    var type = types.ToArray();
                    foreach (var t in type)
                    {
                        // 2가지인 경우 => 0, 1, 2 개중 하나를 선택한다고 했을때 +1을 해준다.
                        answer *= (typeCount[t] + 1);
                    }

                    answer--;
                }
                
                return answer;
            }
        }
    }
}

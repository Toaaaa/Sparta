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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/12981
        /// </summary>

        public class Solution
        {
            public int[] solution(int n, string[] words)
            {
                int[] answer = {0, 0};
                HashSet<string> usedWords = new HashSet<string>();
                int num = 0;
                int count = 0;

                for (int i = 0; i < words.Length; i++)
                {
                    num = (i + 1) % n;
                    count = i / n;
                    if (num == 0) num = n;

                    // 이미 사용한 단어 or 단어 끝이 안맞는 경우 
                    if (usedWords.Contains(words[i]) || 
                        (i > 0 && words[i][0] != words[i - 1][words[i-1].Length -1]))
                    {
                        return new int[] {num, count + 1};
                    }
                    else
                    {
                        usedWords.Add(words[i]);
                    }
                }

                return answer;
            }

            static void Main(string[] args)
            {
                Solution solution = new Solution();
                string[] words = new string[] { "tank", "kick", "know", "wheel", "land", "dream", "mother", "robot", "tank" };

                int[] answer = solution.solution(3,words);
                Console.WriteLine($"[{string.Join(", ", answer)}]");
            }
        }
    }
}

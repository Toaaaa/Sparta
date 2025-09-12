using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/49993
        /// </summary>

        public class Solution
        {
            public int solution(string skill, string[] skill_trees)
            {
                int answer = 0;
                Queue<char> skillQueue = new Queue<char>(skill.ToCharArray());
                Queue<char> tempQueue = new Queue<char>();

                for (int i = 0; i < skill_trees.Length; i++)
                {
                    answer++;
                    tempQueue = new Queue<char>(skillQueue);
                    for(int j =0; j < skill_trees[i].Length; j++)
                    {
                        // 다음 진행 스킬이, 스킬 트리에 포함된 스킬인 경우
                        if (skill.Contains(skill_trees[i][j]))
                        {
                            if (tempQueue.Count > 0 && skill_trees[i][j] == tempQueue.Peek())
                                tempQueue.Dequeue();
                            else
                            {
                                answer--;
                                break;
                            }
                        }
                    }
                }
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

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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/49994
        /// </summary>

        public class Solution
        {
            public int solution(string dirs)
            {
                Tuple<int, int> current = new Tuple<int, int>(0, 0);
                HashSet<Tuple<int, int, string>> visited = new HashSet<Tuple<int, int, string>>();

                for(int i = 0; i < dirs.Length; i++)
                {
                    char direction = dirs[i];
                    switch (direction)
                    {
                        case 'U':
                            if(current.Item1 < 5)
                            {
                                var next = new Tuple<int, int>(current.Item1 + 1, current.Item2);
                                if (!visited.Contains(new Tuple<int, int, string>(current.Item1, current.Item2, "U")) && 
                                    !visited.Contains(new Tuple<int, int, string>(next.Item1, next.Item2, "D")))
                                {
                                    visited.Add(new Tuple<int, int, string>(current.Item1, current.Item2, "U"));
                                }
                                current = next;
                            }
                            break;
                        case 'D':
                            if(current.Item1 > -5)
                            {
                                var next = new Tuple<int, int>(current.Item1 - 1, current.Item2);
                                if (!visited.Contains(new Tuple<int, int, string>(current.Item1, current.Item2, "D")) && 
                                    !visited.Contains(new Tuple<int, int, string>(next.Item1, next.Item2, "U")))
                                {
                                    visited.Add(new Tuple<int, int, string>(current.Item1, current.Item2, "D"));
                                }
                                current = next;
                            }
                            break;
                        case 'L':
                            if(current.Item2 > -5)
                            {
                                var next = new Tuple<int, int>(current.Item1, current.Item2 - 1);
                                if (!visited.Contains(new Tuple<int, int, string>(current.Item1, current.Item2, "L")) && 
                                    !visited.Contains(new Tuple<int, int, string>(next.Item1, next.Item2, "R")))
                                {
                                    visited.Add(new Tuple<int, int, string>(current.Item1, current.Item2, "L"));
                                }
                                current = next;
                            }
                            break;
                        case 'R':
                            if(current.Item2 < 5)
                            {
                                var next = new Tuple<int, int>(current.Item1, current.Item2 + 1);
                                if (!visited.Contains(new Tuple<int, int, string>(current.Item1, current.Item2, "R")) && 
                                    !visited.Contains(new Tuple<int, int, string>(next.Item1, next.Item2, "L")))
                                {
                                    visited.Add(new Tuple<int, int, string>(current.Item1, current.Item2, "R"));
                                }
                                current = next;
                            }
                            break;
                    }
                }
                return visited.Count;
            }

            static void Main(string[] args)
            {
                Solution solution = new Solution();
                string dirs = "ULURRDLLU";

                int answer = solution.solution(dirs);
                Console.WriteLine(answer);
            }
        }
    }
}

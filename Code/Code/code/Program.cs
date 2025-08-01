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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42883
        /// </summary>

        public class Solution
        {
            public string solution(string number, int k)
            {
                Stack<char> stack = new Stack<char>();

                foreach (char c in number)
                {
                    while (stack.Count > 0 && k > 0 && stack.Peek() < c)
                    {
                        stack.Pop();
                        k--;
                    }
                    stack.Push(c);
                }
                while (k > 0)
                {
                    stack.Pop();
                    k--;
                }

                var result = stack.Reverse(); // Stack은 뒤집기
                return string.Concat(result); // << 문자열을 하나하나 더하기 보다 Concat을 사용하는것이 성능상 유리
            }

        static void Main(string[] args)
        {
            Solution solution = new Solution();
            string ans = solution.solution("4177252814", 4);
            Console.WriteLine(string.Join(", ", ans));
        }
    }
}

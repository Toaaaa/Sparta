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
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42628
        /// </summary>

        public class Solution
        {
            public int[] solution(string[] operations)
            {
                int[] answer = new int[] { };
                List<int> nums = new List<int>();
                Dictionary<int, int> dict = new Dictionary<int, int>();
                Stack<int> maxHeap = new Stack<int>();
                Stack<int> minHeap = new Stack<int>();

                for(int i = 0; i < operations.Length; i++)
                {
                    switch (operations[i])
                    {
                        case "D 1":
                            
                            break;
                        case "D -1":
                            
                            break;
                        default: // "I 숫자"
                            int num = int.Parse(operations[i].Split(' ')[1]);
                            if (dict.ContainsKey(num)) dict[num]++;
                            else dict.Add(num, 1);

                            if(num >= maxHeap.Peek()) maxHeap.Push(num);
                            if(num <= minHeap.Peek()) maxHeap.Push(num);

                            break;
                    }
                }
                return answer;
            }

            public int[] solution2(string[] operations)
            {
                int[] answer = new int[] { };
                Queue<int> heaps = new Queue<int>(); // 내림차순 정렬

                for (int i = 0; i < operations.Length; i++)
                {
                    switch (operations[i])
                    {
                        case "D 1":
                            if(heaps.Count > 0)
                                heaps.Dequeue();
                            break;
                        case "D -1":
                            if(heaps.Count > 0)
                            {
                                Queue<int> temps = new Queue<int>();
                                while (heaps.Count > 1)
                                    temps.Enqueue(heaps.Dequeue());
                                heaps.Dequeue();
                                heaps = temps;
                            }
                            break;
                        default: // "I 숫자"
                            int num = int.Parse(operations[i].Split(' ')[1]);
                            Queue<int> temp = new Queue<int>();

                            if (heaps.Count == 0)
                                heaps.Enqueue(num);
                            else if (heaps.Peek() <= num)
                            { 
                                temp.Clear();

                                temp.Enqueue(num);
                                while (heaps.Count > 0)
                                    temp.Enqueue(heaps.Dequeue());  
                                heaps = temp;
                            }
                            else
                            {
                                temp.Clear();

                                while (heaps.Count > 0 && heaps.Peek() >= num)
                                    temp.Enqueue(heaps.Dequeue());

                                temp.Enqueue(num);

                                while (heaps.Count > 0)
                                    temp.Enqueue(heaps.Dequeue());

                                heaps = temp;
                            }

                            break;
                    }
                }
                if (heaps.Count == 0) return new int[] { 0, 0 };
                if (heaps.Count == 1) return new int[] { heaps.Peek(), heaps.Peek() };
                return new int[] { heaps.Peek(), heaps.Last() };
            }

            static void Main(string[] args)
            {
                Solution solution = new Solution();

                //int answer = solution.solution([5, 4, 3, 2, 1]);
                //Console.WriteLine(answer);
            }
        }
    }
}

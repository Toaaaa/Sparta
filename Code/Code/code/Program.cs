using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/178870
        /// </summary>

        public class Solution
        {
            public int[] solution(int[] sequence, int k)
            {
                int[] answer = new int[] { };
                for(int i = 0; i < sequence.Length; i++)
                {
                    for(int j = i; j < sequence.Length; j++)
                    {
                        if(Sum(sequence, i, j) == k)
                        {
                            if(answer.Length == 0 || (j - i < answer[1] - answer[0]))
                            {
                                answer = new int[] { i, j };
                            }
                        }
                    }
                }
                return answer;
            }

            public int Sum(int[] sequence, int start, int end)
            {
                int sum = 0;
                for(int i = start; i <= end; i++)
                    sum += sequence[i];

                return sum;
            }
        }

        public class Solution2
        {
            public int[] solution(int[] sequence, int k)
            {
                int[] answer = new int[] { };
                // 이분 탐색으로 한번 줄이고 줄인 배열 시작 범위를 i 에 넣기.
                int left = 0;
                int right = sequence.Length - 1;
                int start = right;

                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    long sums = Sum(sequence, left, mid);

                    if (sums <= k || sums == -1)
                    {
                        start = mid;
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                for (int i = start; i < sequence.Length; i++)
                {
                    for (int j = i; j < sequence.Length; j++)
                    {
                        if (Sum(sequence, i, j) == k)
                        {
                            if (answer.Length == 0 || (j - i < answer[1] - answer[0]))
                            {
                                answer = new int[] { i, j };
                            }
                        }
                    }
                }
                return answer;
            }

            public long Sum(int[] sequence, int start, int end)
            {
                long sum = 0;
                for (int i = start; i <= end; i++)
                {
                    sum += sequence[i];
                    if (sum > int.MaxValue)
                        return -1; 

                }

                return sum;
            }
        }

        public class Solution3
        {
            public int[] solution(int[] sequence, int k)
            {
                int[] answer = new int[] { };
                HashSet<Tuple<int,int>> pairs = new HashSet<Tuple<int, int>>();
                int minDiff = int.MaxValue;
                int tupleStart = 0;
                int left = 0;
                int right = 0;
                long sum = sequence[left];


                while (left < sequence.Length && right < sequence.Length)
                {
                    if(sum < k)
                    {
                        right++;
                        if (right <= sequence.Length - 1)
                            sum += sequence[right];
                    }
                    else if (sum > k)
                    {
                        sum -= sequence[left];
                        left++;
                    }
                    else
                    {
                        // 일치하는 조합을 기록한 뒤, left ++ 해서 다음 조합을 찾기 << 이때 right가 left보다 작아져도 break;
                        // 똑같은 조합을 한번더 마주치면 break로 종료
                        if (!pairs.Contains(Tuple.Create(left, right)))
                        {
                            if(right - left < minDiff) minDiff = right - left; // 최소 길이 갱신
                            pairs.Add(Tuple.Create(left, right));
                            if(right == left)
                            {
                                right++;
                                if (right <= sequence.Length - 1)
                                {
                                    sum += sequence[right];
                                }
                                else
                                    break;
                            }
                            else if(left < right)
                            {
                                sum -= sequence[left];
                                if (left < right)
                                    left++;
                                else
                                    break;
                            }
                            else
                                break;
                        }
                        else
                            break;
                    }
                }

                // 기록된 left, right 조합들 선별작업 진행
                // 1. 후보군들 중 길이가 짧은 수열
                List<Tuple<int, int>> toRemove = new List<Tuple<int, int>>();
                foreach (var pair in pairs)
                {
                    int a = pair.Item1;
                    int b = pair.Item2;
                    if (b - a > minDiff)
                        toRemove.Add(pair);
                }

                foreach (var pair in toRemove)
                    pairs.Remove(pair);

                // 2. 시작 인덱스의 값이 가장 낮은 수열
                foreach (var pair in pairs)
                {
                    tupleStart = pairs.Min(p => p.Item1);
                }
                left = tupleStart;
                right = left + minDiff;

                return new int[] { left, right };
            }
        }

        public class Solution4
        {
            public int[] solution(int[] sequence, int k)
            {
                int[] answer = new int[] { };
                int minDiff = int.MaxValue;
                int left = 0;
                int right = 0;
                long sum = sequence[left];
                int ansLeft = 0; int ansRight = 0;


                while (left < sequence.Length && right < sequence.Length)
                {
                    if (sum < k)
                    {
                        right++;
                        if (right <= sequence.Length - 1)
                            sum += sequence[right];
                        else
                            break;
                    }
                    else if (sum > k)
                    {
                        sum -= sequence[left];
                        left++;
                        if (left > right && left < sequence.Length)
                        {
                            right = left;
                            sum = sequence[right];
                        }
                    }
                    else // sum == k
                    {
                        // 일치하는 조합을 기록한 뒤, left ++ 해서 다음 조합을 찾기 << 이때 right가 left보다 작아져도 break;
                        // 똑같은 조합을 한번더 마주치면 break로 종료
                        int currentDiff = right - left;
                        if (currentDiff < minDiff)
                        {
                            minDiff = currentDiff;
                            ansLeft = left;
                            ansRight = right;
                        }

                        sum -= sequence[left];
                        left++;

                        if (left > right && left < sequence.Length)
                        {
                            right = left;
                            sum = sequence[right];
                        }
                    }
                }

                return new int[] { ansLeft, ansRight };
            }
        }

        static void Main(string[] args)
        {
            Solution3 solution = new Solution3();
            int[] ans = solution.solution(new int[] { 1,2,3,4,5},7);
            Console.WriteLine(string.Join(", ", ans));
        }
    }
}

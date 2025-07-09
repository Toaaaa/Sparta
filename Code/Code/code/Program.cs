using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/181881
        /// </summary>

        public class Solution
        {
            public int solution(int[] arr)
            {
                int answer = 0;
                int[] arr2 = new int[arr.Length];
                arr2 = (int[])arr.Clone();

                while(true)
                {
                    answer++;
                    arr2 = (int[])arr.Clone();

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] >= 50 && arr[i] % 2 == 0)
                        {
                            arr[i] = arr[i] / 2;
                        }
                        else if (arr[i] < 50 && arr[i] % 2 != 0)
                        {
                            arr[i] = arr[i] * 2 + 1;
                        }
                    }

                    if (arr.SequenceEqual(arr2))
                        break;
                }

                return answer - 1 ;
            }
        }
    }
}

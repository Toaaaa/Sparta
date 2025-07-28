using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42746
        /// </summary>

        public class Solution
        {
            public string solution(int[] numbers)
            {
                var nums = numbers
                    .OrderByDescending(x => FirstDigit(x))
                    .ThenBy(x => x, Comparer<int>.Create((x,y) =>
                    { 
                        int xy = int.Parse(x.ToString() + y.ToString());
                        int yx = int.Parse(y.ToString() + x.ToString());

                        return yx.CompareTo(xy);
                    }
                    ));
                    
                // 예외처리
                if(nums.First() == 0) return "0";
                return string.Join("",nums);
            }

            int FirstDigit(int n)
            {
                while (n >= 10)
                {
                    n /= 10;
                }
                return n;
            }

        }
    }
}

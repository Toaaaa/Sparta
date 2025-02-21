using System.Formats.Asn1;


namespace code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solution(3,4, [1, 2, 3, 1, 2, 3, 1]));
        }
        static public int solution(int k, int m, int[] score)
        {
            int answer = 0;
            int[] arr = new int[score.Count() - score.Count() % m];
            score = score.OrderByDescending(x => x).ToArray();
            Array.Copy(score, arr, arr.Length);
            arr = arr.OrderBy(x => x).ToArray();
            for (int i = 0; i < arr.Length; i += m)
            {
                answer += arr[i] * m;
            }
            return answer;
        }

    }

}

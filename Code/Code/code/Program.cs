using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/389478
        /// </summary>

        public class Solution
        {
            public int solution(int n, int w, int num)
            {
                int h = (int)Math.Ceiling(n / (double)w); // 전체 행 수
                int[,] boxes = new int[h, w];

                int curr = 1;
                for (int row = 0; row < h; row++)
                {
                    if (row % 2 == 0) // 왼 → 오
                    {
                        for (int col = 0; col < w; col++)
                        {
                            if (curr > n) boxes[row, col] = 0;
                            else boxes[row, col] = curr++;
                        }
                    }
                    else // 오 → 왼
                    {
                        for (int col = w - 1; col >= 0; col--)
                        {
                            if (curr > n) boxes[row, col] = 0;
                            else boxes[row, col] = curr++;
                        }
                    }
                }

                // num 위치 찾기
                int targetRow = -1;
                int targetCol = -1;
                for (int row = 0; row < h; row++)
                {
                    for (int col = 0; col < w; col++)
                    {
                        if (boxes[row, col] == num)
                        {
                            targetRow = row;
                            targetCol = col;
                            break;
                        }
                    }
                    if (targetRow != -1) break;
                }

                // 끝에서부터 열을 스캔
                int count = 0;
                for (int row = h - 1; row >= 0; row--)
                {
                    if (boxes[row, targetCol] != 0)
                    {
                        count++;
                        if (boxes[row, targetCol] == num)
                            break;
                    }
                }

                return count;
            }
        }
    }
}

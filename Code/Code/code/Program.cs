using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        public class Solution
        {
            public int solution(string[] board)
            {
                // 길이가 3인 board를 2차원 배열로 변환.
                int rows = board.Length;
                int cols = board[0].Length;
                char[,] result = new char[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result[i, j] = board[i][j];
                    }
                }

                // 조건 처리 시작

                // 1. 모든 칸이 비어있음 == 시작하지 않음 => 가능한 조건.
                if (board.All(x => x == "...")) return 1;

                // 2. X의 개수가 O의 개수보다 많거나, O의 개수가 X의 개수보다 2개이상(많은 경우) 차이나는 경우
                int xCount = 0;
                int oCount = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (result[i, j] == 'X') xCount++;
                        else if (result[i, j] == 'O') oCount++;
                    }
                }
                if (!(oCount == xCount || oCount == xCount + 1)) return 0;

                // 각각의 승리 여부 체크
                bool xWin = IsWin(result, 'X');
                bool oWin = IsWin(result, 'O');


                // 3. X가 이긴 경우 O의 개수가 X의 개수와 같지 않음 => 불가능한 경우
                if (xWin && xCount != oCount) return 0;
                // 4. O가 이긴 경우 X의 개수보다 1개 많음이 아닌 경우 => 불가능한 경우
                if (oWin && oCount != xCount + 1) return 0;
                // 5. X와 O가 동시에 이긴 경우 => 불가능한 경우
                if(xWin&&oWin) return 0;


                // 나머지
                return 1;
            }

            public bool IsWin(char[,] board, char player)
            {
                for (int i = 0; i < 3; i++)
                {
                    // 가로
                    if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                        return true;
                    // 세로
                    if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                        return true;
                }

                // 대각선
                if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                    return true;
                if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                    return true;

                return false;
            }
        }
    }
}

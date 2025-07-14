using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/42587
        /// </summary>

        public class Solution
        {
            // location : priorities 배열의 인덱스 (0부터 시작)
            // return == answer : location 위치의 문서가 몇 번째로 인쇄되는지 (1부터 시작)
            public int solution(int[] priorities, int location)
            {
                int answer = 0;
                int[] prioritiesIndex = new int[priorities.Length]; // 인덱스 배열 생성
                for (int i = 0; i < priorities.Length; i++)
                {
                    prioritiesIndex[i] = i; // 인덱스 배열에 인덱스 저장
                }

                Queue<int> queue = new Queue<int>(priorities); // 배열을 큐로 변환
                Queue<int> indexQueue = new Queue<int>(prioritiesIndex); // 인덱스 큐 생성



                // while문으로 queue peek 로 뺸 값보다 더 큰값이 있으면 뒤에 넣고 다시 진행. 없으면 뺴고, 인덱스 큐 에서도 제거.
                // 가장 큰 값을 한번 뺄 때마다 answer += 1;
                while (true)
                {
                    int peek = queue.Peek(); // 큐의 맨 앞 요소를 확인
                    bool isMax = true; // 현재 peek 값이 최대값인지 여부


                    // 큐의 모든 요소를 순회하여 최대값 유무 체크
                    foreach (var item in queue)
                    {
                        if (peek < item) // peek 값보다 큰 값이 있으면
                        {
                            isMax = false; // 최대값이 아님
                            break; // foreach문 종료
                        }
                    }

                    // 최대값 여부에 따른 if / else
                    if (isMax) // peek 값이 최대값이면
                    {
                        answer++;
                        queue.Dequeue(); // 큐에서 제거
                        if (indexQueue.Peek() == location) // 인덱스 큐의 맨 앞이 location과 같으면
                        {
                            return answer; // 현재 answer 반환
                        }
                        indexQueue.Dequeue(); // 인덱스 큐에서도 제거
                    }
                    else // peek 값이 최대값이 아니면
                    {
                        queue.Enqueue(queue.Dequeue()); // 맨 앞 요소를 뒤로 보내기
                        indexQueue.Enqueue(indexQueue.Dequeue()); // 인덱스 큐도 동일하게 처리
                    }
                }
            }

        }
    }
}

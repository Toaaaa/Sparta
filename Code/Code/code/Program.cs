using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    internal class Program
    {
        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/258712
        /// </summary>

        public class Solution
        {
            public int solution(string[] friends, string[] gifts)
            {
                int n = friends.Length;
                Dictionary<string, int> nameToIndex = new();
                for (int i = 0; i < n; i++) nameToIndex[friends[i]] = i;

                int[,] giveCount = new int[n, n];
                int[] giveTotal = new int[n];
                int[] receiveTotal = new int[n];

                foreach (var gift in gifts)
                {
                    var parts = gift.Split(' ');
                    int giver = nameToIndex[parts[0]];
                    int receiver = nameToIndex[parts[1]];

                    giveCount[giver, receiver]++;
                    giveTotal[giver]++;
                    receiveTotal[receiver]++;
                }

                int[] giftIndex = new int[n];
                for (int i = 0; i < n; i++)
                    giftIndex[i] = giveTotal[i] - receiveTotal[i];

                int[] nextMonthGifts = new int[n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j) continue;

                        if (giveCount[i, j] > giveCount[j, i])
                        {
                            nextMonthGifts[i]++;
                        }
                        else if (giveCount[i, j] == giveCount[j, i])
                        {
                            if (giftIndex[i] > giftIndex[j])
                                nextMonthGifts[i]++;
                        }
                    }
                }

                return nextMonthGifts.Max();
            }
        }
    }
}

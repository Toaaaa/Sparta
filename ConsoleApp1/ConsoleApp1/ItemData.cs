using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class ItemData//상점의 데이터 및 아이템들의 데이터
    {
        public static List<Item> items = new List<Item>
            {
                new Item("낡은 검", 0, 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600),
                new Item("청동 도끼", 0, 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500),
                new Item("스파르타의 창", 0, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2500),
                new Item("수련자 갑옷", 1, 5, "수련에 도움을 주는 갑옷입니다.", 1000),
                new Item("무쇠갑옷", 1, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000),
                new Item("스파르타의 갑옷", 1, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500),
                new Item("합격 목걸이",2 ,777 ,777 , "그에게 주어지는 합격 목걸이.", 77777),
            };// 이름 + "아이템 타입" + 파라미터[] + "아이템 설명" + 가격


    }
}

using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static int currentStage = 0;
        static Player player = new Player("null", new Job(Job.JobType.전사));

        static void Main(string[] args)
        {
            // 사전에 저장된 데이터 체크, 불러오기
            string filePath = "playerData.json";
            Player loadedPlayer = LoadPlayerData(filePath) ?? player;

            if(loadedPlayer.Name == "null")// 사전에 저장된 데이터가 없는 경우.
            {
                currentStage = 1;//이름 설정 시작.
            }
            else
            {
                Console.WriteLine("이전에 저장된 데이터가 있습니다. 불러오시겠습니까? (Y/N)");
                string? answer = Console.ReadLine();
                if(answer == "Y")
                {
                    player = loadedPlayer;
                    currentStage = 3; //데이터 불러오고 메인 로비 시작.
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("이전의 데이터는 지워집니다. 새로운 플레이어 이름을 입력하세요.");
                    Console.WriteLine("");
                    Console.Write(">> ");
                    player.Name = Console.ReadLine();
                    CheckNullName(player);
                    currentStage = 2; //직업 선택 시작.
                }
            } // 데이터 불러오기 및 이름 설정 종료.

            //게임 실행
            while (true)
            {
                switch (currentStage) // 1~11까지의 커스텀 ui.
                {
                    case 0://데이터 불러오기 단계.
                        //스테이지 0
                        break;
                    case 1:
                        //이름 입력창
                        SetPlayerName(player);
                        break;
                    case 2:
                        //테스팅용으로만듬
                        Console.Clear();
                        Console.WriteLine("직업을 선택해주세요.");
                        Console.WriteLine("이름 : " + player.Name);
                        Console.ReadLine();
                        //직업 선택창
                        break;
                    case 3:
                        //메인 로비
                        break;
                    case 4:
                        //플레이어 상태창
                        break;
                    case 5:
                        //인벤토리
                        break;
                    case 6:
                        //장착 관리
                        break;
                    case 7:
                        //상점
                        break;
                    case 8:
                        //아이템 구매
                        break;
                    case 9:
                        //아이템 판매
                        break;
                    case 10:
                        //던전 입장
                        break;
                    case 11:
                        //던전 결과창
                        break;
                    default:
                        //게임 종료
                        break;
                }
            }
        }

        static void SetPlayerName(Player player)
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.WriteLine("");
            Console.Write(">> ");
            player.Name = Console.ReadLine();

            CheckNullName(player);
            currentStage = 2;
        }
        static void CheckNullName(Player player)
        {
            if (player.Name == "null")
            {
                player.Name = "이름을 null로 설정하다니, 용서하지 않겠다. 오늘부터 니 이름은 이제부터 null 이다";
            }
            if (player.Name == "")
            {
                player.Name = "이름없음";
            }
        }

        static void SavePlayerData(Player player, string filePath)//게임 종료시 플레이어 데이터 저장. SavePlayerData(loadedPlayer, filePath);
        {
            string json = JsonSerializer.Serialize(player);
            File.WriteAllText(filePath, json);
        }
        static Player? LoadPlayerData(string filePath)//처음 시작하는 경우 파일이 없을 수 있기에 null 허용.
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Player>(json);
            }
            else
            {
                return null;
            }

        }

    }
}

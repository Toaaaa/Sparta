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
            //아이템 데이터 불러오기.
            ItemData.ItemDataMade();
            //플레이어 데이터 체크, 불러오기.
            string filePath = "playerData.json";
            Player loadedPlayer = LoadPlayerData(filePath) ?? player;

            if(loadedPlayer.Name == "null")// 사전에 저장된 데이터가 없는 경우.
            {
                currentStage = 1;//이름 설정 시작.
                Console.Clear();
            }
            else
            {
                Console.WriteLine("이전에 저장된 데이터가 있습니다. 불러오시겠습니까? (Y/N)");
                string? answer = Console.ReadLine();
                if(answer == "Y"|| answer == "y")
                {
                    player = loadedPlayer;
                    currentStage = 3; //데이터 불러오고 메인 로비 시작.
                    Console.Clear();
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
                    Console.Clear();
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
                        //직업 선택창
                        SetPlayerJob(player);
                        break;
                    case 3:
                        //메인 로비
                        MainLobby(player);
                        break;
                    case 4:
                        //플레이어 상태창
                        PlayerStatus(player);
                        break;
                    case 5:
                        //인벤토리
                        Inventory(player);
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
            Console.Clear();
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
        static void SetPlayerJob(Player player)
        {
            Console.WriteLine("직업을 선택해주세요.");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 도적");
            Console.WriteLine("3. 개발자");
            Console.WriteLine("");
            Console.Write(">> ");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    player.Job = new Job(Job.JobType.전사);
                    break;
                case "2":
                    player.Job = new Job(Job.JobType.도적);
                    break;
                case "3":
                    player.Job = new Job(Job.JobType.개발자);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    SetPlayerJob(player);
                    break;
            }
            currentStage = 3;
            Console.Clear();
        }
        static void MainLobby(Player player)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 플레이어 상태창");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 입장");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine("6. 저장후 종료");
            ConReadLine();
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    currentStage = 4;
                    Console.Clear();
                    break;
                case "2":
                    currentStage = 5;
                    Console.Clear();
                    break;
                case "3":
                    currentStage = 7;
                    Console.Clear();
                    break;
                case "4":
                    currentStage = 10;
                    Console.Clear();
                    break;
                case "5":
                    //휴식하기
                    Console.Clear();
                    break;
                case "6":
                    SavePlayerData(player, "playerData.json");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    MainLobby(player);
                    break;
            }
        }
        static void PlayerStatus(Player player)
        {
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine(player.Name + $" ({player.Job?.Type})");
            Console.WriteLine($"공격력 : {player.Attack}");
            Console.WriteLine($"방어력 : {player.Defense}");
            Console.WriteLine($"체력 : {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            ConReadLine();
            string? input = Console.ReadLine();
            if (input == "0")
            {
                currentStage = 3;
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                PlayerStatus(player);
            }
        }
        static void Inventory(Player player)
        {
            Console.WriteLine("[아이템 목록]");
            for(int i =0; i < player.Inven.Count; i++)
            {
                Console.WriteLine($"- {i+1} {player.Inven[i].EquipString()}{player.Inven[i].Name}   |  {player.Inven[i].ReturnInfo()}   |  {player.Inven[i].Description}");
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            ConReadLine() ;
            string? input = Console.ReadLine();
            if (input == "0") { currentStage = 3;}
            else
            {
                if(int.TryParse(input,out int num))//정수값 입력시
                {
                    if(num >= 1 || num <= player.Inven.Count)//범위내의 값을 입력시
                    {
                        player.EquipTry(player.Inven[num]); //장착or해제
                        Console.Clear();
                        Inventory(player);
                    }
                    else//범위밖의 값을 입력시
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        Inventory(player);
                    }
                }
                else//정수값이 아닌값을 입력시
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Inventory(player);
                }
            }
        }

        static void ConReadLine()
        {
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
        }

        static void SavePlayerData(Player player, string filePath)//게임 종료시 플레이어 데이터 저장. SavePlayerData(loadedPlayer, filePath);
        {
            string json = JsonSerializer.Serialize(player);
            File.WriteAllText(filePath, json);
        }
        static Player? LoadPlayerData(string filePath)//처음 시작하는 경우 파일이 없을 수 있기에 null 허용.
        {
            if (File.Exists(filePath)) //파일이 존재
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

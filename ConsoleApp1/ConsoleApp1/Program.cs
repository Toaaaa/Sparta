using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using static ConsoleApp1.Item;

namespace ConsoleApp1
{
    internal class Program
    {
        static int currentStage = 0;
        static Player player = new Player("null", new Job(Job.JobType.전사));

        static void Main(string[] args)
        {
            //플레이어 데이터 체크, 불러오기.
            string filePath = "playerData.json";
            Player loadedPlayer = LoadPlayerData(filePath) ?? player;

            if (loadedPlayer.Name == "null")// 사전에 저장된 데이터가 없는 경우.
            {
                currentStage = 1;//이름 설정 시작.
                Console.Clear();
            }
            else
            {
                Console.WriteLine("이전에 저장된 데이터가 있습니다. 불러오시겠습니까? (Y/N)");
                string? answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                {
                    player = loadedPlayer;//플레이어 데이터 불러오기
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
                DrawTopAndBottomBorders(40);
                switch (currentStage) // 1~11까지의 커스텀 ui.
                {
                    case 0://데이터 불러오기 단계.
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
                        //휴식하기
                        Rest(player);
                        break;
                    case 7:
                        //상점
                        Shop(player);
                        break;
                    case 8:
                        //아이템 구매]
                        ShopBuy(player);
                        break;
                    case 9:
                        //아이템 판매
                        ShopSell(player);
                        break;
                    case 10:
                        //던전 입장
                        EnterDungeon(player);
                        break;
                    default:
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
                    player.isRegistered = true;
                    currentStage = 3;
                    Console.Clear();
                    break;
                case "2":
                    player.Job = new Job(Job.JobType.도적);
                    player.isRegistered = true;
                    currentStage = 3;
                    Console.Clear();
                    break;
                case "3":
                    player.Job = new Job(Job.JobType.개발자);
                    player.isRegistered = true;
                    currentStage = 3;
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("");
                    //SetPlayerJob(player);
                    break;
            }
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
                    currentStage = 6;
                    Console.Clear();
                    break;
                case "6":
                    SavePlayerData(player, "playerData.json", "itemData.json");//플레이어+아이템 데이터 저장.
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("");
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
                Console.WriteLine("");
                //PlayerStatus(player);
            }
        }
        static void Inventory(Player player)
        {
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < player.Inven.Count; i++)
            {
                Console.WriteLine($"- {i + 1} {player.Inven[i].EquipString()}{player.Inven[i].Name}   |  {player.Inven[i].ReturnInfo()}   |  {player.Inven[i].Description}");
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            ConReadLine();
            string? input = Console.ReadLine();
            if (input == "0") { currentStage = 3; Console.Clear(); }
            else
            {
                if (player.Inven.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("");
                    //Inventory(player);
                }//인벤토리에 아무것도 들어있지 않을시
                if (int.TryParse(input, out int num))//정수값 입력시
                {
                    if (num >= 1 && num <= player.Inven.Count)//범위내의 값을 입력시
                    {
                        player.EquipTry(num - 1); //장착or해제
                        Console.Clear();
                        //Inventory(player);
                    }
                    else//범위밖의 값을 입력시
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("");
                        //Inventory(player);
                    }
                }
                else//정수값이 아닌값을 입력시
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("");
                    //Inventory(player);
                }
            }
        }
        static void Shop(Player player)
        {
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < ItemData.items?.Count; i++)//샵 아이템 데이터 for문.
            {
                Console.WriteLine($"- {ItemData.items?[i].Name}   |  {ItemData.items?[i].ReturnInfo()}   |  {ItemData.items?[i].Description}   |  {CheckBought(player, ItemData.items?[i])}");
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            ConReadLine();
            string? input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    currentStage = 3;
                    Console.Clear();
                    break;
                case "1":
                    currentStage = 8;
                    Console.Clear();
                    break;
                case "2":
                    currentStage = 9;
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("");
                    break;
            }
        }
        static void ShopBuy(Player player)
        {
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < ItemData.items?.Count; i++)//샵 아이템 데이터 for문.
            {
                Console.WriteLine($"- {i + 1} {ItemData.items?[i].Name}   |  {ItemData.items?[i].ReturnInfo()}   |  {ItemData.items?[i].Description}   |  {CheckBought(player, ItemData.items?[i])}");
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine($"1~{ItemData.items?.Count + 1}. 구매하기");
            ConReadLine();
            string? input = Console.ReadLine();
            if (input == "0") { currentStage = 7; Console.Clear(); }//상점 화면으로 돌아가기.
            else
            {
                if (int.TryParse(input, out int num))//정수값 입력시
                {
                    if (num >= 1 && num <= ItemData.items?.Count)//범위내의 값을 입력시
                    {
                        //구매함수 작동 (이미구매상태//금액충분구매//금액부족구매)
                        Console.Clear();
                        TryBuy(player, ItemData.items[num - 1]);
                        //ShopBuy(player);
                    }
                    else//범위밖의 값을 입력시
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("");
                        //ShopBuy(player);
                    }
                }
                else//정수값이 아닌값을 입력시
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("");
                    //ShopBuy(player);
                }
            }
        }
        static void ShopSell(Player player)//여기서 나가기 >> current =7
        {
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < player.Inven.Count; i++)
            {
                Console.WriteLine($"- {i + 1} {player.Inven[i].EquipString()}{player.Inven[i].Name}   |  {player.Inven[i].ReturnInfo()}   |  {player.Inven[i].Description}   |  {player.Inven[i].Gold} G");
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            if (player.Inven.Count > 0)
                Console.WriteLine($"1~{ItemData.items?.Count + 1}. 판매하기");
            ConReadLine();
            string? input = Console.ReadLine();
            if (input == "0") { currentStage = 7; Console.Clear(); }//상점 화면으로 돌아가기.
            else
            {
                if (player.Inven.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("");
                    ShopSell(player);
                }//인벤토리에 아무것도 들어있지 않을시
                if (int.TryParse(input, out int num))//정수값 입력시
                {
                    if (num >= 1 && num <= player.Inven.Count)//범위내의 값을 입력시
                    {
                        //판매함수 작동(아
                        Console.Clear();
                        TrySell(player, num - 1);
                        ShopSell(player);
                    }
                    else//범위밖의 값을 입력시
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.WriteLine("");
                        ShopSell(player);
                    }
                }
                else//정수값이 아닌값을 입력시
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("");
                    ShopSell(player);
                }
            }
        }

        static void TryBuy(Player player, Item itemDT)
        {
            //구매함수 작동(이미구매상태//금액충분구매//금액부족구매)
            Item? item = player.Inven.FirstOrDefault(x => x.Name == itemDT.Name);//플레이어의 인벤에 있는 아이템에 접근, itemDT의 아이템과 동일한게 있으면 item에 저장.
            if (item?.Name != null)
            {
                //플레이어의 인벤에 동일한 아이템 존재
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else
            {
                //플레이어의 인벤에 없는 아이템 + 구매 시도
                if (itemDT.Gold <= player.Gold)
                {
                    //구매가 가능한 금액(재화 감소//인벤토리에 아이템추가)
                    player.Gold -= itemDT.Gold;
                    itemDT.PurchasedTime = DateTime.Now;
                    player.Inven.Add(itemDT);
                    Console.WriteLine("구매를 완료했습니다.");

                }
                else
                {
                    //구매가 불가능한 금액 
                    Console.WriteLine("Gold가 부족합니다.");
                }
            }
        }
        static void TrySell(Player player, int index)
        {
            Item item = player.Inven[index];

            if (item.isEquipped)
            {
                if (item.Type == ItemType.weapon)
                    player.Attack -= item.Value;
                else if (item.Type == ItemType.armor)
                    player.Defense -= item.Value;
                else if (item.Type == ItemType.acc)
                {
                    player.Attack -= item.Value;
                    player.Defense -= item.Value2;
                }
                else
                { Console.WriteLine("아이템 판매중 오류가 발생하였습니다."); }
            }//장칙중인 아이템을 판매시(능력치 반환) 
            TimeSpan timeDif = DateTime.Now - item.PurchasedTime;
            float fixedPricee = (1 - ((float)timeDif.TotalSeconds) / 3600);
            if (fixedPricee < 0)
                fixedPricee = 0;
            player.Gold += (int)(item.Gold * fixedPricee);//1시간 기준으로 100% ~ 0%의 금액으로 재판매 가능.
            Console.WriteLine($"{item.Name}을(를) {(float)Math.Round(timeDif.TotalHours,5)}시간이 지나, {(float)Math.Round(fixedPricee * 100,3)}%의 금액에 판매하였습니다.");
            player.Inven.Remove(item);//아이템 제거.
        }
        static string CheckBought(Player player, Item? itemDT)
        {
            Item? item = player.Inven.FirstOrDefault(x => x.Name == itemDT?.Name);//만약 플레이어의 인벤에 있는 아이템에 접근시...
            if (item?.Name != null)
            {
                //플레이어의 인벤에 동일한 아이템 존재
                return $"구매완료";
            }
            else
            {
                //플레이어의 인벤에 없는 아이템
                return $"{itemDT?.Gold} G";
            }

        }
        static void Rest(Player player)
        {
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)");
            Console.WriteLine($"현재 체력 : {player.Health} / {player.MaxHealth}");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 휴식하기");
            ConReadLine();
            string? input = Console.ReadLine();
            if (input == "0")
            {
                currentStage = 3;
                Console.Clear();
            }
            else if (input == "1")
            {
                if (player.Gold >= 500)
                {
                    player.Gold -= 500;
                    player.Health += 100;
                    if(player.Health > player.MaxHealth)
                        player.Health = player.MaxHealth;
                    Console.Clear();
                    Console.WriteLine("휴식을 취했습니다.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("골드가 부족합니다.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine("");
            }
        }
        static void EnterDungeon(Player player)
        {
            Console.WriteLine("입장하실 던전의 종류를 골라주세요.");
            Console.WriteLine("");
            Console.WriteLine("1. 쉬운 던전    | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전    | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전    | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기");
            ConReadLine();
            string? input = Console.ReadLine();
            if (input == "0")
            {
                currentStage = 3;
                Console.Clear();
            }
            else if(input == "1" || input == "2" || input == "3")
            {
                int p_gold = player.Gold;
                int p_health = player.Health;
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        DungeonResult(player, CheckDefense(player, 5, 1),p_health, p_gold);
                        break;
                    case "2":
                        Console.Clear();
                        DungeonResult(player, CheckDefense(player, 11, 2), p_health, p_gold);
                        break;
                    case "3":
                        Console.Clear();
                        DungeonResult(player, CheckDefense(player, 17, 3), p_health, p_gold);
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine("");
            }
        }
        static bool CheckDefense(Player player,int recomDef,int dungeonT)
        {
            Random rand = new Random();
            if (player.Defense >= recomDef)
            {
                //체력 변동
                int defdif = player.Defense - recomDef;
                int ranValue = rand.Next(20, 36);
                player.Health -= ranValue;
                //골드 변동
                switch (dungeonT)
                {
                    case 1:
                        player.Gold += 10 * rand.Next(player.Attack,(player.Attack*2) +1);
                        break;
                    case 2:
                        player.Gold += 17 * rand.Next(player.Attack, (player.Attack * 2) + 1);
                        break;
                    case 3:
                        player.Gold += 25 * rand.Next(player.Attack, (player.Attack * 2) + 1);
                        break;
                }
                return true;
            }
            else//방어력이 부족하면 40%의 확률로 던전실패
            {
                if(rand.Next(1, 100) <= 40)
                {
                    player.Health -= (int)(player.MaxHealth * 0.5);//체력 50% 감소.
                    return false;//실패
                }
                else//방어력 부족시 체력은 50% 감소 + 골드 보상 o
                {
                    //체력 변동
                    player.Health -= (int)(player.MaxHealth * 0.5);// 체력 50% 감소.
                    //골드 변동
                    switch (dungeonT)
                    {
                        case 1:
                            player.Gold += 1000 + 10 * rand.Next(player.Attack, (player.Attack * 2) + 1);
                            break;
                        case 2:
                            player.Gold += 1700 + 17 * rand.Next(player.Attack, (player.Attack * 2) + 1);
                            break;
                        case 3:
                            player.Gold += 2500 + 25 * rand.Next(player.Attack, (player.Attack * 2) + 1);
                            break;
                    }
                    return true;//성공
                }
            }
        }
        static void DungeonResult(Player player,bool b,int _hp, int _gold)//던전 결과창 , 체력이 부족해 사망시 게임오버.
        {
            if (b == false)//실패시
            {
                Console.WriteLine("던전 탐험에 실패하였습니다.");
            }
            else//성공시
            {
                player.DungeonClearCount++;
                player.AddExp();
                player.CheckLevelUp();
                //탐험 결과(체력,골드 변동 보여주기)               
            }
            if(player.Health <= 0)
            {
                Console.WriteLine("당신은 사망하였습니다");
                Environment.Exit(0);
            }//사망체크

            //탐험 결과(체력,골드 변동 보여주기)
            Console.WriteLine("");
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {_hp} -> {player.Health}");
            Console.WriteLine($"Gold {_gold} G -> {player.Gold} G");
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
                Console.WriteLine("");
            }
        }
        static void ConReadLine()
        {
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
        }

        static void SavePlayerData(Player player, string filePath, string itemData)//게임 종료시 플레이어 데이터 저장. SavePlayerData(loadedPlayer, filePath);
        {
            string json = JsonSerializer.Serialize(player);
            File.WriteAllText(filePath, json);//플레이어 데이터 저장
        }
        static Player? LoadPlayerData(string filePath)//처음 시작하는 경우 파일이 없을 수 있기에 null 허용.
        {
            if (File.Exists(filePath)) //파일이 존재
            {
                string json = File.ReadAllText(filePath);

                try { return JsonSerializer.Deserialize<Player>(json); }
                catch (JsonException)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
        static void DrawTopAndBottomBorders(int width)//여기에 레벨, 이름 (직업), 체력, 던전 클리어 횟수 등의 간단한 정보 표시.
        {
            // 상단 테두리 그리기
            Console.Write("+");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");

            // 중앙 빈 공간 출력
            if(player.isRegistered == false)
            {
                Console.WriteLine("플레이어 정보가 없습니다.");
                for (int i = 0; i < 2; i++) // 5줄의 빈 줄을 출력 (원하는 줄 수로 변경 가능)
                {
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Lv.{player.Level}    {player.Name} ({player.Job.Type}) ");
                Console.WriteLine($"체력 : {player.Health} / {player.MaxHealth} ");
                Console.WriteLine($"누적 던전 클리어 횟수 : {player.DungeonClearCount}");
            }

            // 하단 테두리 그리기
            Console.Write("+");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
        }
    }
}

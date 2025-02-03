using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        public bool isRegistered { get; set; }//플레이어가 등록되었는지 여부 확인.//기본값이 false 인것을 활용.
        public int Level { get; set; }
        public string? Name { get; set; }
        public Job? Job { get; set; }
        public int Score { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }

        public int DungeonClearCount;
        private int _exp{ get; set; }

        public List<Item> Inven { get; set; }

        public Player()//직렬화 역직렬화를 위한 기본 생성자.
        {
            Level = 1;
            Name = null;
            Job = null;
            Score = 0;
            Attack = 10;
            Defense = 5;
            Health = 100;
            MaxHealth = 100;
            Gold = 15000;
            DungeonClearCount = 0;
            Inven = new List<Item>();
        }
        public Player(string? name, Job? job)
        {
            Level = 1;
            Name = name;
            Job = job;
            Score = 0;
            Attack = 10;
            Defense = 5;
            Health = 100;
            MaxHealth = 100;
            Gold = 15000;
            DungeonClearCount = 0;
            Inven = new List<Item>();
        }

        public void levelUp()
        {
            switch (Job?.Type)
            {
                case Job.JobType.전사:
                    Attack += 2;
                    Defense += 2;
                    MaxHealth += 4;
                    break;
                case Job.JobType.도적:
                    Attack += 5;
                    Defense += 1;
                    MaxHealth += 2;
                    break;
                case Job.JobType.개발자:
                    Attack += 1000;
                    Defense += 1000;
                    MaxHealth += 1000;
                    break;
            }
        }
        public void AddExp()//경험치 획득
        {
            _exp += 1;
        }
        public void CheckLevelUp()//경험치가 레벨에 도달하면 레벨업
        {
            if (_exp >= Level)
            {
                Level++;
                _exp = 0;
                levelUp();
                Console.WriteLine("레벨업을 하였습니다.");
            }
        }

        public void EquipTry(int index)
        {
            int count = 0;
            Item item = Inven[index];//장착을 시도하는 아이템
            foreach (Item sametype in Inven)
            {
                if(sametype.Type == item.Type && sametype.isEquipped)//타입이 같고 장착중인 아이템이 있을경우, 장착 해제
                {
                    //장착 중인 아이템의 장착 해제 및 능력치 해제
                    if (sametype.Type == Item.ItemType.weapon)
                    {
                        Attack -= sametype.Value;
                    }
                    else if (sametype.Type == Item.ItemType.armor)
                    {
                        Defense -= sametype.Value;
                    }
                    else
                    {
                        Attack -= sametype.Value;
                        Defense -= sametype.Value2;
                    }
                    if(Inven.Count > count)
                    {
                        Item temp = Inven[count];
                        temp.isEquipped = false;
                        Inven[count] = temp;
                    }

                    if(count == index)//장착을 시도하는 아이템이 장착중인 아이템일경우, 장착 해제 후 함수 종료.
                    {
                        return;
                    }
                    else
                    {
                        break;
                    }
                }
                count++;
            }
            if (item.isEquipped)//장착중일경우, 장착 해제
            {
                item.isEquipped = false;
                if(item.Type == Item.ItemType.weapon)
                {
                    Attack -= item.Value;
                }
                else if (item.Type == Item.ItemType.armor)
                {
                    Defense -= item.Value;
                }
                else
                {
                    Attack -= item.Value;
                    Defense -= item.Value2;
                }
            }
            else//장착중이 아닐경우, 장착
            {
                item.isEquipped =true;
                if (item.Type == Item.ItemType.weapon)
                {
                    Attack += item.Value;
                }
                else if (item.Type == Item.ItemType.armor)
                {
                    Defense += item.Value;
                }
                else
                {
                    Attack += item.Value;
                    Defense += item.Value2;
                }
            }
            Inven[index] = item;//변경된 아이템 정보를 다시 저장.
        }
    }
}

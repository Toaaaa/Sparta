using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        public int Level { get; set; }
        public string? Name { get; set; }
        public Job? Job { get; set; }
        public int Score { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }

        public List<Item> Inven;

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
            Gold = 1500;
            Inven = new List<Item>();
        }

        public void levelUp()
        {
            switch (Job?.Type)
            {
                case Job.JobType.전사:
                    Attack += 10;
                    Defense += 5;
                    MaxHealth += 20;
                    break;
                case Job.JobType.도적:
                    Attack += 15;
                    Defense += 3;
                    MaxHealth += 10;
                    break;
                case Job.JobType.개발자:
                    Attack += 1000;
                    Defense += 1000;
                    MaxHealth += 1000;
                    break;
            }
        }

        public void EquipTry(Item item)
        {
            if(item.isEquipped)//장착중일경우, 장착 해제
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
        }
    }
}

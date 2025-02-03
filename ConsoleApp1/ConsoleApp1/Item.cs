using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public struct Item
    {
        public Item(string? name, int typenum, int value, string disc, int gold)
        {
            Name = name;
            Type = (ItemType)typenum;
            Value = value;
            Description = disc;
            Gold = gold;
        }
        public Item(string? name, int typenum, int value, int value2, string disc, int gold)//acc 생성자
        {
            Name = name;
            Type = (ItemType)typenum;
            Value = value;
            Value2 = value2;
            Description = disc;
            Gold = gold;
        }
        public enum ItemType
        {
            weapon,
            armor,
            acc,
        }

        public string? Name { get; set; }
        public ItemType Type { get; set; }//무기,방어구 타입 (중복착용 불가, 타입별 대응 능력치 고정.)
        public int Value { get; set; }
        public int Value2 { get; set; }//acc만 사용하는 2번째 능력치.
        public string Description { get; set; }
        public int Gold { get; set; }
        public DateTime PurchasedTime { get; set; }
        public bool isEquipped{ get; set; }//착용 여부


        public string EquipString()
        {
            if (isEquipped)
                return "[E]";
            else
                return "";
        }
        public string ReturnInfo()
        {
            if (Type == ItemType.weapon)
                return $"공격력 +{Value}";
            else if (Type == ItemType.armor)
                return $"방어력 +{Value}";
            else if (Type == ItemType.acc)
                return $"공격력 +{Value}, 방어력 +{Value2}";
            else
                return "null";
        }
    }
}

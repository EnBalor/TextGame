using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class InventoryList
    {
        public string Name { get; set; }
        public float Effect { get; set; }
        public string Info { get; set; }
        public bool IsBuy { get; set; }
        public bool IsSell { get; set; }
        public string ItemType { get; set; }
        public bool IsEquip { get; set; }
        public int Price { get; set; }

        public InventoryList(string name, float effect, string info, bool isBuy, string itemType, bool isEquip, int price)
        {
            Name = name;
            Effect = effect;
            Info = info;
            IsBuy = isBuy;
            ItemType = itemType;
            IsEquip = isEquip;
            Price = price;
        }

        public override string ToString()
        {
            if (ItemType == "무기")
            {
                return $"{Name} | 공격력 +{Effect} | {Info}";
            }

            else if (ItemType == "방어구")
            {
                return $"{Name} | 방어력 +{Effect} | {Info}";
            }

            else
            {
                return $"{Name} | {Info}";
            }
        }
    }
}

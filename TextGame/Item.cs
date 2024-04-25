using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class Item
    {
        public string Name { get; set; }
        public float Effect { get; set; }
        public string Info { get; set; }
        public string Price { get; set; }
        public bool IsBuy { get; set; }
        public string ItemType { get; set; }
        public bool IsEquip { get; set; }

        public Item(string name, float effect, string info, string price, bool isBuy, string itemType, bool isEquip)
        {
            Name = name;
            Effect = effect;
            Info = info;
            Price = price;
            IsBuy = isBuy;
            ItemType = itemType;
            IsEquip = isEquip;
        }

        public void Purchase()
        {
            Price = "구매완료";
            IsBuy = true;
        }

        public override string ToString()
        {
            if(ItemType == "무기")
            {
                return $"{Name} | 공격력 +{Effect} | {Info} | {Price}";
            }

            else if (ItemType == "방어구")
            {
                return $"{Name} | 방어력 +{Effect} | {Info} | {Price}";
            }

            else
            {
                return $"{Name} | | {Info} | {Price}";
            }
        }
    }
}

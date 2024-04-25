using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextGame
{
    internal class Shop
    {
        LeatherArmor leatherArmor = new LeatherArmor();
        IronArmor ironArmor = new IronArmor();
        SpartaArmor spartaArmor = new SpartaArmor();
        OldSword oldSword = new OldSword();
        BronzeAxe bronzeAxe = new BronzeAxe();
        SpartaSpear spartaSpear = new SpartaSpear();
        ChainSword chainSword = new ChainSword();

        MainScene mainScene = new MainScene();

        public List<Item> shopList = new List<Item>();
        public List<InventoryList> inventoryList = new List<InventoryList>();

        public bool sell = false;

        public void ShopStart()
        {
            shopList.Add(new Item(leatherArmor.name, leatherArmor.effect, leatherArmor.info, leatherArmor.price, leatherArmor.isBuy, leatherArmor.itemType, leatherArmor.isEquip));
            shopList.Add(new Item(ironArmor.name, ironArmor.effect, ironArmor.info, ironArmor.price, ironArmor.isBuy, ironArmor.itemType, ironArmor.isEquip));
            shopList.Add(new Item(spartaArmor.name, spartaArmor.effect, spartaArmor.info, spartaArmor.price, spartaArmor.isBuy, spartaArmor.itemType, spartaArmor.isEquip));
            shopList.Add(new Item(oldSword.name, oldSword.effect, oldSword.info, oldSword.price, oldSword.isBuy, oldSword.itemType, oldSword.isEquip));
            shopList.Add(new Item(bronzeAxe.name, bronzeAxe.effect, bronzeAxe.info, bronzeAxe.price, bronzeAxe.isBuy, bronzeAxe.itemType, bronzeAxe.isEquip));
            shopList.Add(new Item(spartaSpear.name, spartaSpear.effect, spartaSpear.info, spartaSpear.price, spartaSpear.isBuy, spartaSpear.itemType, spartaSpear.isEquip));
            shopList.Add(new Item(chainSword.name, chainSword.effect, chainSword.info, chainSword.price, chainSword.isBuy, chainSword.itemType, chainSword.isEquip));

            Print();
        }

        public void Print()
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G\n", Character.Instance.gold);

            Console.WriteLine("[아이템 목록]");

            foreach (var item in shopList)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            SelectMenu();
        }

        public void BuyItemPrint()
        {
            Console.Clear();
            bool isQuit = false;
            while(!isQuit)
            {
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine("{0} G\n", Character.Instance.gold);

                Console.WriteLine("[아이템 목록]");

                int index = 1;

                foreach (var item in shopList)
                {
                    Console.WriteLine($"{index}. {item}");
                    index++;
                }

                Console.WriteLine("");

                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");

                SelectManager.Instance.inputSelect();
                

                if (SelectManager.Instance.selectNum == 0)
                {
                    isQuit = true;
                    Print();
                }

                else
                {
                    ItemBuy();
                }
            }
            
        }

        private void SelectMenu()
        {
            SelectManager.Instance.inputSelect();
            SelectManager.Instance.returnStartScene();

            if(SelectManager.Instance.selectNum == 1)
            {
                BuyItemPrint();
            }

            else if (SelectManager.Instance.selectNum == 2)
            {
                ItemSell();
            }

            else
            {
                Console.WriteLine("잘못된 입력입니다.\n");
                Print();
            }
        }

        private void ItemBuy()
        {
            for(int i = 0; i < shopList.Count; i++)
            {
                if (SelectManager.Instance.selectNum == i + 1 && shopList[i].IsBuy == false)
                {
                    if (Character.Instance.gold - int.Parse(shopList[i].Price) >= 0)
                    {
                        Console.Clear();
                        Character.Instance.gold -= int.Parse(shopList[i].Price);
                        inventoryList.Add(new InventoryList(shopList[i].Name, shopList[i].Effect, shopList[i].Info, shopList[i].IsBuy, shopList[i].ItemType, shopList[i].IsEquip, int.Parse(shopList[i].Price)));
                        shopList[i].Purchase();
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Gold가 부족합니다.\n");
                    }

                    break;
                }

                else if (SelectManager.Instance.selectNum == i + 1 && shopList[i].IsBuy == true)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.\n");
                    break;
                }
            }
        }

        public void ItemSell()
        {
            sell = true;

            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요없는 아이템을 팔 수 있습니다.");

            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G\n", Character.Instance.gold);

            Console.WriteLine("[아이템 목록]");

            int index = 1;

            foreach (var item in Shop.Instance.inventoryList)
            {
                if (item.IsEquip == false)
                {
                    Console.WriteLine($"{index}. {item}");
                }

                else if (item.IsEquip == true)
                {
                    Console.WriteLine($"[E] {index}. {item}");
                }

                index++;
            }

            Console.WriteLine("\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.\n");

            Console.WriteLine("0. 나가기\n");

            SelectManager.Instance.inputSelect();

            if (SelectManager.Instance.selectNum == 0)
            {
                Print();
            }

            if (SelectManager.Instance.selectNum > 0 && Shop.instance.inventoryList.Count >= SelectManager.Instance.selectNum)
            {
                if (Shop.Instance.inventoryList[SelectManager.Instance.selectNum - 1].IsEquip == true)
                {
                    Shop.Instance.inventoryList[SelectManager.Instance.selectNum - 1].IsEquip = false;
                }

                if (Shop.Instance.inventoryList[SelectManager.Instance.selectNum - 1].IsEquip == false && Shop.Instance.inventoryList[SelectManager.Instance.selectNum - 1].ItemType == "방어구")
                {
                    Character.Instance.defence = 5f + (Character.Instance.level * 1f);

                }

                else if (Shop.Instance.inventoryList[SelectManager.Instance.selectNum - 1].IsEquip == false && Shop.Instance.inventoryList[SelectManager.Instance.selectNum - 1].ItemType == "무기")
                {
                    Character.Instance.attackPoint = 10f + (Character.Instance.level * 0.5f);
                }

                int sellGold = (int)(Shop.instance.inventoryList[SelectManager.Instance.selectNum - 1].Price * 0.85);
                Character.Instance.gold += sellGold;

                Shop.instance.inventoryList.RemoveAt(SelectManager.Instance.selectNum - 1);

                Console.WriteLine("{0} G를 획득했습니다.", sellGold);
                ItemSell();
            }

            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        private static Shop? instance;

        private Shop() { }

        public static Shop Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Shop();
                }

                return instance;
            }
        }
    }
}

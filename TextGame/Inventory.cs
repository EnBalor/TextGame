using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class Inventory
    {
        bool isQuit = false;

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

            Console.WriteLine("[아이템 목록]");

            foreach (var item in Shop.Instance.inventoryList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("1. 장착 관리");

            Console.WriteLine("0. 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            SelectManager.Instance.inputSelect();
            SelectManager.Instance.returnStartScene();

            if (SelectManager.Instance.selectNum == 1)
            {
                EquipItem();
            }
        }

        public void EquipItem()
        {
            while(!isQuit)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

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

                Console.WriteLine("0. 나가기\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");

                SelectManager.Instance.inputSelect();

                if (SelectManager.Instance.selectNum > 0 && SelectManager.Instance.selectNum <= Shop.Instance.inventoryList.Count)
                {
                    int selectedIndex = SelectManager.Instance.selectNum - 1;

                    if (Shop.Instance.inventoryList[selectedIndex].IsEquip == true)
                    {
                        Shop.Instance.inventoryList[selectedIndex].IsEquip = false;
                    }

                    else
                    {
                        foreach(var equipItem in Shop.Instance.inventoryList)
                        {
                            if(equipItem.IsEquip == true && equipItem.ItemType == Shop.Instance.inventoryList[selectedIndex].ItemType)
                            {
                                equipItem.IsEquip = false;
                                Character.Instance.defence = 5f;
                                Character.Instance.attackPoint = 10f;
                                break;
                            }
                        }

                        Shop.Instance.inventoryList[selectedIndex].IsEquip = true;
                    }

                    


                    if (Shop.Instance.inventoryList[selectedIndex].ItemType == "방어구")
                    {
                        Shop.Instance.inventoryList[selectedIndex].IsEquip = true;
                        Character.Instance.defence += Shop.Instance.inventoryList[selectedIndex].Effect;
                    }

                    else
                    {
                        Character.Instance.attackPoint += Shop.Instance.inventoryList[selectedIndex].Effect;
                    }

                        Shop.Instance.inventoryList[selectedIndex].IsEquip = true;
                }
;

                if (SelectManager.Instance.selectNum == 0)
                {
                    isQuit = true;
                    Print();
                }
            }
            
        }
    }
}

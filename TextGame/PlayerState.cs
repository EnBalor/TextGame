using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class PlayerState
    {
        public void Print()
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Console.WriteLine("Lv. {0}", Character.Instance.level);

            Console.WriteLine("{0} ( {1} )", Character.Instance.name, Character.Instance.job);
            Console.WriteLine("공격력 : {0}", Character.Instance.attackPoint);
            Console.WriteLine("방어력 : {0}", Character.Instance.defence);

            for (int i = 0; i < Shop.Instance.inventoryList.Count; i++)
            {
                if (Shop.Instance.inventoryList[i].IsEquip == true && Shop.Instance.inventoryList[i].ItemType == "방어구")
                {
                    Console.WriteLine("방어력 : {0} (+{1})", Character.Instance.defence, Shop.Instance.inventoryList[i].Effect);
                }

                else if (Shop.Instance.inventoryList[i].IsEquip == true && Shop.Instance.inventoryList[i].ItemType == "무기")
                {
                    Console.WriteLine("공격력 : {0} (+{1})", Character.Instance.attackPoint, Shop.Instance.inventoryList[i].Effect);
                }
            }
            
            Console.WriteLine("체  력 : {0}", Character.Instance.healthPoint);
            Console.WriteLine("Gold : {0}\n", Character.Instance.gold);

            Console.WriteLine("0. 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            ReturnScene();
        }

        public void ReturnScene()
        {
            SelectManager.Instance.inputSelect();

            SelectManager.Instance.returnStartScene();
        }
    }
}

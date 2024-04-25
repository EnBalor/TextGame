using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class StartScene
    {
        public void Print()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식하기");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            SceneMove();
        }

        public void SceneMove()
        {
            SelectManager.Instance.inputSelect();

            if (SelectManager.Instance.selectNum == 1)
            {
                PlayerState playerState = new PlayerState();
                playerState.Print();
            }

            else if (SelectManager.Instance.selectNum == 2)
            {
                Inventory inventory = new Inventory();
                inventory.Print();
            }

            else if (SelectManager.Instance.selectNum == 3)
            {
                Shop.Instance.ShopStart();
            }

            else if (SelectManager.Instance.selectNum == 4)
            {
                Dungeon dungeon = new Dungeon();
                dungeon.SelectLevel();
            }

            else if (SelectManager.Instance.selectNum == 5)
            {
                Tavern tavern = new Tavern();
                tavern.Rest();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("유효하지 않은 숫자입니다.");
                Print();
            }
        }
    }
}

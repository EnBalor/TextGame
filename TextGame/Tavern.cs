using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextGame
{
    internal class Tavern
    {
        public void Rest()
        {
            Console.WriteLine("휴식하기");
            Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0}\n", Character.Instance.gold);
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n");

            SelectManager.Instance.inputSelect();

            SelectManager.Instance.returnStartScene();

            if(SelectManager.Instance.selectNum == 1)
            {
                if(Character.Instance.gold >= 500)
                {
                    Character.Instance.healthPoint = 100;
                    Console.WriteLine("체력이 회복되었습니다.\n");
                }
                
                else
                {
                    Console.WriteLine("소지금이 부족합니다.");
                }

                Console.WriteLine("0. 나가기");
                SelectManager.Instance.inputSelect();
                SelectManager.Instance.returnStartScene();
            }

            else
            {
                Console.WriteLine("잘못된 입력입니다.\n");
                Rest();
            }
        }
    }
}

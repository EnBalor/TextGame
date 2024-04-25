using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class Dungeon
    {
        Random defeat = new Random();
        Random loseHP = new Random();
        Random randomGold = new Random();

        float recomendDef;

        public void SelectLevel()
        {
            Console.WriteLine("던전 입장");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. 쉬운 던전 | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전 | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전 | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.\n");

            SelectManager.Instance.inputSelect();

            if(SelectManager.Instance.selectNum == 1)
            {
                EasyDungeon();
            }

            else if (SelectManager.Instance.selectNum == 2)
            {
                NormalDungeon();
            }

            else if (SelectManager.Instance.selectNum == 3)
            {
                HardDungeon();
            }

            else if (SelectManager.Instance.selectNum == 0)
            {
                SelectManager.Instance.returnStartScene();
            }

            else
            {
                Console.WriteLine("잘못된 입력입니다.\n");
                SelectLevel();
            }
        }

        public void EasyDungeon()
        {
            recomendDef = 5f;
            int clearGold = 1000;

            if(Character.Instance.defence < recomendDef)
            {
                float rand = defeat.Next(0, 100);

                if(rand < 40)
                {
                    Defeat();
                }

                else
                {
                    Clear(clearGold, "쉬운");
                }
            }

            else
            {
                Clear(clearGold, "쉬운");
            }
        }

        public void NormalDungeon()
        {
            recomendDef = 11f;
            int clearGold = 1700;

            if (Character.Instance.defence < recomendDef)
            {
                float rand = defeat.Next(0, 100);

                if (rand < 40)
                {
                    Defeat();
                }

                else
                {
                    Clear(clearGold, "일반");
                }
            }

            else
            {
                Clear(clearGold, "일반");
            }
        }

        public void HardDungeon()
        {
            recomendDef = 17f;
            int clearGold = 2500;

            if (Character.Instance.defence < recomendDef)
            {
                float rand = defeat.Next(0, 100);

                if (rand < 40)
                {
                    Defeat();
                }

                else
                {
                    Clear(clearGold, "어려운");
                }
            }

            else
            {
                Clear(clearGold, "어려운");
            }
        }

        public void Defeat()
        {
            Character.Instance.healthPoint /= 2;
            Console.WriteLine("클리어 실패");
            Console.WriteLine("체력 {0} -> {1}", Character.Instance.healthPoint, Character.Instance.healthPoint /= 2);
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            SelectManager.Instance.inputSelect();

            if (SelectManager.Instance.selectNum == 0)
            {
                SelectLevel();
            }
        }

        public void Clear(int clearGold, string level)
        {
            float randLose = loseHP.Next(20, 35);
            float sumLose = recomendDef - Character.Instance.defence;
            float totalLose = randLose + sumLose;
            int randGold = randomGold.Next((int)Character.Instance.attackPoint, (int)Character.Instance.attackPoint * 2);
            Character.Instance.dungeonClear++;
            Character.Instance.LevelUp();

            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!");
            Console.WriteLine("{0} 던전을 클리어 하였습니다.\n", level);
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine("체력 {0} -> {1}", Character.Instance.healthPoint, Character.Instance.healthPoint -= totalLose);
            Console.WriteLine("Gold {0} -> {1}", Character.Instance.gold, Character.Instance.gold + clearGold + randGold);

            //Character.Instance.healthPoint -= totalLose;

            Character.Instance.gold = Character.Instance.gold + clearGold + randGold;

            Console.WriteLine("0. 나가기\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            

            SelectManager.Instance.inputSelect();

            if (SelectManager.Instance.selectNum == 0)
            {
                SelectLevel();
            }
        }
    }
}

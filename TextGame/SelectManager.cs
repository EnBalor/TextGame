using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class SelectManager
    {
        public int selectNum;

        public void inputSelect()
        {
            if(!int.TryParse(Console.ReadLine(), out selectNum))
            {
                Console.WriteLine("숫자를 입력해주세요.");
            }

            else
            {
                Console.Clear();
            }
        }

        public void returnStartScene()
        {
            if (selectNum == 0)
            {
                Console.Clear();
                StartScene startScene = new StartScene();
                startScene.Print();
            }
        }

        private static SelectManager instance;

        private SelectManager() { }

        public static SelectManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SelectManager();
                }

                return instance;
            }
        }
    }
}

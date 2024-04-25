using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class Character
    {
        public string name = "Chad";
        public string job = "전사";
        public int level = 1;
        public float attackPoint = 10f;
        public float defence = 5f;
        public float healthPoint = 100f;
        public int gold = 1500;
        public int dungeonClear = 0;

        public void LevelUp()
        {
            for(int i = 0; i < 5; i++)
            {
                if(dungeonClear == i)
                {
                    level++;
                }
            }

            attackPoint += 0.5f;
            defence += 1f;
        }

        private static Character? instance;

        private Character() { }

        public static Character Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Character();
                }

                return instance;
            }
        }
    }
}

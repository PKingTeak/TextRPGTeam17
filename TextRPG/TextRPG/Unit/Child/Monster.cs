using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit.Child
{
    public class Monster : Unit
    {

        public int Exp { get; private set; }
        static public string[] monsterNames = {"미니언", "슬라임", "", "", "서큐버스" };

        public void setExp(int floor)
        {
            Exp = 5 * floor;
        }

        public static string GetRandomMonsterName()
        {
            Random rand = new Random();

            return monsterNames[rand.Next(0, monsterNames.Length)];
        }

        //이벤트 선언 (Action 사망소식 전달)
        public event Action<string> OnMonsterDead;
        public void Dead()//퀘스트에 사망소식 전달
        {
            // 이벤트 발생
            OnMonsterDead?.Invoke(state.Name);
        }
    }
}

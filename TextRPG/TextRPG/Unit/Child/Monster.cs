using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit.Child
{
    public class Monster : Unit
    {
        public Monster(string _name)
        {
            state.Name = _name;
        }

        //이벤트 선언 (Action 사망소식 전달)
        public event Action<string> OnMonsterKilled;
        public void Dead()//퀘스트에 사망소식 전달
        {
            // 이벤트 발생
            OnMonsterKilled?.Invoke(state.Name);
        }


    }
}

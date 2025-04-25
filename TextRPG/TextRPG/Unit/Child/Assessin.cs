using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit.Child
{
    public class Assessin : Player
    {
        public Assessin(string _name): base()
        {

            state.Name = _name;
            state.MaxHp = 100;
            state.MaxMp = 150;
            state.Damage = 15;
            state.Defense = 8;
            state.Level = 1;
            state.Gold = 800;
            state.MaxExp = 100; //경험치량
            ResetHp();
            ResetMP();

            SkillList.Add(new Skill("비겁하게 통수치기", "이걸쓰네",20 ,2));
            SkillList.Add(new Skill("민첩하게 통수치기", "빠르게 전두엽을 때려 치명상을 입힌다.", 30, 4));
           
        }
        public override void AttackVoice()
        {
            Console.WriteLine($"{state.Name}이 단검을 사용하여 비겁하게 공격!!");
        }



    }
}

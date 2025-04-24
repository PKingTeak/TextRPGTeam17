using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit.Child
{
    public class Warrior : Player
    {
        public Warrior(string _name) : base()
        {
            
            state.Name = _name;
            state.MaxHp = 200;
            state.MaxMp = 50;
            state.Damage = 10;
            state.Defense = 10;
            state.Level = 1;
            state.Gold = 5000;
            state.MaxExp = 100; //경험치량
            ResetHp();
            ResetMP();

            //스킬생성도
            SkillList.Add(new Skill("풀파워", "힘을 집중시켜 대상을 공격한다", 10, 2));
            SkillList.Add(new Skill("진심으로 묵직하게 때리기", "진지하게 장난 안치고 때리기 때문에 아픕니다", 20, 3));


        }

        public override void AttackVoice()
        {
            Console.WriteLine($"{state.Name}이 대검을 사용하여 공격!!");
        }


    }
}

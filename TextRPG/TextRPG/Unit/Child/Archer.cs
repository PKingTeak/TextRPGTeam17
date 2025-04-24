using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG.Unit.Child
{
    public class Archer : Player
    {
        public Archer(string _name) : base()
        {
            state.Name = _name;
            state.MaxHp = 100;
            state.MaxMp = 100;
            state.Damage = 20;
            state.Defense = 5;
            state.Level = 1;
            state.Gold = 800;
            state.MaxExp = 100; //경험치량
            ResetHp();
            ResetMP();

            SkillList.Add(new Skill("더블샷", "화살을 두번 쏴서 두번의 데미지가 들어간다", 10, 2));
            SkillList.Add(new Skill("트리플샷", "화상을 세번 쏴서 세 번의 데미지가 들어간다", 10, 3));

        }

        public override void AttackVoice()
        {
           
            Console.WriteLine($"{state.Name}이 활을 사용하여 공격!!");
            Console.ReadLine();
            
        }


        
    }
}

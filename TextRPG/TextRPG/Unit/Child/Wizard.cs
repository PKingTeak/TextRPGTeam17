﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG.Unit.Child
{
    public class Wizard : Player
    {

        public Wizard(string _name) :  base()
        {
            state.Name = _name;
            state.MaxHp = 100;
            state.MaxMp = 200;
            state.Damage = 10;
            state.Defense = 5;
            state.Level = 1;
            state.Gold = 800;
            state.MaxExp = 100; //경험치량
            ResetHp();
            ResetMP();
            SkillList.Add(new Skill("익스펙토 페트로눔!!!", "해리에게 전수받은 공격 스킬이다.", 40, 3));
            SkillList.Add(new Skill("지팡이로 급소 때리기", "인간은 도구를 사용하는 동물입니다.", 50, 5));

        }

        public override void AttackVoice()
        {
            Random ran = new Random();
            int voicenum = ran.Next(0, 3);
            switch (voicenum)
            {
                case 0:
                    Console.WriteLine($"{state.Name}이 간단한 주문을 사용하여 공격!!");
                    break;
                case 1:
                    Console.WriteLine("가라 해리!! 몸통 박치기!!!");
                    break;
                case 2:
                    Console.WriteLine("인센디오!!!!");
                    break;


            }


        }

    }
}

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
            state.Name = base.state.Name;
            state.MaxHp = 100;
            state.MaxMp = 100;
            state.Damage = 20;
            state.Defense = 5;
            state.Level = 1;
            state.Gold = 800;
            state.MaxExp = 100; //경험치량
            ResetHp();
            ResetMP();
        }

        public override Dictionary<string, SkillAttack> GetSkillSet()
        {
            return new Dictionary<string, SkillAttack>
                {
                    {"stealarrow",(other) =>
                        {
                            int skilldamage = state.Damage+10;
                            other.SetDamage(skilldamage);
                            Console.WriteLine($"공격에 올인 스킬을 사용하여 {skilldamage}데미지를 주었습니다.");
                        }


                    },
                    {"doubleshot", (other) =>
                        {
                            int skilldamage = (state.Damage/2)*2;
                            other.SetDamage(skilldamage);
                            Console.WriteLine($"펀치를 사용하여{skilldamage/2}로 두번 공격하였습니다.");

                        }
                    }


                };

        }


    }
}

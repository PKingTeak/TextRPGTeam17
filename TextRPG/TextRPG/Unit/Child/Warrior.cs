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
            state.Gold = 800;
            state.MaxExp = 100; //경험치량
            ResetHp();
            ResetMP();
            SettingSkill(GetSkillSet());



        }

        public override Dictionary<string, SkillAttack> GetSkillSet()
        {
            return new Dictionary<string, SkillAttack>
                {
                    {"FullPower",(other) =>
                        {
                            int skilldamage = state.Damage+state.Defense;
                            other.SetDamage(skilldamage);
                            Console.WriteLine($"공격에 올인 스킬을 사용하여 {state.Damage}(공격력)+{state.Defense}(방어력)을 합친만큼 데미지를 주었습니다.");
                        }


                    },
                    {"Pucnch", (other) =>
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

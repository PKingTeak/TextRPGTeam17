using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit.Child
{
    public class Skill
    {
        public Skill(string _name, string _info, int _mp, int _rank)
        {
            SkillName = _name;
            SkillData = _info;
            AttackRank = _rank;
            UseMp = _mp;

        }

        public void SkillInfo()
        {
            Console.WriteLine(SkillData);
        }


        public void UsingSkill(Player player, Unit other)
        {
            int result = player.state.Damage * AttackRank;
            if (player.state.CurMp >= UseMp)
            {
                Console.WriteLine($"{player.state.Name} 의 {SkillName}!!");
                Console.WriteLine($"Mp {player.state.CurMp} -> {player.state.CurMp - UseMp}\n");
                player.state.CurMp -= UseMp;
            }
            else
            {
                Console.WriteLine($"MP가 부족합니다");
            }
            other.SetDamage(result);
        }

        public int AttackRank { get; private set; }

        public string SkillName { get; private set; }
        public string SkillData { get; private set; }

        public int UseMp { get; private set; }




    }
}
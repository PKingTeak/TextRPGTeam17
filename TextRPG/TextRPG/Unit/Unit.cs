using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit
{

    public class Unit
    {

        public delegate void SkillAttack(Unit _Other);
        public struct UnitState
        {

            public string Name { get;set; }
            public int Level { get;set; }

            public int MaxHp { get;set; }

            public int MaxMp { get;set; }

            public int Damage { get;set; }

            public int Defense { get;set; }

            public int Gold { get;set; }

            public int MaxExp { get;set; }

            public int CurHp { get;set; }
            public int CurExp { get;set; }
            public int CurMp { get;set; }
            public void Healing(/*item*/)
            {
                //나중에 아이템 오면 생각
            }

            
          
          



            public UnitState(int _MaxHp, int _MaxMp, int _Damage, int _Defense)
            {
                MaxHp = _MaxHp;
                MaxMp = _MaxMp;
                Damage = _Damage;
                Defense = _Defense;


            }
        }

        public virtual void Attack(Unit _Other)
        {
            int realDamage = RandomNum(state.Damage-_Other.state.Defense,state.Damage+10);
            if (realDamage < 0)
            {
                realDamage = 1;
            }
            Console.WriteLine($"{state.Name}이 {realDamage}의 데미지로 공격하였습니다");
            
            //랜덤 추가 예정
            _Other.SetDamage(realDamage);

            //공격 
            //공격력 - 방어력 만큼 피해 주기 
        }

        public int RandomNum(int _min, int _max)
        {
            Random random = new Random();
            int result = random.Next(_min,_max);
            return result;
        }

        

        public void Healing(/*item*/)
        {
            //나중에 아이템 오면 생각
        }

        public void SetDamage(int _damage)
        {
            state.CurHp -= _damage;
            if (state.CurHp < 0)
            {
                state.CurHp = 0;
            }
        }
        public void ResetHp()
        {
            state.CurHp = state.MaxHp;
        }

        public void ResetMP()
        { 
            state.CurMp = state.MaxMp;
        }




        //공격, 피해

        public UnitState state = new UnitState();

        

    }
}


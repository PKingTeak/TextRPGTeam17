using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextRPG.Unit;



namespace TextRPG.Unit.Child
{
   




  

    public class Player : Unit
    {
        public Player()
        {


        }
        public void UseSkill(Unit _other)
        {
            if (Skill != null)
            {
                Skill(_other);
            }
            else
            {
                Console.WriteLine("값이 잘못 들어왔습니다.");
            }
        }
        //능력치 오르는 조건
        //1. 레벨업
        //2. 아이템 장착 
        public void levelUp()
        {

            state.MaxHp = state.MaxHp * state.Level;
            
        
        }

        public void ShowInfo()
        {
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine($"레벨: {state.Level}\nChad: {GetType().Name}\n공격력: {state.Damage}\n방어력: {state.Defense}\n체 력: {state.CurHp}\nGold: {state.Gold}");

        }
        public void equipmentItem(/*Item item*/)
        { 
            
        }


        protected SkillAttack Skill;
    };
};



/*
      Player player;
            Console.WriteLine("이름 ");
            string Input = Console.ReadLine();
            Console.WriteLine("직업선택 숫자로 입력해주세요 ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                     player = new Warrior(Input);
                    break;
                case "1":
                     player = new Archer(Input);
                    break;
                case "2":
                    player = new Assessin(Input);
                    break;
                case "3":
                    player = new Wizard(Input);
                    break;
                default:
                    Console.WriteLine("잘못 입력 하였습니다");
                    break;
            }



            int ab = 0;
  
 */
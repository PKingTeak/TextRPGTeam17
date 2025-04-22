using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using TextRPG.Unit;



namespace TextRPG.Unit.Child
{
    public enum Jobs
    {

    }

    public class Player : Unit
    {
        

       public void SetJob(string _input)
       {
            Console.WriteLine("직업을 선택해 주세요\n1.전사 \t2.궁수\t3.도적\t4.마법사");
            Player player = null;
            switch(_input)
            {
                case "1":
                player = new Warrior(state.Name);
                break;
                case "2":
                player = new Archer(state.Name);
                break;
                case "3" :
                player = new Assessin(state.Name);
                break;
                case "4" :
                player = new Wizard(state.Name);
                break;
                

            }


       }
      

        
        //능력치 오르는 조건
        //1. 레벨업
        //2. 아이템 장착 
        public void levelUp()
        {
            state.Level++;
            state.CurExp = state.CurExp - state.MaxExp;
            state.MaxExp = state.MaxExp * state.Level; //레벨에 비례서 경험치량 증가
            state.MaxHp = (100 * state.Level); //체력증가
            state.MaxMp = (state.MaxMp + (50 * state.Level));
            state.Defense += state.Level;
            state.Damage += (2 * state.Level);
            //추가 수정사항은 회의 하고 추가 및 수정예정
        }
        public void RewardExp(int _Exp)
        {
            state.CurExp += _Exp;
            if (state.CurExp >= state.MaxExp)
            {
                levelUp();


            }
            else
            {
                return; //레벨업 조건이 아님 
            }

        }


        public void ShowInfo()
        {
            Console.WriteLine($"레벨: {state.Level}\nChad: {GetType().Name}\n공격력: {state.Damage}\n방어력: {state.Defense}\n체 력: {state.CurHp}\nGold: {state.Gold}");

        }

        public void ChoiceSkill(string _input)
        {
            switch (_input)
            {
                case "1":
                    break;
            }


        }
        public void equipmentItem(/*Item item*/)
        {
            //아이템 능력치를 가져와서 값을 증가시키는 방식을 사용하거나
            //player의 능력치를 직접 호출하여 사용하거나 둘중에 하나 .

        }


        public void UsingSkill(string _skillName , Unit other)
        {
            if(Skills.ContainsKey(_skillName))
            {
                Skills[_skillName]?.Invoke(other); //다른 유닛 공격하기 

            }
            else{

                Console.WriteLine("스킬이름을 다시 확인해 주세요");
            }
        }

        protected void SettingSkill(Dictionary<string, SkillAttack> skillset)
        {
            Skills = skillset;
        }
        Dictionary<string,SkillAttack> Skills = new();
        
    

    };
};



/*
     
            Player player = null;
            Monster monster = new Monster();
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
                    player = null;
                    break;
            }

            if (player == null)
            {
                Console.WriteLine("잘못된 값이 들어옴");
            }
            else
            {
                Console.WriteLine($"플레이어 생성됨: {player.GetType().Name}");
            }
            while (true)
            {
                Input = Console.ReadLine();
                if (Input == "1")
                {
                    player.UseSkill(monster);

                }
                else if (Input == "2")
                {
                    player.ShowInfo();
                }
                else
                {
                    break;
                }

            }



            int ab = 0;
  
 */
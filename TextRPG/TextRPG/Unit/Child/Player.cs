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


    public class Player : Unit
    {

        public Player()
        {


        }
        public Player SetJob(string _name)
        {
            Console.WriteLine("직업을 선택해 주세요\n1.전사 \t2.궁수\t3.도적\t4.마법사");
            string Input = Console.ReadLine();

            switch (Input)
            {
                case "1":
                    return new Warrior(_name);
                    break;
                case "2":
                    return new Archer(_name);
                    break;
                case "3":
                    return new Assessin(_name);
                    break;
                case "4":
                    return new Wizard(_name);
                    break;
                default:
                    Console.WriteLine("값을 잘못 입력했습니다.");
                    return null;



            }


        }
        //상태창 
        public void ShowInfo()
        {
            if (playerequiments.Count > 0)
            {
                Console.WriteLine($"레벨: {state.Level}\nChad: {GetType().Name}\n공격력: {state.Damage}(+{ItemDamage})\n방어력: {state.Defense}(+{ItemDefense})\n체 력: {state.CurHp}\nGold: {state.Gold}");
            }
            else
            {
                Console.WriteLine($"레벨: {state.Level}\nChad: {GetType().Name}\n공격력: {state.Damage}\n방어력: {state.Defense}\n체 력: {state.CurHp}\nGold: {state.Gold}");

            }

        }

        #region 레벨관련매서드
        private void levelUp()
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
        #endregion








        #region 아이템 관련
        public void EquimentItem(Item _Item)
        {

            playerequiments.Add(_Item);
            foreach (var ItemType in _Item.Stats.Keys)
            {
                switch (ItemType)
                {
                    case Item.ItemType.WeaPon:
                        ItemDamage = _Item.Stats[ItemType]; //바로 부르는거기 때문에 아이템 클래스
                        break;
                    case Item.ItemType.Armor:
                        ItemDefense = _Item.Stats[ItemType];
                        break;
                }
            }




        }

        #endregion


        #region 공격및스킬관련
        public override void Attack(Unit _Other)
        {
            int realDamage = RandomNum(FinalDamage - _Other.state.Defense, state.Damage + 10);
            if (realDamage < 0)
            {
                realDamage = 1;
            }
            Console.WriteLine($"{state.Name}의 일반 공격 !!");
            _Other.SetDamage(realDamage);

        }
       
        public List<Skill> GetSKillList()
        {
            return SkillList;
            //GetSkillList
        }


        public int FinalDamage { get => state.Damage + ItemDamage; }
        public int FinalDefense { get => state.Defense + ItemDefense; }


        private int ItemDamage = 0;
        private int ItemDefense = 0;


        public List<Skill> SkillList = new List<Skill>();

        List<Item> playerequiments = new List<Item>(); //장비 갯수 무조건 0번째는 무기 나머지는 방어구
        //아이템 먹으면 -> 공격력이 겹치는데 -> 
#endregion

    };
};



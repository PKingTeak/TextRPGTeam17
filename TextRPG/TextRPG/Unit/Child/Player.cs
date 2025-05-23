﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using TextRPG.Unit;



namespace TextRPG.Unit.Child
{
    public enum PlayerType
    {
        Warrior,
        Archer,
        Assessin,
        Wizard
    }

    public class Player : Unit
    {
        const int criticalPercent = 15;

        public Player()
        {

        }
        public static Player SetJob(string _name, PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Warrior:
                    return new Warrior(_name);
                case PlayerType.Archer:
                    return new Archer(_name);
                case PlayerType.Assessin:
                    return new Assessin(_name);
                case PlayerType.Wizard:
                    return new Wizard(_name);
                default:
                    return new Warrior(_name);
            }
        }
        //상태창 
        public void ShowInfo()
        {
            Console.WriteLine($"이름: {state.Name}\n레벨: {state.Level}\nChad: {GetType().Name}\n공격력: {state.Damage} {GetItemStat(ItemDamage)}\n방어력: {state.Defense} {GetItemStat(ItemDefense)}\n체 력: {state.CurHp}\nGold: {state.Gold}");
        }


        public void UseGold(int _num)
        {
            if (_num < 0)
            {
                if (state.Gold >= -_num)
                {
                    state.Gold += _num;
                    if (state.Gold < 0)
                    {
                        state.Gold = 0;
                    }
                }
            }
            else
            {
                state.Gold += _num;
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
            // 이벤트 발생
            OnPlayerChange?.Invoke("더욱 더 강해지기!");

            // HP, MP 회복
            ResetHp();
            ResetMP();
        }

        public void RewardExp(int _Exp)
        {
            state.CurExp += _Exp;
            if (state.CurExp >= state.MaxExp)
            {
                Console.WriteLine("\n레벨업 !!");
                Console.WriteLine($"Lv. {state.Level} -> Lv. {state.Level + 1}");

                levelUp();
            }
        }
        #endregion

        #region 아이템 관련
        public void EquimentItem(Item _Item)
        {
            switch (_Item.itemType)
            {
                case Item.ItemType.Weapon:
                    ItemDamage += _Item.Value;
                    break;

                case Item.ItemType.Armor:
                    ItemDefense += _Item.Value;
                    break;
            }

            // 이벤트 발생
            OnPlayerChange?.Invoke("장비를 장착해보자");
        }

        public void DequimentItem(Item _Item)
        {
            //장착 해제 
            switch (_Item.itemType)
            {
                case Item.ItemType.Weapon:
                    ItemDamage -= _Item.Value;
                    break;

                case Item.ItemType.Armor:
                    ItemDefense -= _Item.Value;
                    break;
            }
        }

        public void UseHpPotion(int value)
        {
            state.CurHp += value;

            if(state.CurHp >= state.MaxHp)
                state.CurHp = state.MaxHp;
        }

        public void UseMpPotion(int value)
        {
            state.CurMp += value;

            if(state.CurMp >= state.MaxMp)
                state.CurMp = state.MaxMp;
        }
        #endregion


        #region 공격및스킬관련
        public override void Attack(Unit Attacker, Unit _Other)
        {
            int percent = rand.Next(100);
            bool isCritical = false;

            if (percent <= criticalPercent)
                isCritical = true;

            int realDamage = (int)(RandomNum(FinalDamage - _Other.state.Defense, FinalDamage + 10) * (isCritical ? 1.6 : 1));
            if (realDamage < 0)
            {
                realDamage = 1;
            }
            Attacker.AttackVoice();
            _Other.SetDamage(realDamage, isCritical);
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
        #endregion


        //이벤트 선언 (Action 사망소식 전달)
        public event Action<string> OnPlayerChange;

        private string GetItemStat(int itemStat)
        {
            if (itemStat == 0) return "";
            else return $"(+{itemStat})";
        }
    };
};



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit.Child
{
    public class Warrior : Player
    {
        public Warrior(string _Name)
        {
            state.Name = _Name;
            state.MaxHp = 200;
            state.MaxMp = 50;
            state.Damage = 10;
            state.Defense = 10;
            state.Level = 1;
            state.Gold = 800;
            state.MaxExp = 100; //경험치량


        }
    }
}

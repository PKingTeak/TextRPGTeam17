using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit.Child
{
    public class Assessin : Player
    {
        public Assessin(string _name): base()
        {

            state.Name = _name;
            state.MaxHp = 100;
            state.MaxMp = 150;
            state.Damage = 15;
            state.Defense = 8;
            state.Level = 1;
            state.Gold = 800;
            state.MaxExp = 100; //경험치량
            ResetHp();
            ResetMP();
        }

    }
}

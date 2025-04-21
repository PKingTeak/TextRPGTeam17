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
        public Archer(string _Name)
        {
            state.Name = _Name;
            state.MaxHp = 100;
            state.MaxMp = 100;
            state.Damage = 20;
            state.Defense = 5;
            state.Level = 1;
            state.Gold = 800;
            state.MaxExp = 100; //경험치량
    

        }

    }
}

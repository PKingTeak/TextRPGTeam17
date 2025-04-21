using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG.Unit.Child
{
    public class Wizard : Player
    {

        public Wizard(string _Name)
        {
            state.Name = _Name;
            state.MaxHp = 100;
            state.MaxMp = 200;
            state.Damage = 10;
            state.Defense = 5;
            state.Level = 1;
            state.Gold = 800;
            state.MaxExp = 100; //경험치량


        }
        
        
    }
}

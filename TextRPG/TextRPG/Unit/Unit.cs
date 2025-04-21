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

       
        protected struct UnitState
        {

            public string Name;
            public int Level;
            public int MaxHp;
            public int MaxMp;
            public int Damage;
            public int Defense;
            public int Gold;
            public int MaxExp;

            public UnitState(int _MaxHp, int _MaxMp, int _Damage, int _Defense)
            { 
                MaxHp = _MaxHp;
                MaxMp = _MaxMp;
                Damage = _Damage;
                Defense = _Defense;

            }
        }

        //공격, 피해

        protected UnitState state = new UnitState();



    }


}


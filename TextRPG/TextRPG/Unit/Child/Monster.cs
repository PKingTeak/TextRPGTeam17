using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Unit.Child
{
    public class Monster : Unit
    {
        public int Exp { get; private set;}

        public void setExp(int floor)
        {
            Exp = 5 * floor;
        }

        


    }
}

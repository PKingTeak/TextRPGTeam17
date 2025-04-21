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

        public void Init(string _Name)
        {


        }

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

using TextRPG.Unit.Child;

namespace Program
{
    class MainGame
    {
        static void Main(string[] args)
        {
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
        }
    };
}
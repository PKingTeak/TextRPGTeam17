using System.Reflection.Metadata;
using TextRPG.Unit.Child;
namespace TextRPG.Scene
{
    public class BattleScene : Scene
    {
        public BattleScene(SceneManager sceneManager) : base(sceneManager) { }

        Player player;

        int floor = 1; // 던전의 층수
        MonsterSpawner spawner = new MonsterSpawner();
        List<Unit.Unit> monsters = new List<Unit.Unit>();
        private bool isBattle;

        public override void ShowScene()
        {
            isBattle = true;
            monsters = spawner.SpawnMonsters(floor);

            while (isBattle)
            {
                // 전투 UI 출력
                Console.Clear();
                Console.WriteLine("Battle!!\n");

                //몬스터 출력
                PrintMonsterInfo();

                // 플레이어 정보 표시
                PrintPlayerInfo();

                int choice = InputHandler.ChooseAction(1, 2, "\n1. 공격\n2. 스킬", "원하시는 행동을 입력해주세요.\n");

                switch (choice)
                {
                    case 1:
                        ChooseMonster();
                        break;

                    case 2:
                        ChooseSkill();
                        break;
                }
            }
        }

        // 스킬 선택
        void ChooseSkill()
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n");

            // 몬스터 출력

            // 플레이어 정보 표시
            Console.WriteLine("[내정보]");

            // 스킬 정보 표시

        }

        // 대상 선택 화면
        void ChooseMonster()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!\n");

                // 몬스터 번호와 함께 출력

                // 플레이어 정보 표시
                Console.WriteLine("[내정보]");

                int choice = InputHandler.ChooseAction(0, monsters.Count, "0. 취소", "공격할 대상을 선택하세요.\n");

                if (choice == 0)
                    return;

                else
                {
                    player.Attack(monsters[choice]);
                }
            }
        }

        void MonstersPhase()
        {
            // 몬스터 페이즈
        }

        void PrintPlayerInfo()
        {
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv. {player.state.Level} {player.state.Name} (직업)");
            Console.WriteLine($"{player.state.CurHp}/{player.state.MaxHp}");
        }

        void PrintMonsterInfo(bool useNum)
        {
            if (useNum)
            {

            }
            else
            {
                foreach (var mon in monsters)
                    Console.WriteLine($"Lv. {mon.state.Level} HP {mon.state.CurHp}");
            }

        }
    }
}

using TextRPG.Unit.Child;
namespace TextRPG.Scene
{
    public class BattleScene : Scene
    {
        public BattleScene(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "Battle!!";
            sceneDescription = "";
            type = SceneType.Battle;
            this.player = sceneManager.Player;
        }
        
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

                //번호 없이 몬스터 출력
                PrintMonsterInfo(false);

                Console.WriteLine();

                // 플레이어 정보 표시
                PrintPlayerInfo();

                int choice = InputHandler.ChooseAction(1, 2, "\n1. 공격\n2. 스킬", "원하시는 행동을 입력해주세요.\n");

                switch (choice)
                {
                    case 1:
                        PlayerPhase(false); // 공격 선택
                        break;

                    case 2:
                        PlayerPhase(true);  // 스킬 선택
                        break;
                }
            }
        }

        void PlayerPhase(bool useSkill)
        {
            if (useSkill)
                ChooseSkill();
            else
                ChooseMonster();
        }

        // 스킬 선택
        void ChooseSkill()
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n");

            // 번호 없이 몬스터 출력
            PrintMonsterInfo(false);

            Console.WriteLine();

            // 플레이어 정보 표시
            PrintPlayerInfo();

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
                PrintMonsterInfo(true);

                Console.WriteLine();

                // 플레이어 정보 표시
                PrintPlayerInfo();

                int choice = InputHandler.ChooseAction(0, monsters.Count, "\n0. 취소", "공격할 대상을 선택하세요.\n");

                if (choice == 0)
                    return;

                else
                {
                    player.Attack(monsters[choice - 1]);
                    MonstersPhase();
                    return;
                }
            }
        }
        
        // 몬스터 페이즈
        void MonstersPhase()
        {
            foreach(var mon in monsters)
            {
                if(mon.state.CurHp == 0)
                    continue;
                else
                    mon.Attack(player);
            }
        }

        // 플레이어 정보 출력
        void PrintPlayerInfo()
        {
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv. {player.state.Level} {player.state.Name} (직업)");
            Console.WriteLine($"{player.state.CurHp}/{player.state.MaxHp}");
        }

        // 몬스터 정보 출력
        void PrintMonsterInfo(bool useNum)
        {
            if (useNum)
            {
                int num = 1;

                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.WriteLine($"[{num}] Lv. {monsters[i].state.Level} {monsters[i].state.Name} HP {monsters[i].state.CurHp}");
                    num++;
                }
            }
            else
            {
                foreach (var mon in monsters)
                    Console.WriteLine($"Lv. {mon.state.Level} {mon.state.Name} HP {mon.state.CurHp}");
            }

        }
    }
}

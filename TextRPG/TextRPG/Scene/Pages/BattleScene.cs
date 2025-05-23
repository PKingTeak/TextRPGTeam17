using System.Runtime.InteropServices.Marshalling;
using TextRPG.Unit.Child;

namespace TextRPG.Scene
{
    public class BattleScene : Scene
    {
        public BattleScene(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "\u001b[38;2;255;27;27m[Battle!!]\u001b[0m";
            sceneDescription = "";
            type = SceneType.Battle;
            this.player = sceneManager.Player;
        }

        Player player;
        int floor = 1; // 던전의 층수
        PrintBattleInfo printInfo;
        MonsterSpawner spawner = new MonsterSpawner();
        List<Monster> monsters = new List<Monster>();
        List<Item> potions;
        private bool isBattle;
        Skill? selectSkill = null;

        public override void ShowScene()
        {
            // 플레이어의 체력이 남아있다면 전투 시작
            if (player.state.CurHp != 0)
            {
                printInfo = new PrintBattleInfo(player.state.CurHp, player.state.CurMp);
                isBattle = true;
                monsters = spawner.SpawnMonsters(floor);
                potions = sceneManager.ItemManager.GetPotions();

                foreach (var monster in monsters)
                {
                    sceneManager.QuestManager.Subscribe(monster);
                }
            }
            else
            {
                isBattle = false;
                Console.WriteLine("지금은 체력이 남아나질 않습니다...");
                Thread.Sleep(500);
            }

            while (isBattle)
            {
                Console.Clear();
                // 전투 UI 출력
                Console.WriteLine($"{sceneName} - 현재 층수 {floor}층" + "\n");

                //번호 없이 몬스터 출력
                printInfo.PrintMonsterInfo(monsters, false);

                Console.WriteLine();

                // 플레이어 정보 표시
                printInfo.PrintPlayerInfo(player);

                int choice = InputHandler.ChooseAction(1, 3, "\n1. 공격\n2. 스킬\n3. 아이템", "원하시는 행동을 입력해주세요.\n");

                switch (choice)
                {
                    case 1:
                        PlayerPhase(false); // 공격 선택
                        break;

                    case 2:
                        PlayerPhase(true);  // 스킬 선택
                        break;

                    case 3:
                        ChooseItem(); // 아이템 선택
                        break;

                    default:
                        Thread.Sleep(500);
                        break;
                }
            }

            sceneManager.PopScene();
        }

        void PlayerPhase(bool useSkill)
        {
            selectSkill = null;

            if (useSkill)
                ChooseSkill();
            else
                ChooseMonster();
        }

        // 아이템 선택
        void ChooseItem()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{sceneName} - 현재 층수 {floor}층" + "\n");
                Console.WriteLine("아이템 사용");

                // 플레이어 정보 표시
                printInfo.PrintPlayerInfo(player);

                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < potions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {potions[i].Name} x {potions[i].Count}");
                }

                int choice = InputHandler.ChooseAction(0, potions.Count, "\n0. 취소", "원하는 행동을 입력해주세요.");

                if (choice == 0) return;

                else if (choice != -1 && choice <= potions.Count)
                {
                    sceneManager.ItemManager.UsePotion(potions[choice - 1]);
                }
            }
        }

        /// 스킬 선택
        void ChooseSkill()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{sceneName} - 현재 층수 {floor}층" + "\n");

                // 번호 없이 몬스터 출력
                printInfo.PrintMonsterInfo(monsters, false);

                Console.WriteLine();

                // 플레이어 정보 표시
                printInfo.PrintPlayerInfo(player);

                // 스킬 목록 출력
                Console.WriteLine("\n[스킬 목록]");
                for (int i = 0; i < player.SkillList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {player.SkillList[i].SkillName} - MP {player.SkillList[i].UseMp}");
                    player.SkillList[i].SkillInfo();
                }

                int choice = InputHandler.ChooseAction(0, player.SkillList.Count, "\n0. 취소", "원하는 행동을 입력해주세요.");

                if (choice == 0) return;

                else if (choice != -1 && choice <= player.SkillList.Count)
                {
                    selectSkill = player.SkillList[choice - 1];
                    // 스킬 선택 후 공격 몬스터 선택
                    if (player.state.CurMp >= selectSkill.UseMp)
                    {
                        ChooseMonster();
                        return;
                    }
                    else
                    {
                        selectSkill = null;
                        Console.WriteLine("MP가 부족합니다.");
                        Thread.Sleep(500);
                    }
                }
            }
        }

        // 대상 선택 화면
        void ChooseMonster()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{sceneName} - 현재 층수 {floor}층" + "\n");

                // 선택된 스킬이 있다면 현재 선택중인 스킬 표시
                if (selectSkill != null) Console.WriteLine($"현재 선택된 스킬 [{selectSkill.SkillName}]\n");

                // 몬스터 번호와 함께 출력
                printInfo.PrintMonsterInfo(monsters, true);

                Console.WriteLine();

                // 플레이어 정보 표시
                printInfo.PrintPlayerInfo(player);

                int choice = InputHandler.ChooseAction(0, monsters.Count, "\n0. 취소", "공격할 대상을 선택하세요.\n");

                if (choice == 0) return;

                else if (choice != -1 && choice <= monsters.Count)
                {
                    // 몬스터가 살아있다면 공격
                    if (monsters[choice - 1].state.CurHp != 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"{sceneName}" + "\n");

                        if (selectSkill != null)
                            selectSkill.UsingSkill(player, monsters[choice - 1]);
                        else
                            player.Attack(player, monsters[choice - 1]);

                        printInfo.WaitBattleProgress(); // 전투 과정 출력 대기

                        MonstersPhase(); // 몬스터 턴
                        return;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 대상입니다.");
                        Thread.Sleep(500);
                    }
                }
            }
        }

        // 몬스터 페이즈
        void MonstersPhase()
        {
            Console.Clear();
            Console.WriteLine($"{sceneName} - 현재 층수 {floor}층" + "\n");

            // 모든 몬스터가 죽었다면 전투 종료
            if (CheckAllMonstersDie())
            {
                isBattle = false;
                EndBattle(true);
                return;
            }

            // 몬스터가 죽지 않았다면 공격
            foreach (var monster in monsters)
            {
                if (monster.state.CurHp == 0)
                    continue;
                else
                    monster.Attack(monster, player);
            }

            // 전투 과정 출력 대기
            printInfo.WaitBattleProgress();

            // 플레이어가 죽었다면 전투 종료
            if (player.state.CurHp == 0)
            {
                isBattle = false;
                EndBattle(false);
                return;
            }
        }

        // 전투 종료 페이지
        void EndBattle(bool isWin)
        {
            int killCount = CountKilledMonster();
            bool isRewarded = false;
            // 보상 번들 생성
            BattleReward battleReward = new BattleReward(sceneManager.ItemManager);
            Reward reward = battleReward.CreateBattleReward(floor, killCount);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{sceneName} - Result\n");
                if (isWin) { Console.WriteLine("Victory\n"); floor++; }
                else Console.WriteLine("You Lose\n");

                Console.WriteLine($"던전에서 몬스터 {killCount}마리를 잡았습니다.\n");

                Console.WriteLine("[캐릭터 정보]");
                printInfo.PrintPlayerInfoEndBattle(player);

                // 보상 출력
                Console.WriteLine("\n[획득 보상]");
                printInfo.PrintRewardInfo(reward);

                // 보상 적용
                if (!isRewarded)
                {
                    battleReward.ApplyReward(reward, player);
                    isRewarded = true;
                }

                int choice = InputHandler.ChooseAction(0, 0, "\n0. 다음", "원하시는 행동을 입력해주세요.\n");

                if (choice == 0) return;
            }
        }

        // 모든 몬스터가 죽었는지 확인
        bool CheckAllMonstersDie()
        {
            bool isAllDie = true;

            foreach (var monster in monsters)
            {
                if (monster.state.CurHp != 0)
                    isAllDie = false;
            }

            return isAllDie;
        }

        // 처치한 몬스터 수 계산
        int CountKilledMonster()
        {
            int kill = 0;

            foreach (var monster in monsters)
            {
                if (monster.state.CurHp == 0)
                {
                    kill++;
                    monster.Dead();
                }
            }
            return kill;
        }
    }
}


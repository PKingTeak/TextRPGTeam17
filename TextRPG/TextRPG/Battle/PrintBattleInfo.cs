using TextRPG.Unit.Child;

public class PrintBattleInfo
{
    public int entranceHp { get; }
    public int entranceMp { get; }

    public PrintBattleInfo(int entranceHp, int entranceMp)
    {
        this.entranceHp = entranceHp;
        this.entranceMp = entranceMp;
    }

    /// <summary>
    /// 전투 과정 대기
    /// </summary>
    public void WaitBattleProgress()
    {
        Console.WriteLine("계속하려면 아무 키나 입력해주세요.");
        Console.ReadKey();
    }

    /// <summary>
    /// 플레이어 정보 출력 (전투 중)
    /// </summary>
    /// <param name="player"></param>
    public void PrintPlayerInfo(Player player)
    {
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv. {player.state.Level} \u001b[38;2;0;220;44m{player.state.Name}\u001b[0m ({player.GetType().Name})");
        Console.WriteLine($"HP {player.state.CurHp}/{player.state.MaxHp}");
        Console.WriteLine($"MP {player.state.CurMp}/{player.state.MaxMp}");
    }

    /// <summary>
    /// 플레이어 정보 출력 (전투 종료)
    /// </summary>
    /// <param name="player"></param>
    public void PrintPlayerInfoEndBattle(Player player)
    {
        Console.WriteLine($"Lv.{player.state.Level} {player.state.Name}");
        Console.WriteLine($"HP {entranceHp} -> {player.state.CurHp}");
        Console.WriteLine($"MP {entranceMp} -> {player.state.CurMp}");
    }

    /// <summary>
    /// 번호 사용여부에 따라 몬스터 정보 출력
    /// </summary>
    /// <param name="monsters"></param>
    /// <param name="useNum"></param>
    public void PrintMonsterInfo(List<Monster> monsters, bool useNum)
    {

        if (useNum)
        {
            int num = 1;

            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].state.CurHp != 0)
                    Console.WriteLine($"[{num}] Lv. {monsters[i].state.Level} \u001b[38;2;255;27;27m{monsters[i].state.Name}\u001b[0m HP {monsters[i].state.CurHp}");
                else
                    Console.WriteLine($"[{num}] Lv. {monsters[i].state.Level} \u001b[38;2;255;27;27m{monsters[i].state.Name}\u001b[0m Dead");
                num++;
            }
        }

        else
        {
            foreach (var monster in monsters)
            {
                if (monster.state.CurHp != 0)
                    Console.WriteLine($"Lv. {monster.state.Level} \u001b[38;2;255;27;27m{monster.state.Name}\u001b[0m HP {monster.state.CurHp}");
                else
                    Console.WriteLine($"Lv. {monster.state.Level} \u001b[38;2;255;27;27m{monster.state.Name}\u001b[0m Dead");
            }
        }
    }

    /// <summary>
    /// 보상 정보 출력
    /// </summary>
    /// <param name="reward"></param>
    public void PrintRewardInfo(Reward reward)
    {
        Console.WriteLine($"Exp {reward.Exp}");
        Console.WriteLine($"Gold {reward.Gold}");
        if (reward.Items.Count > 0)
        {
            foreach (var item in reward.Items)
                Console.WriteLine($"{item.Name} x 1");
        }
    }
}
using TextRPG.Unit.Child;

public class Reward
{
    public int Exp { get; set; }
    public int Gold { get; set; }
    public List<Item> Items { get; set; }

    public Reward()
    {
        Exp = 0;
        Gold = 0;
        Items = new List<Item>();
    }
}
public class BattleReward
{
    Random rand = new Random();
    ItemManager itemManager;

    public BattleReward(ItemManager itemManager)
    {
        this.itemManager = itemManager;
    }

    /// <summary>
    /// 전투 보상 생성
    /// </summary>
    /// <param name="floor"></param>
    /// <param name="killCount"></param>
    /// <returns></returns>
    public Reward CreateBattleReward(int floor, int killCount)
    {
        // 새로운 보상 생성
        Reward reward = new Reward();

        // 보상 경험치 적용
        reward.Exp = 20 * floor * killCount;

        // 처치한 몬스터 만큼 아이템 생성
        for (int i = 0; i < killCount; i++)
        {
            int chance = rand.Next(0, 100);

            // 아이템 생성 확률 = (5 + 현재 층수)% 
            if (chance < 5 + floor)
            {
                reward.Items.Add(itemManager.GetRandomItem());
            }

            else
                reward.Gold += floor * 10;
        }

        return reward;
    }

    /// <summary>
    /// 플레이어에게 보상 적용
    /// </summary>
    /// <param name="reward"></param>
    /// <param name="player"></param>
    public void ApplyReward(Reward reward, Player player)
    {
        player.RewardExp(reward.Exp);
        player.state.Gold += reward.Gold;

        if (reward.Items.Count != 0)
        {
            foreach (var item in reward.Items)
            {
                if (item.IsOwned)
                {
                    player.state.Gold += item.Price;
                }
                item.ChangeOwnership(true);
            }
        }
    }
}

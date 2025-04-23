public struct RewardBundle
{
    int RewardExp { get; }
    int RewardGold { get; }

    // 아이템도 추가 해야함

    // 층수에 따른 보상 설정
    public RewardBundle(int floor)
    {
        RewardExp = 10 * floor;
        RewardGold = 20 * floor;
    }
}

public class BattleReward
{


    public RewardBundle GetReward(int floor)
    {
        RewardBundle bundle = new RewardBundle(floor);
        return bundle;
    }
}

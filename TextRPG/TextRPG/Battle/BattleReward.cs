
public struct BattleReward
{
    int RewardExp { get; }
    int RewardGold { get; }

    // 아이템도 추가 해야함

    // 층수에 따른 보상 설정
    public BattleReward(int floor)
    {
        RewardExp = 10 * floor;
        RewardGold = 20 * floor;
    }
}

public class MonsterSpawner
{
    Random rand = new Random();
    public List<string> SpawnMonsters(int floor)
    {
        List<string> monsters = new List<string>();

        int repeat = rand.Next(1, 3);  // 랜덤 생성

        for (int i = 0; i < repeat; i++)
        {
            //몬스터 생성 메서드 필요

            //monsters.Add(생성된 몬스터);
        }

        return monsters;
    }
}
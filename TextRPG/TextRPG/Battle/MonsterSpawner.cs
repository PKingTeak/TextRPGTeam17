using TextRPG.Unit;

public class MonsterSpawner
{
    Random rand = new Random();
    string[] monsterNames = {"몬스터", "개쌘 몬스터", "적당한 몬스터", "귀여운 몬스터"};
    public List<Unit> SpawnMonsters(int floor)
    {
        List<Unit> monsters = new List<Unit>();

        int repeat = rand.Next(1, 4);  // 랜덤 생성

        for (int i = 0; i < repeat; i++)
        {
            monsters.Add(SetMonster(floor));
        }

        return monsters;
    }

    Unit SetMonster(int floor)
    {
        Unit monster = new Unit();

        int rand_Value = rand.Next(5) * floor;

        monster.state = new Unit.UnitState()
        {
            Name = monsterNames[rand.Next(monsterNames.Length)],
            Level = 1 + rand_Value,
            MaxHp = 20 + rand_Value,
            Damage = 5 + rand_Value
        };

        monster.state.CurHp = monster.state.MaxHp;

        return monster;
    }
}
using TextRPG.Unit.Child;

public class MonsterSpawner
{
    Random rand = new Random();
    string[] monsterNames = {"고릴라", "고블린", "골렘", "오크"};
    public List<Monster> SpawnMonsters(int floor)
    {
        List<Monster> monsters = new List<Monster>();

        int repeat = rand.Next(1, 4);  // 랜덤 생성

        for (int i = 0; i < repeat; i++)
        {
            monsters.Add(SetMonster(floor));
        }

        return monsters;
    }

    // 스탯 설정
    Monster SetMonster(int floor)
    {
        Monster monster = new Monster();

        int monsterLevel = floor + rand.Next(1, 3);

        monster.state = new Monster.UnitState()
        {
            Name = monsterNames[rand.Next(monsterNames.Length)],
            Level = monsterLevel,
            MaxHp = 20 + (5 * monsterLevel) ,
            Damage = 5 + (2 * monsterLevel)
        };

        monster.state.CurHp = monster.state.MaxHp;

        return monster;
    }
}
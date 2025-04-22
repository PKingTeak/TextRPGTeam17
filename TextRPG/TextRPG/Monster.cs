using System;

public class TestMonster : TestUnit
{

    public string Name;

    //이벤트 선언 (Action 사망소식 전달)
    public event Action<string> OnMonsterKilled;
    public void Dead()//퀘스트에 사망소식 전달
    {
        // 이벤트 발생
        OnMonsterKilled?.Invoke(Name); 
    }

}
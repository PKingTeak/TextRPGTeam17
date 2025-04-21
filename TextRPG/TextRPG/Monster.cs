using System;

public class Monster : Unit
{

    public string Name;

    //이벤트 선언 (Action 사망소식 전달)
    public event Action OnMonsterKilled;
    public void Dead()//퀘스트에 사망소식 전달
    {
        // 이벤트 발생
        OnMonsterKilled?.Invoke(); 
    }

}
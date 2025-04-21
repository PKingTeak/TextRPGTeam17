using System;
using TextRPG;

public class QuestManager
{
    int killCount = 0; //처치한 몬스터 수
    public void Subscribe(Monster monster)//몬스터가 구독해서 HandleMonsterKilled()를 쓸 수 있게 해줌
    {
       
        monster.OnMonsterKilled += HandleMonsterKilled;
    }
    private void HandleMonsterKilled() //몬스터에게서 OnMonsterKilled?.Invoke();될 때 마다 호출
    {
        this.killCount ++; //처치한 몬스터 수 증가
        if(killCount >= 10) //처치한 몬스터 수가 10 이상이면
        {
            Console.WriteLine($"[퀘스트 업데이트] 몬스터 10마리 처치 완료!");
        }
    }



}
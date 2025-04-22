using System;
using System.Diagnostics;
using TextRPG;

public class QuestManager
{
    List<Quest> questList = new List<Quest>(); //퀘스트 리스트

    int minCount = 0; //처치한 몬스터 수
    int maxCount = 5; //처치해야 할 몬스터 수
    public void Subscribe(Monster monster)//몬스터가 구독해서 HandleMonsterKilled()를 쓸 수 있게 해줌
    {
        monster.OnMonsterKilled += HandleMonsterKilled;
    }
    private void HandleMonsterKilled() //몬스터에게서 OnMonsterKilled?.Invoke();될 때 마다 호출
    {
        this.minCount ++; //처치한 몬스터 수 증가
        if(minCount >=maxCount) //처치한 몬스터 수가 5 이상이면
        {
            Console.WriteLine($"[퀘스트 업데이트] 몬스터 5마리 처치 완료!");
        }
    }

    public void setQuest(int id=0,string title = "", string content = "", string condition = "", string reward = "") //퀘스트 화면
    {
        Quest quest = new Quest(id,title, content, condition, reward);
        questList.Add(quest);
    }

    public void getQuest(int i) //퀘스트 정보
    {
        foreach (var quest in questList)
        {
            if(quest.QuestID == i)
            {
                quest.GetCount(minCount, maxCount); //퀘스트 수집 수
                quest.QuestInfo();
            }
        }
    }
}
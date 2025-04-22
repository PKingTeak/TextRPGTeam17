using System;
using System.Diagnostics;


public class QuestManager
{
    List<Quest> questList = new List<Quest>(); //퀘스트 묶음,퀘스트의 수가 100개 이상이라면 딕셔너리로 바꿔야함

    //하나의 기능
    public void Subscribe(TestMonster monster)//몬스터가 구독해서 HandleMonsterKilled()를 쓸 수 있게 해줌
    {
        monster.OnMonsterKilled += HandleMonsterKilled;
    }
    private void HandleMonsterKilled(string name) //몬스터에게서 OnMonsterKilled?.Invoke();될 때 마다 호출
    {
        foreach (var quest in questList) //퀘스트 리스트를 돌면서
        {
            if (quest.questTarget == name) //퀘스트의 목표물과 몬스터 이름이 같으면
            {
                quest.Count(); //퀘스트의 수집 수 증가
                if (quest.minCount >= quest.maxCount) //처치한 몬스터 수가 5 이상이면
                {
                    Console.WriteLine($"[퀘스트 업데이트] 몬스터 5마리 처치 완료!"); //클리어 축하 메세지
                }
            }
        }

    }
    //하나의 기능

    public void setQuest(int id = 0, string title = "제목", string content = "퀘스트내용", string target = "목표물", int maxcount = 0, string action = "", string reward = "보상") //퀘스트 화면
    {
        Quest quest = new Quest(id,title, content,target,maxcount,action, reward);
        questList.Add(quest);
    }

    public void getQuest(int i) //퀘스트 정보
    {
        foreach (var quest in questList)
        {
            if(quest.QuestID == i)
            {
                quest.QuestInfo();
            }
        }
    }
}
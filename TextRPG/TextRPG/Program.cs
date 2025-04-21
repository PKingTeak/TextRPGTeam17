using System;

class Program
{
    static void Main(string[] args)
    {
        Monster slime = new Monster();//몬스터
        QuestManager questManager = new QuestManager();//퀘스트 매니저
        questManager.Subscribe(slime);// 퀘스트 매니저에 슬라임 등록

        // 몬스터 처치 → 이벤트 자동 호출
        slime.Name = "슬라임";
        for (int i = 0; i < 10; i++) //던전 생략 슬라임 10번 사망
        {
            slime.Dead();
        }


    }
}

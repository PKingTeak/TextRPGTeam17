using System;
using TextRPG;

class Program
{
    static void Main(string[] args)
    {
        Monster slime = new Monster();//몬스터
        QuestManager questManager = new QuestManager();//퀘스트 매니저
        questManager.Subscribe(slime);// 퀘스트 매니저에 슬라임 등록

        // 몬스터 처치 → 이벤트 자동 호출
        slime.Name = "슬라임";
        for (int i = 0; i <5; i++) //던전 생략 슬라임 10번 사망
        {
            slime.Dead();
        }


        // 퀘스트 정보 출력
        questManager.setQuest(1,"마을을 위협하는 미니언 처치", "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\r\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\r\n모험가인 자네가 좀 처치해주게!", "미니언 5마리 처치", "쓸만한 방패 x 1 , 5G");
        questManager.getQuest(1);

        // 퀘스트 정보 출력
        questManager.setQuest(2, "장비를 장착해보자", "모험을 떠나기 전엔 기본 장비부터 챙기는 게 좋지 않겠어?\r\n몸을 보호하려면 방어구 하나쯤은 필요하고, 적을 상대하려면 무기도 있어야 하니까 말이야.\r\n인벤토리를 열고 아무 장비나 하나 장착해봐!\r\n별거 아닐 것 같아도, 그게 모험의 시작이니까!", "장비 1개 장착하기", "초급 전투복 x 1 , 3G");
        questManager.getQuest(2);

        // 퀘스트 정보 출력
        questManager.setQuest(3, "더욱 더 강해지기!", "모험가라면 레벨을 올리는 건 기본이지!\r\n레벨이 올라가면 능력치도 올라가고, 새로운 스킬도 배울 수 있어!\r\n레벨을 올리기 위해선 몬스터를 처치하고 경험치를 얻어야 해.\r\n그럼 자네의 모험이 시작되는 거야!", "레벨 1 이상 올리기", "힘의 물약 x 2 , 8G");
        questManager.getQuest(3);

    }
}

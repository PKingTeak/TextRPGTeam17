using System;
using TextRPG.Scene;
using TextRPG.Unit.Child;



class Program
{

    static void Main(string[] args)
    {
        ItemManager itemManager = new ItemManager(); //아이템 매니저
        // 플레이어 객체 생성 및 정보 입력
        Console.WriteLine("이름을 입력해주세요");
        string Input = Console.ReadLine();
        Player player = new Player();
        player = player.SetJob(Input);

        //Item item = new Item("봉",new Dictionary<Item.ItemType, int>() { { Item.ItemType.WeaPon, 10 } } ,"아",500);
        //player.EquimentItem(item);

        SceneManager sceneManager = new SceneManager(player, itemManager);
       
        while (sceneManager.StackCount > 0)
        {
            sceneManager.ShowCurrentScene();
        }


        Console.WriteLine("게임 종료");
        TestMonster minieon = new TestMonster();//몬스터
        QuestManager questManager = new QuestManager();//퀘스트 매니저
        questManager.Subscribe(minieon);// 퀘스트 매니저에 슬라임 등록

        // 퀘스트 정보 저장
        questManager.SetQuest(10001, "마을을 위협하는 미니언 처치", "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\r\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\r\n모험가인 자네가 좀 처치해주게!", "미니언", 5, "마리 처치하기", "쓸만한 방패 x 1 , 5G");
        questManager.SetQuest(10004, "협곡을 부수는 골렘 처치", "이봐! 골렘 잡아", "골렘", 20, "마리 처치", "무한의 대검 x 1 , 500G");
        questManager.SetQuest(10002, "장비를 장착해보자", "모험을 떠나기 전엔 기본 장비부터 챙기는 게 좋지 않겠어?\r\n몸을 보호하려면 방어구 하나쯤은 필요하고, 적을 상대하려면 무기도 있어야 하니까 말이야.\r\n인벤토리를 열고 아무 장비나 하나 장착해봐!\r\n별거 아닐 것 같아도, 그게 모험의 시작이니까!", "장비", 1, "개 장착하기", "초급 전투복 x 1 , 3G");
        questManager.SetQuest(10003, "더욱 더 강해지기!", "모험가라면 레벨을 올리는 건 기본이지!\r\n레벨이 올라가면 능력치도 올라가고, 새로운 스킬도 배울 수 있어!\r\n레벨을 올리기 위해선 몬스터를 처치하고 경험치를 얻어야 해.\r\n그럼 자네의 모험이 시작되는 거야!", "레벨", 1, " 이상 올리기", "힘의 물약 x 2 , 8G");



        Quest quest = questManager.FindQuest(10001); //특정 퀘스트 찾기
        questManager.GetQuest(quest);//퀘스트 정보 출력


        //퀘스트 수락했을 경우 수락했다라는 정보를 넘겨주기
        Console.WriteLine("퀘스트를 수락하셨습니다.");
        questManager.SetQuestAccept(quest);
        //몬스터 3마리만 처치
        minieon.Name = "미니언";
        for (int i = 0; i < 3; i++) //던전 생략 슬라임 3번 사망
        {
            minieon.Dead();
        }

        questManager.GetQuest(quest);//퀘스트 정보 출력

        //몬스터 2마리 더 처치
        minieon.Name = "미니언";
        for (int i = 0; i < 2; i++)
        {
            minieon.Dead();
        }
        questManager.GetQuest(quest);//퀘스트 정보 출력

        

        //골렘처치<< 미니언 처치와 동일
        //아무 장비장착 퀘스트<<인벤토리에서 값을 받아 와야함
        //레벨업 퀘스트<<레벨업이 됐는지 확인하는 방법이 필요함







        if (quest.isAlready)//퀘스트를 클리어 했는데 또 들어올 경우
        {
            Console.WriteLine("이미 퀘스트를 클리어 했습니다.");
        }
        else
        {
            //해당 퀘스트의 조건을 클리어했을때만 보상받기 가능
            if (quest.isComplete)//퀘스트 완료 여부
            {
                Console.WriteLine("퀘스트를 완료했으므로 보상을 드립니다.");
                quest.Already(); //퀘스트 재수락 체크
            }
        }

    }
}

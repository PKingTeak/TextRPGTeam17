using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;
using TextRPG.QuestSystem;
using System.Security.Cryptography.X509Certificates;
namespace TextRPG.Scene.Pages
{
    class QuestScene : Scene
    {
        QuestManager questManager;
        Player player;
        public QuestScene(SceneManager sceneManager) : base(sceneManager)
        {
            questManager = sceneManager.QuestManager;
            sceneName = "Quest!!";
            sceneDescription = "이곳에서 퀘스트를 진행할 수 있습니다.";
            type = SceneType.Quest;
            // 퀘스트 정보 저장
            questManager.SetQuest(10001, "마을을 위협하는 미니언 처치", "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\r\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\r\n모험가인 자네가 좀 처치해주게!", "미니언", 5, "마리 처치하기", "쓸만한 방패 x 1\n5G");
            questManager.SetQuest(10004, "협곡을 부수는 골렘 처치", "이봐! 골렘 잡아", "골렘", 20, "마리 처치", "무한의 대검 x 1 , 500G");
            questManager.SetQuest(10002, "장비를 장착해보자", "모험을 떠나기 전엔 기본 장비부터 챙기는 게 좋지 않겠어?\r\n몸을 보호하려면 방어구 하나쯤은 필요하고, 적을 상대하려면 무기도 있어야 하니까 말이야.\r\n인벤토리를 열고 아무 장비나 하나 장착해봐!\r\n별거 아닐 것 같아도, 그게 모험의 시작이니까!", "장비", 1, "개 장착하기", "초급 전투복 x 1\n3G");
            questManager.SetQuest(10003, "더욱 더 강해지기!", "모험가라면 레벨을 올리는 건 기본이지!\r\n레벨이 올라가면 능력치도 올라가고, 새로운 스킬도 배울 수 있어!\r\n레벨을 올리기 위해선 몬스터를 처치하고 경험치를 얻어야 해.\r\n그럼 자네의 모험이 시작되는 거야!", "레벨", 1, " 이상 올리기", "힘의 물약 x 2\n8G");
            this.player = sceneManager.Player;
        }

        public override void ShowScene()
        {
            sceneManager.QuestManager.Subscribe(player);

            Console.WriteLine($"{sceneName}\n{sceneDescription}\n");
            int questID = InputHandler.ChooseAction(0, 3, "1. 마을을 위협하는 미니언 처치\n" +
                                                         "2. 장비를 장착해보자\n" +
                                                         "3. 더욱 더 강해지기!\n" +
                                                         "0. 나가기", "원하시는 퀘스트를 선택해주세요.");
            Quest quest = new Quest(); //빈 퀘스트
            switch (questID)
            {
                case 0:
                    sceneManager.PopScene();
                    break;
                case 1:
                    quest = questManager.FindQuest(10001); //특정 퀘스트 찾기
                    QuestControl(quest);
                    break;
                case 2:
                    quest = questManager.FindQuest(10002);
                    QuestControl(quest);
                    break;
                case 3:
                    quest = questManager.FindQuest(10003);
                    QuestControl(quest);
                    break;

            }
        }
        public void QuestControl(Quest quest)//퀘스트 각종 제어문
        {
            if (quest.isRewardGet)
            {
                Console.WriteLine("이미 보상을 받고 완료한 퀘스트 입니다.");
                Thread.Sleep(1000);
                return;
            }

            Console.Clear();
            questManager.GetQuest(quest); //해당 퀘스트 정보 출력

            if (quest.isAccepted)
                QuestReward(quest); //퀘스트 보상받기,돌아가기
            else
                QuestSelect(quest); //퀘스트 수락,거절
        }


        public void QuestSelect(Quest quest)//퀘스트 수락,거절
        {
            int select = InputHandler.ChooseAction(0, 2, "1. 수락" +
                                                         "\n2. 거절", "원하시는 행동을 입력해주세요.");
            switch (select)
            {
                case 1:
                    quest.ResetQuest();//퀘스트 수락체크
                    Console.WriteLine(quest.questTitle + "퀘스트를 수락하였습니다.");
                    Thread.Sleep(500);
                    break;
                default:
                    break;
            }
        }

        public void QuestReward(Quest quest)//퀘스트 보상받기,돌아가기
        {
            Console.WriteLine($"{sceneName}\n{sceneDescription}\n");
            int select = InputHandler.ChooseAction(0, 2, "1. 완료" +
                                                         "\n2. 포기", "원하시는 행동을 입력해주세요.");

            switch (select)
            {
                case 1:
                    if (quest.isComplete)
                    {
                        Console.WriteLine("보상을 드렸습니다.");
                        quest.RewardGet();//보상완료 체크
                        quest.ResetQuest();
                    }
                    else
                        Console.WriteLine("조건을 충족하지 못했습니다.");

                    Thread.Sleep(500);
                    break;

                case 2:
                    // 퀘스트 포기
                    quest.ResetQuest();
                    break;
            }
        }

    }
}

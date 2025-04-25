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

        string monsterName = Monster.GetRandomMonsterName();

        public QuestScene(SceneManager sceneManager) : base(sceneManager)
        {
            questManager = sceneManager.QuestManager;
            sceneName = "Quest!!";
            sceneDescription = "이곳에서 퀘스트를 진행할 수 있습니다.";
            type = SceneType.Quest;

            // 퀘스트 정보 저장
            questManager.InitQuest(monsterName);

            this.player = sceneManager.Player;
            sceneManager.QuestManager.Subscribe(player);
        }

        public override void ShowScene()
        {
            Console.WriteLine($"{sceneName}\n{sceneDescription}\n");
            int questID = InputHandler.ChooseAction(0, 3, $"1. 마을을 위협하는 {monsterName} 처치\n" +
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
                    quest.Accept();//퀘스트 수락체크
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
                        
                        if(quest.QuestID == 10001)
                        {
                            monsterName = Monster.GetRandomMonsterName();
                            quest.ChangeTarget(monsterName);
                        }
                        
                        quest.ResetQuest();
                    }
                    else
                        Console.WriteLine("조건을 충족하지 못했습니다.");

                    Thread.Sleep(1000);
                    break;

                case 2:
                    // 퀘스트 포기
                    quest.ResetQuest();
                    Console.WriteLine("퀘스트를 포기하셨습니다.");

                    Thread.Sleep(1000);
                    break;
            }
        }

    }
}

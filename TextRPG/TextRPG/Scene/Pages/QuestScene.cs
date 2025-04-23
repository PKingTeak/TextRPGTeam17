using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene.Pages
{
    class QuestScene : Scene
    {

        public QuestScene(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "Quest!!";
            sceneDescription = "";
            type = SceneType.Quest;
        }
        public override void ShowScene()
        {
            Console.WriteLine($"{sceneName}\n{sceneDescription}\n");
            // 플레이어 정보 출력
            int choice = InputHandler.ChooseAction(0, 4, "1. 마을을 위협하는 미니언 처치\n" +
                                                         "2. 장비를 장착해보자\n" +
                                                         "3. 더욱 더 강해지기!\n" +
                                                         "0. 나가기", "원하시는 퀘스트를 선택해주세요.");
            switch (choice)
            {
                case 0:
                    sceneManager.PopScene();
                    break;
                case 1:
                    // 퀘스트 수락 로직
                    break;
                case 2:
                    // 퀘스트 진행 로직
                    break;
                case 3:
                    // 퀘스트 완료 로직
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine();
                    break;
            }
        }



    }
}

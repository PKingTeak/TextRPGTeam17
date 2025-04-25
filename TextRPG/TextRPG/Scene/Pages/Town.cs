using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

namespace TextRPG.Scene.Pages
{
    public class Town :Scene
    {
        public Town(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "[마을]";
            sceneDescription = "스파르타 던전에 오신 여러분 환영합니다.\n이제 전투를 시작할 수 있습니다.";
            type = SceneType.Town;
            
        }
        public override void ShowScene()
        {
        
            Console.WriteLine($"{sceneName}\n{sceneDescription}\n");

            // 플레이어 정보 출력

            int choice = InputHandler.ChooseAction(0, 5, "1. 상태보기\n" +
                                                         "2. 인벤토리\n" +
                                                         "3. 상점\n" +
                                                         "4. 전투 시작\n" +
                                                         "5. 퀘스트\n" +
                                                         "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch(choice)
            {
                case 0:
                    sceneManager.PopScene();
                    break;
                case 1:
                    sceneManager.AddScene(SceneType.Status);
                    break;
                case 2:
                    sceneManager.AddScene(SceneType.Inventory);
                    break;
                case 3:
                    sceneManager.AddScene(SceneType.Shop);
                    break;
                case 4:
                    sceneManager.AddScene(SceneType.Battle);
                    break;
                case 5:
                    sceneManager.AddScene(SceneType.Quest);
                    break;
            }
        }
    }
}

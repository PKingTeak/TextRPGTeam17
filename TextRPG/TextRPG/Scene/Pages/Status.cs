using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene.Pages
{
    internal class Status:Scene
    {
        // Player 객체 변수 생성

        public Status(string sceneName, string sceneDescription, SceneManager sceneManager) : base(sceneName, sceneDescription, sceneManager)
        {
            // 매개변수로 Player 객체 받아와 Player 변수 할당
        }

        public override void ShowScene()
        {
            Console.WriteLine($"{sceneName}\n{sceneDescription}");

            // 플레이어 정보 출력

            int choice = InputHandler.ChooseAction(0, 0, "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch(choice)
            {
                case 0:
                    sceneManager.PopScene();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

namespace TextRPG.Scene.Pages
{
    public class Status:Scene
    {
        public Status(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "\u001b[38;2;255;255;131m[상태 보기]\u001b[0m";
            sceneDescription = "캐릭터의 정보가 표시됩니다.";
            type = SceneType.Status;
        }

        public override void ShowScene()
        {
            Console.WriteLine($"{sceneName}\n{sceneDescription}\n");

            // 플레이어 정보 출력
            sceneManager.Player.ShowInfo();
            Console.WriteLine();

            int choice = InputHandler.ChooseAction(0, 0, "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch(choice)
            {
                case 0:
                    sceneManager.PopScene();
                    break;
            }
        }
    }
}

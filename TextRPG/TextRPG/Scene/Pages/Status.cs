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
        Player player;

        public Status(SceneManager sceneManager, Player player) : base(sceneManager)
        {
            sceneName = "상태 보기";
            sceneDescription = "캐릭터의 정보가 표시됩니다.";
            type = SceneType.Status;
            this.player = player;
        }

        public override void ShowScene()
        {
            Console.WriteLine($"{sceneName}\n{sceneDescription}\n");

            // 플레이어 정보 출력
            player.ShowInfo();
            Console.WriteLine();

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

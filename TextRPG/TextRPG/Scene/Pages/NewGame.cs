using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextRPG.Unit.Child;

namespace TextRPG.Scene.Pages
{
    public class NewGame:Scene
    {
        public NewGame(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "\u001b[38;2;255;255;131m[캐릭터 생성]\u001b[0m";
            sceneDescription = "스파르타 마을에 오신걸 환영합니다.\n캐릭터 정보를 입력해 주세요";
            type = SceneType.NewGame;
        }

        public override void ShowScene()
        {
            string name = InputName();
            PlayerType pType = ChooseClass();
            sceneManager.InitPlayer(name, pType);

            sceneManager.PopScene();
            sceneManager.AddScene(SceneType.Town);
        }

        private string InputName()
        {
            string name;
            bool confirm = false;

            do
            {
                Console.Clear();
                Console.WriteLine($"{sceneName}\n{sceneDescription}\n");

                Console.Write("이름을 알려주세요 : ");
                name = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();

                int choice = InputHandler.ChooseAction(1, 2, $"이름이 [{name}], 맞나요?\n" +
                                                              "1. 네\n" +
                                                              "2. 아니요", "원하시는 행동을 입력해주세요.");
                if(choice == 1) confirm = true;
            } while(!confirm);

            return name;
        }

        private PlayerType ChooseClass()
        {
            PlayerType pType = PlayerType.Warrior;
            bool confirm = false;
            string[] className = { "전사", "궁수", "도적", "마법사" };

            do
            {
                Console.Clear();
                Console.WriteLine($"{sceneName}\n{sceneDescription}\n");
                int choice = InputHandler.ChooseAction(1, 4, $"직업을 선택해 주세요.\n" +
                                                              "1. 전사\n" +
                                                              "2. 궁수\n" +
                                                              "3. 도적\n" +
                                                              "4. 마법사", "원하시는 직업을 입력해주세요.");
                switch(choice)
                {
                    case -1:
                        continue;
                    default:
                        pType = (PlayerType)(choice - 1);
                        break;
                }
                Console.Clear();
                choice = InputHandler.ChooseAction(1, 2, $"직업은 [{className[choice - 1]}], 맞나요?\n" +
                                                              "1. 네\n" +
                                                              "2. 아니요", "원하시는 행동을 입력해주세요.");
                if(choice == 1) confirm = true;
            } while(!confirm);

            return pType;
        }
    }
}

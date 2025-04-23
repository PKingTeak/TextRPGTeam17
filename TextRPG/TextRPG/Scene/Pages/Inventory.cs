using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

namespace TextRPG.Scene.Pages
{
    public class Inventory :Scene
    {
        private enum InvenMode
        {
            Inventory,
            Equipment
        }
        private InvenMode invenMode = InvenMode.Inventory;

        public Inventory(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "인벤토리";
            sceneDescription = "보유 중인 아이템을 관리할 수 있습니다.";
            type = SceneType.Inventory;
        }
        public override void ShowScene()
        {
            /*
foreach (var mon in monsters)
{
  questManager.Subscribe(mon); // 모든 몬스터 구독
}
*/
            Monster monster = new Monster("미니언");
            questManager.Subscribe(monster);

            for (int i = 0; i < 5; i++)
            {
                monster.Dead();
                Console.WriteLine("몬스터 처치");
            }
            string subTitle = "";
            if(invenMode == InvenMode.Equipment)
            {
                subTitle = " - 장비 관리";
            }

            Console.WriteLine($"{sceneName}{subTitle}\n{sceneDescription}\n");

            switch(invenMode)
            {
                case InvenMode.Inventory:
                    ShowInventory();
                    break;
                case InvenMode.Equipment:
                    ShowEquipment();
                    break;
            }
        }

        private void ShowInventory()
        {
            // 플레이어 정보 출력

            int choice = InputHandler.ChooseAction(0, 1, "1. 장착관리\n" +
                                                         "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch(choice)
            {
                case 0:
                    invenMode = InvenMode.Inventory;
                    sceneManager.PopScene();
                    break;
                case 1:
                    invenMode = InvenMode.Equipment;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine();
                    break;
            }
        }

        private void ShowEquipment()
        {
            // 플레이어 정보 출력(장착 여부 표시)

            int choice = InputHandler.ChooseAction(0, 0, "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch(choice)
            {
                case 0:
                    invenMode = InvenMode.Inventory;
                    break;
                case -1:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine();
                    break;
                default:
                    // 선택 장비 장착
                    break;
            }
        }
    }
}

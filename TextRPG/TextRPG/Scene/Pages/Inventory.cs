using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string subTitle = "";
            if(invenMode == InvenMode.Equipment)
            {
                subTitle = " - 장비 관리";
            }

            Console.WriteLine($"{sceneName}{subTitle}\n{sceneDescription}\n");
            Console.WriteLine();

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
            for(int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                Console.WriteLine($"{sceneManager.ItemManager.ShowItems(i)}");
            }
            Console.WriteLine();

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
            for(int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sceneManager.ItemManager.ShowItems(i)}");
            }

            int choice = InputHandler.ChooseAction(0, sceneManager.ItemManager.Items.Count, "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch(choice)
            {
                case 0:
                    invenMode = InvenMode.Inventory;
                    break;
                default:
                    // 선택 장비 장착
                    break;
            }
        }
    }
}

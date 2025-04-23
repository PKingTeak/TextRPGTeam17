using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

namespace TextRPG.Scene.Pages
{
    public class Inventory : ItemContainer
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
            if (invenMode == InvenMode.Equipment)
            {
                subTitle = " - 장비 관리";
            }

            Console.WriteLine($"{sceneName}{subTitle}\n{sceneDescription}\n");
            Console.WriteLine();

            switch (invenMode)
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
            itemInfoTypes.Clear();
            itemInfoTypes.Add(ItemInfoType.NameAndDescription);

            for (int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                if(sceneManager.ItemManager.Items[i].IsOwned)
                {
                    Console.WriteLine($"{PickItemInfo(i, itemInfoTypes)}/ {GetItemStatus(i)}"); // 소지 중인 아이템만 출력
                }
            }
            Console.WriteLine();

            int choice = InputHandler.ChooseAction(0, 1, "1. 장착관리\n" +
                                                         "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch (choice)
            {
                case 0:
                    invenMode = InvenMode.Inventory;
                    sceneManager.PopScene();
                    break;
                case 1:
                    invenMode = InvenMode.Equipment;
                    break;
            }
        }

        private void ShowEquipment()
        {
            itemInfoTypes.Clear();
            itemInfoTypes.Add(ItemInfoType.NameAndDescription);
            itemInfoTypes.Add(ItemInfoType.IsEquipped);

            for (int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                if(sceneManager.ItemManager.Items[i].IsOwned)
                {
                    Console.WriteLine($"{i + 1}. {PickItemInfo(i, itemInfoTypes)}/ {GetItemStatus(i)}"); // 소지 중인 아이템만 출력
                }
            }
            Console.WriteLine();

            int choice = InputHandler.ChooseAction(0, sceneManager.ItemManager.Items.Count, "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch (choice)
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

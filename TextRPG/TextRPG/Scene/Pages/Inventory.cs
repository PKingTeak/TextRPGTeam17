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
            sceneName = "\u001b[38;2;255;255;131m[인벤토리]\u001b[0m";
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
            itemInfoList.Clear();
            itemInfoList.Add(ItemInfoType.NameAndDescription);

            ShowItemList(itemInfoList, (int x) => sceneManager.ItemManager.Items[x].IsOwned, false); // 소지 중인 아이템만 출력
            ShowItemList(itemInfoList, (int x) => sceneManager.ItemManager.Items[x].Count > 0, false);
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
            sceneManager.ItemManager.ShowEquippedItems();
            Console.WriteLine();

            itemInfoList.Clear();
            itemInfoList.Add(ItemInfoType.NameAndDescription);
            itemInfoList.Add(ItemInfoType.IsEquipped);

            ShowItemList(itemInfoList, (int x) => sceneManager.ItemManager.Items[x].IsOwned, true); // 소지 중인 아이템만 출력

            int choice = InputHandler.ChooseAction(0, showItemList.Count, "0. 나가기", "원하시는 행동을 입력해주세요.");

            switch (choice)
            {
                case 0:
                    invenMode = InvenMode.Inventory;
                    break;
                case -1:
                    break;
                default:
                    // 보유중인 아이템 목록 중에서 선택한 아이템이 전체 아이템 중 몇 번째인지 찾기
                    int itemIdx = sceneManager.ItemManager.Items.FindIndex(x => x.Equals(showItemList[choice - 1]));
                    sceneManager.ItemManager.EquipItemByIndex(itemIdx);
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }
        }
    }
}

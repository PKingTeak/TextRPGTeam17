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
           this.player = sceneManager.Player;//테스트
            sceneName = "인벤토리";
            sceneDescription = "보유 중인 아이템을 관리할 수 있습니다.";
            type = SceneType.Inventory;
        }
             Player player;//테스트
        public override void ShowScene()
        {         
        //테스트
            sceneManager.QuestManager.Subscribe(player);
            player.RewardExp(10000);//레벨업퀘스트깨기
            Item item=new Item("불꽃의 검", new Dictionary<Item.ItemType, int> { { Item.ItemType.WeaPon, 15 } }, "불 속성을 띤 강력한 검.", 1000);
            player.EquimentItem(item);//장비장착퀘스트 깨기
            Monster mon =new Monster("미니언");
            sceneManager.QuestManager.Subscribe(mon);//미니언 5마리 처치퀘스트 깨기
            for(int i=0;i<5;i++)
            {
                mon.Dead();
            }
        //테스트

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
            itemInfoList.Clear();
            itemInfoList.Add(ItemInfoType.NameAndDescription);

            ShowItemList(itemInfoList, (int x) => sceneManager.ItemManager.Items[x].IsOwned, false); // 소지 중인 아이템만 출력

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

namespace TextRPG.Scene.Pages
{
    public class Inventory : Scene
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
                        Monster monster = new Monster("미니언");
            questManager.Subscribe(monster);

            for (int i = 0; i < 5; i++)
            {
                monster.Dead();
            }
            
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
            for (int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                if (CheckOwnedItem(i))
                {
                    Console.WriteLine($"{PickItemInfo(i)}/ {GetItemStatus(i)}"); // 소지 중인 아이템만 출력
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
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine();
                    break;
            }
        }

        private void ShowEquipment()
        {
            for (int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                if (CheckOwnedItem(i))
                {
                    Console.WriteLine($"{i + 1}. {PickItemInfo(i)}/ {GetItemStatus(i)}"); // 소지 중인 아이템만 출력
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

        private string GetItemStatus(int idx)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<Item.ItemType, int> stats in sceneManager.ItemManager.Items[idx].Stats)
            {
                switch (stats.Key)
                {
                    case Item.ItemType.WeaPon:
                        sb.Append($"공격력 +{stats.Value}");
                        break;
                    case Item.ItemType.Armor:
                        sb.Append($"방어력 +{stats.Value}");
                        break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 아이템 정보에서 소지 여부를 확인합니다.
        /// </summary>
        /// <param name="idx">확인할 아이템 인덱스</param>
        /// <returns>아이템 소지 여부</returns>
        private bool CheckOwnedItem(int idx)
        {
            // {Name} - {Description} / Price: {Price} / Owned: {IsOwned} / Equipped: {IsEquipped}
            string itemInfo = sceneManager.ItemManager.ShowItems(idx);

            // Owned: True인 경우 체크
            if (itemInfo.Split('/')[2].ToUpper().Contains("TRUE"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 아이템 정보에서 이름과 설명만 추출하여 반환합니다.
        /// </summary>
        /// <param name="idx">추출할 아이템 인덱스</param>
        /// <returns>아이템의 이름과 설명</returns>
        private string PickItemInfo(int idx)
        {
            // {Name} - {Description} / Price: {Price} / Owned: {IsOwned} / Equipped: {IsEquipped}
            string itemInfos = sceneManager.ItemManager.ShowItems(idx);
            int targetSlashIdx = itemInfos.IndexOf('/');

            return itemInfos.Substring(0, targetSlashIdx); // 슬래시까지의 문자열 반환
        }
    }
}

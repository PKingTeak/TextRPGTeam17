﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    public abstract class ItemContainer : Scene
    {
        protected enum ItemInfoType
        {
            NameAndDescription,
            Price,
            IsOwned,
            IsEquipped
        }
        protected List<ItemInfoType> itemInfoList = new List<ItemInfoType>(); // 아이템 정보 목록
        protected List<Item> showItemList = new List<Item>(); // 화면에 보여줄 아이템 목록

        protected ItemContainer(SceneManager sceneManager) : base(sceneManager)
        {
        }

        /// <summary>
        /// 아이템 정보를 출력합니다.
        /// </summary>
        /// <param name="infoTypes">출력할 아이템 정보 목록</param>
        /// <param name="condition">출력할 아이템 선발 조건 판별 메서드</param>
        /// <param name="isShowIdx">아이템 목록에 순서를 표시할 숫자 출력 여부</param>
        protected void ShowItemList(List<ItemInfoType> infoList, Func<int, bool> condition, bool isShowIdx)
        {
            showItemList.Clear(); // 화면에 보여줄 아이템 목록 초기화
            int num = 0; // 아이템 번호 초기화

            for (int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                if (condition(i))
                {
                    if (isShowIdx)
                    {
                        Console.Write($"{++num}. "); // 인덱스 출력
                    }
                    showItemList.Add(sceneManager.ItemManager.Items[i]); // 조건에 맞는 아이템 추가
                    Console.WriteLine($"{PickItemInfo(i, infoList)}/ {GetItemStatus(i)}"); // 소지 중인 아이템만 출력
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 아이템의 능력치를 가져옵니다.
        /// </summary>
        /// <param name="idx">능력치를 가져올 아이템 인덱스</param>
        /// <returns>아이템의 능력치</returns>
        protected string GetItemStatus(int idx)
        {
            StringBuilder sb = new StringBuilder();

            var item = sceneManager.ItemManager.Items[idx];

            switch (item.itemType)
            {
                case Item.ItemType.Weapon:
                    sb.Append($"공격력 +{item.Value}");
                    break;

                case Item.ItemType.Armor:
                    sb.Append($"방어력 +{item.Value}");
                    break;

            }

            return sb.ToString();
        }

        /// <summary>
        /// 아이템 정보에서 원하는 값을 추출하여 반환합니다.
        /// {Name} - {Description} / Price: {Price} / Owned: {IsOwned} / Equipped: {IsEquipped}
        /// " / "로 구분된 문자열에서 원하는 정보를 추출합니다.
        /// </summary>
        /// <param name="idx">추출할 아이템 인덱스</param>
        /// <param name="pickRange">추출할 정보의 마지막 인덱스</param>
        /// <returns>추출한 정보</returns>
        protected string PickItemInfo(int idx, List<ItemInfoType> infoList)
        {
            string[] itemInfos = sceneManager.ItemManager.ShowItems(idx).Split(" / ");
            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < infoList.Count; i++)
            {
                int infoIdx = (int)infoList[i];
                sb.Append(itemInfos[infoIdx]);

                // 마지막 정보가 아닐 경우 슬래시 추가
                if (i != infoList.Count - 1)
                {
                    sb.Append(" / ");
                }
            }

            return sb.ToString(); // 슬래시까지의 문자열 반환
        }
    }
}

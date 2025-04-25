using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene.Pages
{
    public class Shop:ItemContainer
    {
        private enum ShopMode
        {
            Shop,
            Buy,
            Sell
        }
        private ShopMode shopMode = ShopMode.Shop;
        private delegate void ShopAction(Item item);
        private event ShopAction OnShopAction;

        public Shop(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "\u001b[38;2;255;255;131m[상점]\u001b[0m";
            sceneDescription = "필요한 아이템을 얻을 수 있는 상점입니다.";
            type = SceneType.Shop;
        }
        public override void ShowScene()
        {
            string subTitle = "";
            if(shopMode == ShopMode.Buy)
            {
                subTitle = " - 구매";
            }
            else if(shopMode == ShopMode.Sell)
            {
                subTitle = " - 판매";
            }

            Console.WriteLine($"{sceneName}{subTitle}\n{sceneDescription}\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(sceneManager.Player.state.Gold + " G");
            Console.WriteLine();

            switch(shopMode)
            {
                case ShopMode.Shop:
                    ShowShop();
                    break;
                case ShopMode.Buy:
                    ShowBuyOrSell();
                    break;
                case ShopMode.Sell:
                    ShowBuyOrSell();
                    break;
            }
        }

        private void ShowShop()
        {
            itemInfoList.Clear();
            itemInfoList.Add(ItemInfoType.NameAndDescription);
            itemInfoList.Add(ItemInfoType.Price);
            itemInfoList.Add(ItemInfoType.IsOwned);

            ShowItemList(itemInfoList, (int x) => true, false); // 모든 아이템 출력

            int choice = InputHandler.ChooseAction(0, 2, "1. 아이템 구매\n" +
                                                         "2. 아이템 판매\n" +
                                                         "0. 나가기", "원하시는 행동을 입력해주세요.");
            switch(choice)
            {
                case 0:
                    shopMode = ShopMode.Shop;
                    sceneManager.PopScene();
                    break;
                case 1:
                    shopMode = ShopMode.Buy;
                    break;
                case 2:
                    shopMode = ShopMode.Sell;
                    break;
            }
        }

        private void ShowBuyOrSell()
        {
            int usingGoldType = 1; // 1 : 골드 증가, -1 : 골드 감소

            itemInfoList.Clear();
            itemInfoList.Add(ItemInfoType.NameAndDescription);
            itemInfoList.Add(ItemInfoType.Price);

            if(shopMode == ShopMode.Buy)
            {
                ShowItemList(itemInfoList, (int x) => !sceneManager.ItemManager.Items[x].IsOwned, true);
                OnShopAction = sceneManager.ItemManager.BuyItem;
                usingGoldType = -1; // 구매 시 골드 감소
            }
            else if(shopMode == ShopMode.Sell)
            {
                ShowItemList(itemInfoList, (int x) => sceneManager.ItemManager.Items[x].IsOwned, true);
                OnShopAction = sceneManager.ItemManager.SellItem;
                usingGoldType = 1; // 판매 시 골드 증가
            }

            int choice = InputHandler.ChooseAction(0, showItemList.Count, "0. 나가기", "아이템 번호를 입력해주세요.");
            switch(choice)
            {
                case 0:
                    shopMode = ShopMode.Shop;
                    break;
                case -1:
                    break;
                default:
                    // 구매/판매 로직
                    OnShopAction(showItemList[choice - 1]);
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene.Pages
{
    public class Shop:Scene
    {
        private enum ShopMode
        {
            Shop,
            Buy,
            Sell
        }
        private ShopMode shopMode = ShopMode.Shop;

        public Shop(SceneManager sceneManager) : base(sceneManager)
        {
            sceneName = "상점";
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
            for(int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                Console.WriteLine($"{sceneManager.ItemManager.ShowItems(i)}");
            }
            Console.WriteLine();

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
            for(int i = 0; i < sceneManager.ItemManager.Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sceneManager.ItemManager.ShowItems(i)}");
            }
            Console.WriteLine();

            int choice = InputHandler.ChooseAction(0, 2, "0. 나가기", "아이템 번호를 입력해주세요.");
            switch(choice)
            {
                case 0:
                    shopMode = ShopMode.Shop;
                    break;
                default:
                    // 구매/판매 로직
                    break;
            }
        }
    }
}

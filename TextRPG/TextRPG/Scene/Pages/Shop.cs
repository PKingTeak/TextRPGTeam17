using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene.Pages
{
    public class Shop :Scene
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

            switch(shopMode)
            {
                case ShopMode.Shop:

                    break;
                case ShopMode.Buy:

                    break;
                case ShopMode.Sell:

                    break;
            }
        }
    }
}

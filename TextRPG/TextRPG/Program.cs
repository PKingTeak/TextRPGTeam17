
using TextRPG.Scene;
using TextRPG.Unit.Child;

namespace Program
{
    class MainGame
    {
        static void Main(string[] args)
        {
            // 플레이어 객체 생성 및 정보 입력
            Player player = new Archer("asd"); // 테스트용 객체 생성
            SceneManager sceneManager = new SceneManager(player);

            while(sceneManager.StackCount > 0)
            {
                sceneManager.ShowCurrentScene();
            }

            Console.WriteLine("게임 종료");
        }
    };
}
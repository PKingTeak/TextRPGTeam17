
using TextRPG.Scene;

namespace Program
{
    class MainGame
    {
        static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager();
            
            while(sceneManager.StackCount > 0)
            {
                sceneManager.ShowCurrentScene();
            }

            Console.WriteLine("게임 종료");
        }
    };
}
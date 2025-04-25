using TextRPG.Scene;



class Program
{

    static void Main(string[] args)
    {
        Opening opening=new Opening();
        opening.Show();
        SceneManager sceneManager = new SceneManager();

        while (sceneManager.StackCount > 0)
        {
            Console.Clear();
            sceneManager.ShowCurrentScene();
        }
        Console.WriteLine("게임 종료");
    }
}

using System;
using TextRPG.Scene;
using TextRPG.Unit.Child;



class Program
{

    static void Main(string[] args)
    {

        // 플레이어 객체 생성 및 정보 입력
        Console.WriteLine("이름을 입력해주세요");
        string Input = Console.ReadLine();
        Player player = new Warrior(Input);
        player.SetJob(Input);



        SceneManager sceneManager = new SceneManager(player);

        while (sceneManager.StackCount > 0)
        {
            sceneManager.ShowCurrentScene();
        }
        Console.WriteLine("게임 종료");

       

    }
}

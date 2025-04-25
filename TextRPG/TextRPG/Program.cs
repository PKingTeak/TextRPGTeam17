using System;
using System.Security.Cryptography;
using TextRPG.QuestSystem;
using TextRPG.Scene;
using TextRPG.Unit.Child;



class Program
{

    static void Main(string[] args)
    {
        SceneManager sceneManager = new SceneManager();

        while (sceneManager.StackCount > 0)
        {
            Console.Clear();
            sceneManager.ShowCurrentScene();
        }
        Console.WriteLine("게임 종료");
    }
}

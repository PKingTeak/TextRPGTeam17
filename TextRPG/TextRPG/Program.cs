using TextRPG.QuestSystem;
using TextRPG.Scene;
using TextRPG.Unit.Child;



class Program
{

    static void Main(string[] args)
    {
        

        // 플레이어 객체 생성 및 정보 입력
        Console.WriteLine("이름을 입력해주세요");
        string Input = Console.ReadLine();
        Player player = Player.SetJob(Input);
        
        ItemManager itemManager = new ItemManager(player);
        QuestManager questManager = new QuestManager();

       // Item newItem = new Item("검",Item.ItemType.WeaPon, 10 ,"단단한 검이다.", 1000);

        SceneManager sceneManager = new SceneManager(player, itemManager, questManager);

        while (sceneManager.StackCount > 0)
        {
            Console.Clear();
            sceneManager.ShowCurrentScene();
        }
        Console.WriteLine("게임 종료");
    }
}

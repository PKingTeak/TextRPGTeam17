using TextRPG.Scene;
using TextRPG.Unit;
using TextRPG.Unit.Child;
using Program;
namespace TextRPG.Scene
{
    public class BattleScene : Scene
    {
        public BattleScene(string sceneName, string sceneDescription, SceneManager sceneManager) : base(sceneName, sceneDescription, sceneManager){}

        Player player;

        int floor = 1; // 던전의 층수
        MonsterSpawner spawner = new MonsterSpawner();
        List<string> monsters = new List<string>();
        private bool isBattle = false;

        public override void ShowScene()
        {
            isBattle = true;
            monsters = spawner.SpawnMonsters(floor);

            while (isBattle)
            {
                // 전투 UI 출력
                Console.Clear();
                Console.WriteLine("Battle!!");
                Console.WriteLine();

                //몬스터 출력


                // 플레이어 정보 표시
                Console.WriteLine("[내정보]");
                

                int choice = InputHandler.ChooseAction(1, 2, "1. 공격\n2. 스킬", "원하시는 행동을 입력해주세요.\n");
            }
        }
        void PlayerPhase(int choice)
        {
            // 플레이어 페이즈

            switch (choice)
            {

            }
        }

        void MonstersPhase()
        {
            // 몬스터 페이즈
        }
    }
}

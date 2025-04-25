using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.QuestSystem;
using TextRPG.Scene.Pages;
using TextRPG.Unit.Child;

namespace TextRPG.Scene
{
    public class SceneManager
    {
        private List<Scene> sceneList;
        private Stack<Action> sceneStack;

        public ItemManager ItemManager { get; private set; }
        public Player Player { get; private set; }
        public QuestManager QuestManager { get; private set; }

        /// <summary>
        /// 장면 스택의 개수를 반환하는 프로퍼티
        /// </summary>
        public int StackCount
        {
            get { return sceneStack.Count; }
        }

        public SceneManager()
        {
            sceneList = new List<Scene>();
            sceneStack = new Stack<Action>();
            
            sceneList.Add(new NewGame(this));
            sceneStack.Push(sceneList.Find(x => x.SceneType == SceneType.NewGame).Show);
        }

        public void InitPlayer(string name, PlayerType type)
        {
            // 플레이어 생성
            Player = Player.SetJob(name, type);

            // 게임 시작
            // 객체 생성
            ItemManager = new ItemManager(Player);
            QuestManager = new QuestManager();
            // 화면 로드
            sceneList.Add(new Town(this));
            sceneList.Add(new Status(this));
            sceneList.Add(new Inventory(this));
            sceneList.Add(new Shop(this));
            sceneList.Add(new BattleScene(this));
            sceneList.Add(new QuestScene(this));
        }

        /// <summary>
        /// 장면을 스택에 추가하는 메소드
        /// </summary>
        /// <param name="scene">추가할 장면 이름</param>
        public void AddScene(SceneType type)
        {
            sceneStack.Push(sceneList.Find(x => x.SceneType == type).Show);
        }
        /// <summary>
        /// 스택에서 장면을 꺼내는 메소드
        /// </summary>
        public void PopScene()
        {
            if (sceneStack.Count > 0)
            {
                sceneStack.Pop();
            }
            else
            {
                Console.WriteLine("스택이 비어있습니다.");
            }
        }
        /// <summary>
        /// 현재 장면을 보여주는 메소드
        /// </summary>
        public void ShowCurrentScene()
        {
            if (sceneStack.Count > 0)
            {
                sceneStack.Peek()();
            }
            else
            {
                Console.WriteLine("게임 종료");
            }
        }
    }
}

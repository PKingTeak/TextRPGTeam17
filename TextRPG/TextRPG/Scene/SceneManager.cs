using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    public class SceneManager
    {
        private List<Scene> sceneList;
        private Stack<Action> sceneStack;

        public SceneManager()
        {
            sceneList = new List<Scene>();
            sceneStack = new Stack<Action>();
        }

        /// <summary>
        /// 장면을 스택에 추가하는 메소드
        /// </summary>
        /// <param name="scene">추가할 장면 이름</param>
        public void AddScene(string scene)
        {
            sceneStack.Push(sceneList.Find(x => x.SceneName == scene).Show);
        }
        /// <summary>
        /// 스택에서 장면을 꺼내는 메소드
        /// </summary>
        public void PopScene()
        {
            if(sceneStack.Count > 0)
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
            if(sceneStack.Count > 0)
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

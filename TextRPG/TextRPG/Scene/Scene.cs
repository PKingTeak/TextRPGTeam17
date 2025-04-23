using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.QuestSystem;

namespace TextRPG.Scene
{
    public enum SceneType
    {
        Town,
        Status,
        Inventory,
        Shop,
        Battle,
        Quest
    }

    public abstract class Scene
    {
        protected string sceneName;
        protected string sceneDescription;
        protected SceneManager sceneManager;
        protected QuestManager questManager=new QuestManager();
        protected SceneType type;

        public SceneType SceneType { get { return type; } }

        /// <summary>
        /// 장면을 보여주는 메소드
        /// 장면을 스택 구조를 활용해 구현하기 위해 Action으로 정의
        /// </summary>
        public Action Show { get; }

        public Scene(SceneManager sceneManager)
        {
            Show = ShowScene;
            this.sceneManager = sceneManager;
        }

        /// <summary>
        /// 장면을 보여주는 메소드
        /// </summary>
        public abstract void ShowScene();
    }
}

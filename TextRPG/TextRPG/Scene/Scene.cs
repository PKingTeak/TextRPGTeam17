using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

namespace TextRPG.Scene
{
    public abstract class Scene
    {
        protected string sceneName;
        protected string sceneDescription;
        protected SceneManager sceneManager;

        public string SceneName { get { return sceneName; } }

        /// <summary>
        /// 장면을 보여주는 메소드
        /// 장면을 스택 구조를 활용해 구현하기 위해 Action으로 정의
        /// </summary>
        public Action Show { get; }

        public Scene(string sceneName, string sceneDescription, SceneManager sceneManager)
        {
            this.sceneName = sceneName;
            this.sceneDescription = sceneDescription;
            Show = ShowScene;
            this.sceneManager = sceneManager;
        }

        /// <summary>
        /// 장면을 보여주는 메소드
        /// </summary>
        public abstract void ShowScene();
    }
}

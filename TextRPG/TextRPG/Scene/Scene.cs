using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scene
{
    internal abstract class Scene
    {
        protected string sceneName;
        protected string sceneDescription;

        /// <summary>
        /// 장면을 보여주는 메소드
        /// 장면을 스택 구조를 활용해 구현하기 위해 Action으로 정의
        /// </summary>
        public Action Show { get; }

        public Scene(string sceneName, string sceneDescription)
        {
            this.sceneName = sceneName;
            this.sceneDescription = sceneDescription;
            Show = ShowScene;
        }

        /// <summary>
        /// 장면을 보여주는 메소드
        /// </summary>
        public abstract void ShowScene();
    }
}

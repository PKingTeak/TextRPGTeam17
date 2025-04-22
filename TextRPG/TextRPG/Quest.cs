using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Quest
    {
        public int QuestID { get;private set; } //퀘스트 ID
        string questTitle; //퀘스트 제목
        string questContent; //퀘스트 내용
        public string questTarget { get; private set; } //퀘스트 조건
        string questAction; //퀘스트 행동
        string questReward; //퀘스트 보상
        public int minCount { get; private set; } //수집 수
        public int maxCount { get; private set; } //목표 조건 수
        public  Quest(int id=0 ,string title = "제목", string content = "퀘스트내용", string target = "목표물",int maxcount=0,string action="", string reward = "보상") //퀘스트 화면
        {
            QuestID = id;
            questContent = content;
            questTarget = target;
             maxCount= maxcount;
            questAction = action;
            questTitle = title;
            questReward = reward;
        }

        public void QuestInfo() //퀘스트 정보
        {
            Console.WriteLine("Quest!!");
            Console.WriteLine(questTitle);
            Console.WriteLine(questContent);
            Console.WriteLine(questTarget);
            Console.WriteLine(questAction);
            Console.WriteLine($"{minCount}/{maxCount}");
            Console.WriteLine(questReward);
        }

        public void Count() //퀘스트 수집 수
        {
            this.minCount++;
        }
    }
}

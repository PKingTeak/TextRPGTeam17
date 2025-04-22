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
        string questCondition; //퀘스트 조건
        string questReward; //퀘스트 보상
        int minCount; //수집 수
        int maxCount; //목표 조건 수
        public  Quest(int id=0 ,string title = "", string content = "", string condition = "", string reward = "") //퀘스트 화면
        {
            QuestID = id;
            questCondition = condition;
            questContent = content;
            questTitle = title;
            questReward = reward;
        }

        public void QuestInfo() //퀘스트 정보
        {
            Console.WriteLine("Quest!!");
            Console.WriteLine(questTitle);
            Console.WriteLine(questContent);
            Console.WriteLine(questCondition);
            Console.WriteLine($"{minCount}/{maxCount}");
            Console.WriteLine(questReward);
        }

        public void GetCount(int minCount, int maxCount) //퀘스트 수집 수
        {
            this.minCount = minCount;
            this.maxCount = maxCount;
        }
    }
}

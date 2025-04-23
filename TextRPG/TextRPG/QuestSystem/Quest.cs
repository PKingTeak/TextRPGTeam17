using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

namespace TextRPG.QuestSystem
{

    public class Quest
    {
        public int QuestID { get; private set; } //퀘스트 ID
        public string questTitle { get; private set; }  //퀘스트 제목
        string questContent; //퀘스트 내용
        public string questTarget { get; private set; } //퀘스트 조건
        string questAction; //퀘스트 행동
        string questReward; //퀘스트 보상
        public int minCount { get; private set; } //수집 수
        public int maxCount { get; private set; } //목표 조건 수
        public bool isAccepted { get; private set; } = false;//퀘스트 수락 여부
        public bool isComplete { get; private set; } = false;//퀘스트 완료 여부
        public bool isRewardGet { get; private set; } = false;//퀘스트 보상 전달 여부
        public Quest(int id = 0, string title = "제목", string content = "퀘스트내용", string target = "목표물", int maxcount = 0, string action = "", string reward = "보상") //퀘스트 화면
        {
            QuestID = id;
            questContent = content;
            questTarget = target;
            maxCount = maxcount;
            questAction = action;
            questTitle = title;
            questReward = reward;
        }

        public void QuestInfo() //퀘스트 정보
        {
            Console.WriteLine("Quest!!\n");
            Console.WriteLine(questTitle+"\n");
            Console.WriteLine(questContent + "\n");
            Console.Write($"- {questTarget} {maxCount}{questAction}");
            Console.WriteLine($" {minCount}/{maxCount}\n");
            Console.WriteLine($"- 보상-\n");
            Console.WriteLine($"{ questReward}\n");
        }

        public void Count() //퀘스트 수집 수
        {
            this.minCount++;
        }

        public void Accept() //퀘스트 수락
        {
            isAccepted = true;
        }

        public void Complete()//퀘스트 완료
        {
            isComplete = true;
        }
        public void RewardGet()//퀘스트 보상 전달
        {
            isRewardGet = true;
        }
    }
}


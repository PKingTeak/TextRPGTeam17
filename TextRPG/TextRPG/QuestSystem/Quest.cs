using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Unit.Child;

namespace TextRPG.QuestSystem
{
    public enum QuestType { Noraml, Repeat };
    public class Quest
    {
        //퀘스트 정보,변수값
        public QuestType questType { get; private set; }
        public int QuestID { get; private set; } //퀘스트 ID
        public string questTitle { get; private set; }  //퀘스트 제목
        string questContent; //퀘스트 내용
        public string questTarget { get; private set; } //퀘스트 조건
        string questAction; //퀘스트 행동
        public int minCount { get; private set; } //수집 수
        public int maxCount { get; private set; } //목표 조건 수
        public Reward questReward { get; } // 퀘스트 보상

        //퀘스트 상태
        public bool isAccepted { get; private set; } = false;//퀘스트 수락 여부
        public bool isComplete { get; private set; } = false;//퀘스트 완료 여부
        public bool isRewardGet { get; private set; } = false;//퀘스트 보상 전달 여부
        public Quest(QuestType questType, Reward questReward, int id = 0, string title = "제목", string content = "퀘스트내용", string target = "목표물", int maxcount = 0, string action = "") //퀘스트 화면
        {
            this.questType = questType;
            this.questReward = questReward;
            QuestID = id;
            questContent = content;
            questTarget = target;
            maxCount = maxcount;
            questAction = action;
            questTitle = title;
        }

        public void ChangeMonsterQuestInfo(string monsterName)
        {
            questTitle = $"마을을 위협하는 {monsterName} 처치";
            questContent = $"이봐! 마을 근처에 {monsterName}들이 너무 많아졌다고 생각하지 않나?\r\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\r\n모험가인 자네가 좀 처치해주게!";
            questTarget = monsterName;
        }

        public void QuestInfo() //퀘스트 정보
        {
            Console.WriteLine($"\u001b[38;2;255;255;131mQuest!!\u001b[0m - {(questType == QuestType.Noraml ? "일반 퀘스트" : "반복퀘스트")}\n");
            Console.WriteLine(questTitle + "\n");
            Console.WriteLine(questContent + "\n");
            Console.Write($"- {questTarget} {maxCount}{questAction}");
            Console.WriteLine($" {minCount}/{maxCount}\n");
            Console.WriteLine($"- 보상 -");
            Console.WriteLine($"{questReward.Gold} Gold");
            if (questReward.item != null)
                Console.WriteLine($"{questReward.item.Name} x 1");

            Console.WriteLine();
        }

        public void Count() //퀘스트 목표 도달치 증가
        {
            this.minCount++;

            if (minCount >= maxCount)
            {
                minCount = maxCount;
                Complete();
                Console.WriteLine($"{questTitle} 퀘스트 완료!!!!");
            }
        }

        public void Accept() //퀘스트 수락
        {
            isAccepted = true;
        }
        public void ResetQuest() // 퀘스트 초기화
        {
            isComplete = false;
            isAccepted = false;
            isRewardGet = false;
            minCount = 0;
        }

        private void Complete()//퀘스트 완료
        {
            isComplete = true;
        }
        public void RewardGet()//퀘스트 보상 전달
        {
            isRewardGet = true;


        }

        public void ChangeTarget(string target)
        {
            questTarget = target;
        }
    }
}
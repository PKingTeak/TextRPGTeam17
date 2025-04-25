using System;
using System.Diagnostics;
using TextRPG.Unit;
using TextRPG.Unit.Child;


namespace TextRPG.QuestSystem
{
    public class QuestManager
    {
        List<Quest> questList = new List<Quest>(); //퀘스트 묶음,퀘스트의 수가 100개 이상이라면 딕셔너리로 바꿔야함
        ItemManager itemManager;
        Player player;
        public QuestManager(ItemManager itemManager, Player player)
        {
            this.itemManager = itemManager;
            this.player = player;
        }

        public void InitQuest(string monsterName)
        {
            SetQuest(QuestType.Repeat, new Reward(1000),10001, $"마을을 위협하는 {monsterName} 처치", $"이봐! 마을 근처에 {monsterName}들이 너무 많아졌다고 생각하지 않나?\r\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\r\n모험가인 자네가 좀 처치해주게!", monsterName, 1, "마리 처치하기");
            SetQuest(QuestType.Noraml, new Reward(300, itemManager.Items[itemManager.Items.Count - 1]),10002, "장비를 장착해보자", "모험을 떠나기 전엔 기본 장비부터 챙기는 게 좋지 않겠어?\r\n몸을 보호하려면 방어구 하나쯤은 필요하고, 적을 상대하려면 무기도 있어야 하니까 말이야.\r\n인벤토리를 열고 아무 장비나 하나 장착해봐!\r\n별거 아닐 것 같아도, 그게 모험의 시작이니까!", "장비", 1, "개 장착하기");
            SetQuest(QuestType.Repeat, new Reward(500),10003, "더욱 더 강해지기!", "모험가라면 레벨을 올리는 건 기본이지!\r\n레벨이 올라가면 능력치도 올라가고, 새로운 스킬도 배울 수 있어!\r\n레벨을 올리기 위해선 몬스터를 처치하고 경험치를 얻어야 해.\r\n그럼 자네의 모험이 시작되는 거야!", "레벨", 1, " 이상 올리기");
        }

        #region 몬스터 퀘스트 이벤트
        //하나의 기능
        public void Subscribe(Monster unit)//몬스터가 구독해서 HandleMonsterKilled()를 쓸 수 있게 해줌
        {
            unit.OnMonsterDead += HandleMonsterDead;
        }
        private void HandleMonsterDead(string name) //몬스터에게서 OnMonsterKilled?.Invoke();될 때 마다 호출
        {
            foreach (var quest in questList) //퀘스트 리스트를 돌면서
            {
                if (quest.questTarget == name && quest.isAccepted)//퀘스트를 수락한 상태가 아니라면 카운트 되지않음
                    quest.Count(); //퀘스트의 수집 수 증가
            }

        }
        //하나의 기능
        #endregion
        #region 플레이어 퀘스트 이벤트
        public void Subscribe(Player player)//몬스터가 구독해서 HandleMonsterKilled()를 쓸 수 있게 해줌
        {
            player.OnPlayerChange += HandlePlayerChange;
        }
        private void HandlePlayerChange(string title) //몬스터에게서 OnMonsterKilled?.Invoke();될 때 마다 호출
        {
            foreach (var quest in questList) //퀘스트 리스트를 돌면서
            {
                if (quest.questTitle == title && quest.isAccepted)//퀘스트를 수락한 상태가 아니라면 카운트 되지않음
                    quest.Count(); //퀘스트의 수집 수 증가
            }
        }
        #endregion

        /// <summary>
        /// 퀘스트 화면
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="target"></param>
        /// <param name="maxcount"></param>
        /// <param name="action"></param>
        /// <param name="reward"></param>
        public void SetQuest(QuestType questType, Reward questReward, int id = 0, string title = "제목", string content = "퀘스트내용", string target = "목표물", int maxcount = 0, string action = "")
        {
            Quest quest = new Quest(questType, questReward, id, title, content, target, maxcount, action);
            questList.Add(quest);
        }


        // 퀘스트 리스트 반환
        public List<Quest> ReturnQuestList()
        {
            return questList;
        }

        public void GetQuest(Quest quest) //퀘스트 정보
        {
            quest.QuestInfo();
        }
        public void SetQuestAccept(Quest quest) //퀘스트 수락
        {
            quest.Accept();
        }

        public void ApplyReward(Reward reward)
        {
            player.state.Gold += reward.Gold;

            if(reward.item != null)
                reward.item.ChangeOwnership(true);
        }
    }
}
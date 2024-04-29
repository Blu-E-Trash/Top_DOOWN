using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int, QuestData> questList;
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    
    void GenerateData()
    {
        questList.Add(10, new QuestData("첫 동네 방문", /*int[]에는 해당 퀘스트에 연관된 NPC Id 입력*/new int[] {1000}));//(quest id, questData)
        questList.Add(20, new QuestData("ㅡ루ㅡ 찾기", new int[] { 2000 }));
        questList.Add(30, new QuestData("동전 찾기", new int[] { 2000 }));
        
    }
    public int GetQuestTalkIndex(int id)
    {
        return questId+questActionIndex;
    }
    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        if(questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
        return questList[questId].questName;
    }
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
}

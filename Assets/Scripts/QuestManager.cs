using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    
    void GenerateData()
    {
        questList.Add(10, new QuestData("첫 동네 방문", /*int[]에는 해당 퀘스트에 연관된 NPC Id 입력*/new int[] {1000, 2000}));//(quest id, questData)
        questList.Add(20, new QuestData("동전 찾기", new int[] { 5000, 2000 }));
        questList.Add(30, new QuestData("'동전 찾기' 클리어", new int[] { 0 }));

    }
    public int GetQuestTalkIndex(int id)
    {
        return questId+questActionIndex;
    }
    public string CheckQuest(int id)
    {
        //Next Talk Target
        if (id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }
        //Control QuestObject
        ControlObject();
        //Talk Complete & Next Quest
        if (questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
        //Quest Name
        return questList[questId].questName;
    }
    public string CheckQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if(questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if(questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}

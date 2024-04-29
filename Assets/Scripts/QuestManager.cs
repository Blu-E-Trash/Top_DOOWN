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
        questList.Add(10, new QuestData("ù ���� �湮", /*int[]���� �ش� ����Ʈ�� ������ NPC Id �Է�*/new int[] {1000}));//(quest id, questData)
        questList.Add(20, new QuestData("�ѷ�� ã��", new int[] { 2000 }));
        questList.Add(30, new QuestData("���� ã��", new int[] { 2000 }));
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int/*������ƮID*/, string[]/*��ȭ ����*/> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int , string[] >();
        portraitData = new Dictionary<int , Sprite>();
        GenerateData();
    }

    
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�:0", "ó������ ���̳�:1" });
        talkData.Add(2000, new string[] { "....:3", "...:3", "..��:2", "..����:3" });
        talkData.Add(100, new string[] { "���� �ڽ���", "Ư���� ���� �������ڴ�" });
        talkData.Add(300, new string[] { "���� ���̴�.", "�Ժη� ���� ����" });
        talkData.Add(200, new string[] { "���ϰ� ���� ���̴�.", "�׳�..���̴�" });
        talkData.Add(400, new string[] { "���� ���̺��̴�", "���� ���̺��̴�" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "�����:0", "÷���� ���̳�..:1", "�� �̾߱�� �ѷ�Ѷ�� ������� ����:1", "����ֳİ�?:2", "�ϰ� �˾Ƽ� ã��!!:3" });
        talkData.Add(11 + 2000, new string[] { "...:0", "...:0", "..����:1", "�װ�...�˰ھ�:0", "���� ������ ã����:1" });
        talkData.Add(20 + 5000, new string[] { "��ó���� ������ �ֿ���." });
        talkData.Add(20 + 2000, new string[] { "����:1", "�׷� �� ���:0" });

        portraitData.Add(1000 + 0, portraitArr[0]);//�⺻ 
        portraitData.Add(1000 + 1, portraitArr[1]);//���ϱ�
        portraitData.Add(1000 + 2, portraitArr[2]);//����
        portraitData.Add(1000 + 3, portraitArr[3]);//ȭ��
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
        
    }
    public string GetTalk(int id,int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {//�ش� ����Ʈ ���� ���� ��簡 ���� ��
            //����Ʈ ó�� ��� ������ �´�.
            
            if (!talkData.ContainsKey(id - id % 10))
            {
                //����Ʈ �� ó�� ��絵 ���� ��
                //�⺻ ��� ������ ��
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length) {
            return null;
         }
        else
            return talkData[id][talkIndex];
    }
    public Sprite GetPortrait(int id,int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
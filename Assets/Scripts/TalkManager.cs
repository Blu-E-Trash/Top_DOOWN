using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int/*오브젝트ID*/, string[]/*대화 내용*/> talkData;
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
        talkData.Add(1000, new string[] { "안녕:0", "처음보는 얼굴이네:1" });
        talkData.Add(2000, new string[] { "....:3", "...:3", "..뭐:2", "..뭘봐:3" });
        talkData.Add(100, new string[] { "그저 박스다", "특별함 없는 나무상자다" });
        talkData.Add(300, new string[] { "예쁜 집이다.", "함부로 들어가지 말자" });
        talkData.Add(200, new string[] { "묘하게 예쁜 돌이다.", "그냥..돌이다" });
        talkData.Add(400, new string[] { "나무 테이블이다", "예쁜 테이블이다" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "어서오쇼:0", "첨보는 얼굴이네..:1", "그 이야기는 ㅡ루ㅡ라는 사람에게 가봐:1", "어디있냐고?:2", "니가 알아서 찾아!!:3" });
        talkData.Add(11 + 2000, new string[] { "...:0", "...:0", "..뭘봐:1", "그건...알겠어:0", "먼저 동전좀 찾아줘:1" });
        talkData.Add(20 + 5000, new string[] { "근처에서 동전을 주웠다." });
        talkData.Add(20 + 2000, new string[] { "좋아:1", "그럼 잘 들어:0" });

        portraitData.Add(1000 + 0, portraitArr[0]);//기본 
        portraitData.Add(1000 + 1, portraitArr[1]);//말하기
        portraitData.Add(1000 + 2, portraitArr[2]);//웃음
        portraitData.Add(1000 + 3, portraitArr[3]);//화남
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
        
    }
    public string GetTalk(int id,int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {//해당 퀘스트 진행 순서 대사가 없을 때
            //퀘스트 처음 대사 가지고 온다.
            
            if (!talkData.ContainsKey(id - id % 10))
            {
                //퀘스트 맨 처음 대사도 없을 때
                //기본 대사 가지고 옴
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
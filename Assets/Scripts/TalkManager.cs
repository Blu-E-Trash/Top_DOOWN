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
        talkData.Add(2000, new string[] { "....:3", "...:3", "..뭐:3", "..뭘봐:3" });
        talkData.Add(100, new string[] { "그저 박스다", "특별함 없는 나무상자다" });
        talkData.Add(300, new string[] { "예쁜 집이다.", "함부로 들어가지 말자" });
        talkData.Add(200, new string[] { "묘하게 예쁜 돌이다.", "그냥..돌이다" });
        talkData.Add(400, new string[] { "나무 테이블이다", "예쁜 테이블이다" });

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
        if(talkIndex == talkData[id].Length) {
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
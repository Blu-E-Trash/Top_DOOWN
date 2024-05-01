using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;
    public int CPS;//Charater Per Sec
    Text msgText;
    int index;
    public GameObject EndCursor;
    float interval;
    AudioSource audioSource;
    public bool isAnim;

    public void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    
    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);
        //시간차 반복 호출을 위한 Invoke함수 사용 -> 타이핑 속도
        interval = (1.0f / CPS);
        isAnim = true;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        
        //Sound
        if(targetMsg[index]!=' '|| targetMsg[index]!='.')
            audioSource.Play();

        index++;
        Invoke("Effecting", interval);
    }
    void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}

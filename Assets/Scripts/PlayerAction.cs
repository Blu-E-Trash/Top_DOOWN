using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    public GameManager manager;

    float h;
    float v;
    bool isHorizonMove;
    //현재 바라보고 있는 방향 값을 가진 변수
    Vector2 dirVec;

    GameObject scanObject;

    Animator anim;
    Rigidbody2D rigid;

    //Mobile key Val
    int up_Value;
    int right_Value;
    int down_Value;
    int left_Value;
    bool up_Down;
    bool right_Down;
    bool left_Down;
    bool down_Down;
    bool up_Up;
    bool right_Up;
    bool left_Up;
    bool down_Up;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame 
    void Update()
    {
        //Move Value
        //PC
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        //Moblie
        h = manager.isAction ? 0 : right_Value+left_Value;
        v = manager.isAction ? 0 : down_Value+up_Value;
        //Moblie + PC
        // h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal")+right_Value+left_Value;
        // v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical")+down_Value+up_Value;

        //Check Botton Down & Up 
        //PC+Moblie
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal")|| right_Down || left_Down;
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical")|| up_Down || down_Down;
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal")|| right_Up || left_Up;
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical")||up_Up || down_Up;

        //Check Horizontal Move
        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;

        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

        //Direction
        if (vDown && v == 1)
            dirVec = Vector2.up;
        else if (vDown && v == -1)
            dirVec = Vector2.down;
        else if (hDown && h == -1)
            dirVec = Vector2.left;
        else if (hDown && h == 1)
            dirVec = Vector2.right;

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);

        //Moblie Var Init
        up_Down= false;
        right_Down = false;
        left_Down = false;
        down_Down = false;
        up_Up = false;
        right_Up = false;
        left_Up = false;
        down_Up = false;
    }
    void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) :
            new Vector2(0, v);
        rigid.velocity = moveVec * 4;
        


        //Ray
        Debug.DrawRay(transform.position, dirVec*0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f,LayerMask.GetMask("object"));
 
        if(rayHit.collider != null) {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 1;
                up_Down = true;
                break;
            case "R":
                right_Value = 1;
                right_Down = true;
                break;
            case "D":
                down_Value = -1;
                down_Down = true; 
                break;
            case "L":
                left_Value = -1;
                left_Down = true;
                break;
            case "A":
                if (scanObject != null)
                    manager.Action(scanObject);
                break;
            case "C":
                manager.SubMenuActive();
                break;
        }
    }
    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 0;
                up_Up = true;
                break;
            case "R":
                right_Value = 0;
                right_Up = true;
                break;
            case "D":
                down_Value = 0;
                down_Up = true;
                break;
            case "L":
                left_Value = 0;
                left_Up = true;
                break;
         }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchJumpKey : MonoBehaviour
{
    public bool isJump;
    public bool ableJump;

    private Transform jumpKey;
    private Image jumpKeyImage;
    private Color originalColor;
    private PlayerController myPlayer;
    
    //private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        jumpKey = GetComponent<RectTransform>();
        jumpKeyImage = GetComponent<Image>();
        myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        originalColor = jumpKeyImage.color;
        isJump = false;
        ableJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //判断是否触碰到跳跃键
        if (Input.mousePosition.y >= jumpKey.transform.position.y - 50.0f && Input.touchCount == 1) //打包正式用这个
        //if (Input.mousePosition.y >= jumpKey.transform.position.y - 50.0f) //电脑测试用这个
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
        //控制恢复可以跳跃状态的区域
        if(Input.mousePosition.y <= jumpKey.transform.position.y - 120.0f)
        {
            ableJump = true;
        }


        //控制按键的颜色
        if (ableJump == true)
        {
            jumpKeyImage.color = originalColor; //可跳跃时为默认颜色
        }
        else
        {
            //jumpKeyImage.color = Color.yellow; //不可跳跃时为红色
            jumpKeyImage.color = new Color(originalColor.r,originalColor.g,originalColor.b,0.1f); //不可跳跃时为透明色
        }


        //if (Input.mousePosition.x <= jumpKey.transform.position.x+150.0f && Input.mousePosition.x >= jumpKey.transform.position.x - 150.0f)
        //{
        //    if (Input.mousePosition.y >= jumpKey.transform.position.y - 50.0f)
        //    {
        //        isJump = true;
        //    }
        //    else 
        //    { 
        //        isJump = false;
        //        ableJump = true;
        //    }
        //}
        //else
        //{
        //    isJump = false;
        //    ableJump = true;
        //}

    }
    
   
}

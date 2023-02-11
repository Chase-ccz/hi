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
        //�ж��Ƿ�������Ծ��
        if (Input.mousePosition.y >= jumpKey.transform.position.y - 50.0f && Input.touchCount == 1) //�����ʽ�����
        //if (Input.mousePosition.y >= jumpKey.transform.position.y - 50.0f) //���Բ��������
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
        //���ƻָ�������Ծ״̬������
        if(Input.mousePosition.y <= jumpKey.transform.position.y - 120.0f)
        {
            ableJump = true;
        }


        //���ư�������ɫ
        if (ableJump == true)
        {
            jumpKeyImage.color = originalColor; //����ԾʱΪĬ����ɫ
        }
        else
        {
            //jumpKeyImage.color = Color.yellow; //������ԾʱΪ��ɫ
            jumpKeyImage.color = new Color(originalColor.r,originalColor.g,originalColor.b,0.1f); //������ԾʱΪ͸��ɫ
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

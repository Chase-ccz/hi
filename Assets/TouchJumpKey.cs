using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJumpKey : MonoBehaviour
{

    private Transform jumpKey;
    private bool isJump;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        jumpKey = GetComponent<RectTransform>();
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(IsTouchInUi(Input.mousePosition) ? "�ڵ�ͼ��" : "��������");//���
        //if (Input.touchCount > 0)
        //    //Debug.Log(IsTouchInUi(Input.GetTouch(0).deltaPosition) ? "�ڵ�ͼ��" : "��������");//����
        //if (IsTouchInUi(Input.GetTouch(0).deltaPosition) == false)
        //{
        //    //��ָ�����ƶ�
        //    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {
        //        Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        //        _map.Translate(touchDeltaPosition.x * 5, -touchDeltaPosition.y * 5, 0);
        //    }
        //}
        Debug.Log(Input.mousePosition);
        Debug.Log(jumpKey.transform.position);

        //Vector2 jumpKeyLeftDownPos = new Vector2(jumpKey.transform.position.x + 10);
        if(Input.mousePosition.x <= jumpKey.transform.position.x+50.0f && Input.mousePosition.x >= jumpKey.transform.position.x - 50.0f)
        {
            if (Input.mousePosition.y <= jumpKey.transform.position.y + 50.0f && Input.mousePosition.y >= jumpKey.transform.position.y - 50.0f)
            {
                isJump = true;
            }
            else isJump = false;
        }
        else isJump = false;
        Debug.Log(isJump);
        if(isJump == true)
        {
            player.Jump();
        }
    }
    
   
}

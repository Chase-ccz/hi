using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLeftSkillKey : MonoBehaviour
{

    private Transform leftSkillKey;
    public bool isLeftSkill;
    //private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        leftSkillKey = GetComponent<RectTransform>();
        isLeftSkill = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.mousePosition.x <= leftSkillKey.transform.position.x + 50.0f && Input.mousePosition.x >= leftSkillKey.transform.position.x - 50.0f)
        //{
        //    if (Input.mousePosition.y <= leftSkillKey.transform.position.y + 50.0f && Input.mousePosition.y >= leftSkillKey.transform.position.y - 50.0f)
        //    {
        //        isLeftSkill = true;
        //    }
        //    else isLeftSkill = false;
        //}
        //else isLeftSkill = false;

        if(Input.GetTouch(1).phase == TouchPhase.Ended)
        {
            if (Input.GetTouch(1).position.x <= leftSkillKey.transform.position.x + 80.0f && Input.GetTouch(1).position.x >= leftSkillKey.transform.position.x - 80.0f)
            {
                if (Input.GetTouch(1).position.y <= leftSkillKey.transform.position.y + 80.0f && Input.GetTouch(1).position.y >= leftSkillKey.transform.position.y - 80.0f)
                {
                    isLeftSkill = true;
                }
                else isLeftSkill = false;
            }
        }
        
    }



}

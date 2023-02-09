using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRightSkillKey : MonoBehaviour
{
    private Transform rightSkillKey;
    //public bool isRightSkill;
    private WeaponStateChange weaponSwitch;
    //private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        weaponSwitch = GameObject.FindGameObjectWithTag("WeaponState").GetComponent<WeaponStateChange>();
        rightSkillKey = GetComponent<RectTransform>();
        //isRightSkill = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.mousePosition.x <= rightSkillKey.transform.position.x + 75.0f && Input.mousePosition.x >= rightSkillKey.transform.position.x - 75.0f)
        {
            if (Input.mousePosition.y <= rightSkillKey.transform.position.y + 50.0f && Input.mousePosition.y >= rightSkillKey.transform.position.y - 50.0f)
            {
                weaponSwitch.Switcher();
            }
        }
    }
}

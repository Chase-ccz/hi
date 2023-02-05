using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    public float waitTime;
    

    private BoxCollider2D collider2D;
    private Animator anim;
    private WeaponStateChange weaponState;
    private float timer;
    private Collider2D enemyInRange;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        weaponState = GameObject.FindGameObjectWithTag("WeaponState").GetComponent<WeaponStateChange>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && weaponState.weaponType == "melee")
        {
            //StartCoroutine(Attack());
            anim.SetTrigger("Attack");
        }
    }


    //IEnumerator Attack()
    //{
    //    anim.SetTrigger("Attack");
    //    yield return new WaitForSeconds(waitTime);
    //}
}

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
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        weaponState = GameObject.FindGameObjectWithTag("WeaponState").GetComponent<WeaponStateChange>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && weaponState.weaponType == "melee")
        {
            if(playerHealth.health > 0)
            {
                anim.SetTrigger("Attack");
                StartCoroutine(Attack());
            }
            
        }
    }


    IEnumerator Attack()
    {
        collider2D.enabled = false;
        yield return new WaitForSeconds(waitTime);
        collider2D.enabled = true;
    }
}

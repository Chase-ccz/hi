using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoRangeAttack : MonoBehaviour
{
    public GameObject bullet;

    private WeaponStateChange weaponState;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        weaponState = GameObject.FindGameObjectWithTag("WeaponState").GetComponent<WeaponStateChange>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(bullet, playerPos, Quaternion.identity);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && weaponState.weaponType == "range")
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                Shoot();
            }
            //StartCoroutine(Attack());
            //Shoot();
        }
    }
}

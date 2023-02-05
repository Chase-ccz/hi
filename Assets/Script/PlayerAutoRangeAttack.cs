using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoRangeAttack : MonoBehaviour
{
    public GameObject bullet;
    public float shootFreq;

    private WeaponStateChange weaponState;
    private float timer;
    private BoxCollider2D myBoxCollider;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        weaponState = GameObject.FindGameObjectWithTag("WeaponState").GetComponent<WeaponStateChange>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

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
        if (other.gameObject.CompareTag("Enemy") && weaponState.weaponType == "range" )
        {
            if(playerHealth.health > 0)
            {
                Shoot();

                StartCoroutine(ShootFreq());
            }
            
        }
    }

    IEnumerator ShootFreq()
    {
        myBoxCollider.enabled = false;
        yield return new WaitForSeconds(shootFreq);
        myBoxCollider.enabled = true;
    }
}

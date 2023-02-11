using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetShoot : MonoBehaviour
{
    public GameObject bullet;
    public float shootFreq;

    private float timer;
    private BoxCollider2D myBoxCollider;
    private Transform player;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Vector3 helmetPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(bullet, helmetPos, Quaternion.identity);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Shoot();
            StartCoroutine(ShootFreq());
        }
    }

    IEnumerator ShootFreq()
    {
        myBoxCollider.enabled = false;
        yield return new WaitForSeconds(shootFreq);
        myBoxCollider.enabled = true;
    }
}

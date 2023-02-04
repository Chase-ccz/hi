using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Collider2D enemyInRange;
    private Rigidbody2D rb;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyInRange = Physics2D.OverlapCircle(transform.position, 100.0f, 9);

        Vector3 direction = enemyInRange.transform.position - transform.position;
        Debug.Log(enemyInRange.transform.position);
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

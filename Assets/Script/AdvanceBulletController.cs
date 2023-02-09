using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceBulletController : MonoBehaviour
{
    public float speed;

    //private float timer;
    new private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //Vector2 direction = new Vector2(1, 1);
        //rb.velocity = direction * speed;
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > 2)
        //{
        //    Destroy(gameObject);
        //}
    }

    
}

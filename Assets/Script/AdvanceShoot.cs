using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceShoot : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public int bulletNum;
    public float spread, speed;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(1, 1) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Shoot();
            timer = 0;
        }
        
        
    }


    void Shoot()
    {
        for (int i =0; i < bulletNum; i++)
        {
            GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
            brb.velocity = (dir + pdir) * speed;
        }
    }
}

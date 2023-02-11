using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelmet : Enemy
{
    public float speed;
    public float startWaitTime;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    private float waitTime;
    private int randomInt;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        //movePos.position = GetRandomPos();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        randomInt = Random.Range(0, 1);
        if (randomInt == 0)
        {
            movePos.position = leftDownPos.position;
        }
        else
        {
            movePos.position = rightUpPos.position;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        //调用父类Update的方法
        base.Update();
        

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        Flip();

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (movePos.position == rightUpPos.position)
                {
                    movePos.position = leftDownPos.position;
                }
                else
                {
                    movePos.position = rightUpPos.position;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void Flip()
    {
        if (movePos.position == rightUpPos.position)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (movePos.position == leftDownPos.position)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //Vector2 GetRandomPos()
    //{
    //    Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
    //    return rndPos;
    //}
}

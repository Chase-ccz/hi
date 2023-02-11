using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{
    public float speed;
    public float detectedSpeed;
    public float startWaitTime;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    private float waitTime;
    private PlayerHealth playerHealth;
    private Transform playerPos;
    private EnemyBatPlayerDetect enemyBatPlayerDetect;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyBatPlayerDetect = gameObject.GetComponentInChildren<EnemyBatPlayerDetect>();
    }

    // Update is called once per frame
    public void Update()
    {
        //调用父类Update的方法
        base.Update();

        if(enemyBatPlayerDetect.playerDetected == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, detectedSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }
    }
}

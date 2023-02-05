using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public int damage;

    private Rigidbody2D rb;
    private GameObject player;
    private Collider2D enemyInRange;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player");
        //enemyInRange = Physics2D.OverlapCircle(transform.position, 100.0f, 512);

        //Vector3 direction = enemyInRange.transform.position - transform.position;
        //Debug.Log(enemyInRange.transform.position);
        //rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        //---------------------------mindistance---------------------------------//

        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = OnGetEnemy().position - transform.position;
        Debug.Log(OnGetEnemy().position);
        Debug.Log(transform.position);
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            Destroy(gameObject);
        }
    }

    public Transform OnGetEnemy()
    {
        //��ȡ���е���
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        float distance_min = 10000;    //�����������������
        float distance = 0;            //��ǰ���������ǵľ���
        int id = 0;                    //����������Ĺ���ı��
        //�������е���,������벢�Ƚ�
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].activeSelf == true)
            {
                distance = Vector3.Distance(transform.position, enemy[i].transform.position);
                if (distance < distance_min)
                {
                    //�ҵ�һ��������
                    distance_min = distance;
                    id = i;
                }
            }
        }
        return enemy[id].transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        {

        }
    }
}

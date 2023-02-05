using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spike : MonoBehaviour
{
    public int damage;
    public float hitFreq;

    private PlayerHealth playerHealth;
    private TilemapCollider2D myTileCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        myTileCollider = GetComponent<TilemapCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if(playerHealth.health > 0)
            {
                playerHealth.DamagePlayer(damage);
                StartCoroutine(HitFreq());
            }
            
        }

        IEnumerator HitFreq()
        {
            myTileCollider.enabled = false;
            yield return new WaitForSeconds(hitFreq);
            myTileCollider.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float flashTime;
    public GameObject bloodEffect;

    private SpriteRenderer sr;
    private Color originalColor;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        GameController.camShake.Shake();
    }

    public void FlashColor(float flashTime)
    {
        sr.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    public void ResetColor()
    {
        sr.color = originalColor;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
        
    //    if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
    //    {
    //        if(playerHealth != null)
    //        {
    //            playerHealth.DamagePlayer(damage);
    //        }
    //    }
    //}
}

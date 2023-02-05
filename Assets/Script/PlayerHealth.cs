using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int blink;
    public float time;
    public float dieTime;

    private Renderer myRender;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;
        if(health < 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        
        if(health <= 0)
        {
            anim.SetTrigger("Die");
            Invoke("KillPlayer", dieTime);
        }
        BlinkPlayer(blink, time);
    }

    void KillPlayer()
    {
        Destroy(gameObject);
    }

    void BlinkPlayer(int numBlink, float seconds)
    {
        StartCoroutine(DoBlinks(numBlink,seconds));
    }

    IEnumerator DoBlinks(int numBlink, float seconds)
    {
        for(int i =0; i  <numBlink * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}

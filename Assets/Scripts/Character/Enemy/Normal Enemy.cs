using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public GameObject deathEffect;
    AudioSource enemyAudio;
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        damage = 20;
    }

    
    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Bullet bullet = coll.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                Debug.Log("enemy is hit by the player bullet");
                base.ReceiveDamage(bullet.damage);
            }
        }
    }

    protected override void Die() {
        base.signalDeath();
        Debug.Log("Enemy died.");
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }

    public override void Test() {
        Debug.Log("Test");  
    }

}

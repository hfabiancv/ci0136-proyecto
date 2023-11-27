using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Character
{
    public GameObject deathEffect;
    AudioSource bossAudio;
    // Start is called before the first frame update
    void Start()
    {
        health = 2000;
        damage = 200;
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
        Debug.Log("Boss died.");
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }

}

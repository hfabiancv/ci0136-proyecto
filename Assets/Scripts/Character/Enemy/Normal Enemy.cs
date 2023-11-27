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
        health = 1000;
        damage = 45;
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
                // Transform playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();; 
                // float teleportDistance = 5f; 
                // Vector2 randomPosition = playerTransform.position + UnityEngine.Random.Range(0, 4)* teleportDistance;
                // randomPosition.y = transform.position.y;
                // transform.position = randomPosition;
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

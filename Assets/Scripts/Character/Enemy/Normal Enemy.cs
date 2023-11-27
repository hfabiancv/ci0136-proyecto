using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public GameObject deathEffect;
    private Material matDefault;
    private Material matWhite;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
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
                ReceiveDamage(bullet.GetDamage());
                // flash the enemy
                sr.material = matWhite;
                if (health <= 0)
                {
                    Die();
                }
                else
                {
                    Invoke("ResetMaterial", .1f);
                }
            }
        }
    }

    protected override void ReceiveDamage(int damage)
    {
        health -= damage;
        // Debug.Log("Enemy received damage. Health: " + health);
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
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

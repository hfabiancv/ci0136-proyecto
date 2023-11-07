using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 10;
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Enemy OnTriggerEnter2D");
        if (coll.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy hit by bullet");
            base.ReceiveDamage(damage);
        }
    }
}

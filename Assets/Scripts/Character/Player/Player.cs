using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 10;
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Player OnTriggerStay2D");
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit by bullet");
            base.ReceiveDamage(damage);
        }
    }
}

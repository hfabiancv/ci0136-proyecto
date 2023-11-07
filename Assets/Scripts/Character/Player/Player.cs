using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        // melee damage
        damage = 10;
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Enemy enemy = coll.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("Player is hit by the enemy");
                base.ReceiveDamage(enemy.damage);
            }
        }
    }

}

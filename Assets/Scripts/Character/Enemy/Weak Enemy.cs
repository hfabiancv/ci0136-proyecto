using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 10;
        id = "Weak";
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

}

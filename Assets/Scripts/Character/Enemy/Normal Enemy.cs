using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        damage = 20;
        id = "Normal";
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperiorEnemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        health = 400;
        damage = 40;
        id = "Superior";
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

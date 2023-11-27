using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        // melee damage
        damage = 10;
        animator = GetComponent<Animator>();
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Character enemy = coll.gameObject.GetComponent<Character>();
            if (enemy != null)
            {
                animator.SetTrigger("Hit");
                Debug.Log("Player is hit by the enemy");
                base.ReceiveDamage(enemy.damage);
            }
        }

        if (coll.gameObject.tag == "EnemyBullet")
        {
            Bullet bullet = coll.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                animator.SetTrigger("Hit");
                Debug.Log("Player is hit by the enemy bullet");
                base.ReceiveDamage(bullet.GetDamage());
            }
        }
    }
}

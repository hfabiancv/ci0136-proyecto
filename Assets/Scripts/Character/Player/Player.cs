using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Animator animator;
    private SpriteRenderer spriteRender;

    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        health = 100;
        damage = 10;
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
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
                StartCoroutine(Invulnerability());
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
                StartCoroutine(Invulnerability());
            }
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRender.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}

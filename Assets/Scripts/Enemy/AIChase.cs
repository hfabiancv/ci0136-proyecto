using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    // enemy health
    public int health = 100;
    // distance to player
    private float distanceToPlayer;

    void Start()
    {

    }


    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        checkDeath();
    }

    // check if enemy is hit by player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // if player is hit by enemy
            Debug.Log("Enemy is hit by the player");
            health -= 10;
        }
    }

    // check health
    private void checkDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

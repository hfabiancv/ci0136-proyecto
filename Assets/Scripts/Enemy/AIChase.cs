using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    // enemy health
    public int health = 100;

    private float distanceToPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // check if enemy is dead
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // check if enemy is hit by player
    void OnTriggerEnter2D(Collider2D other)
    {
        // if enemy is hit by bullet
        health -= 10;
    }
}

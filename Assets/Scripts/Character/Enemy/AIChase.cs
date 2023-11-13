using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public float speed;
    // distance to player
    private float distanceToPlayer;

    public Animator animator;

    private Transform target;

    private float x;
    private float y;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        animator.SetBool("isMoving", true);
        // get x and y values
        x = target.position.x - transform.position.x;
        y = target.position.y - transform.position.y;

        // flip sprite
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

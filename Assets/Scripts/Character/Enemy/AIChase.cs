using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public float speed;
    public float obstacleDetectionRange = 1f; // adjust the range based on your needs
    public LayerMask obstacleLayer; // set the layer for obstacles in the Inspector

    private Transform target;
    private Animator animator;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            // Check for obstacles in the path
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, obstacleDetectionRange, obstacleLayer);

            if (hit.collider != null)
            {
                // Obstacle detected, calculate a new direction to move around the obstacle
                Vector2 avoidanceDirection = Vector2.Perpendicular(direction).normalized;
                transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)avoidanceDirection, speed * Time.deltaTime);
            }
            else
            {
                // No obstacle, continue chasing the player
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            animator.SetBool("isMoving", true);

            // Flip sprite
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}

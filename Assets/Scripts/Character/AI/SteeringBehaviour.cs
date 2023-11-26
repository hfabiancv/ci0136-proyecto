using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{
    public float followSpeed;
    public float slowDownDistance;

    Vector2 velocity;

    public float avoidanceDistance; // New parameter for obstacle avoidance
    public LayerMask obstacleLayerMask;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", true);
        Vector2 targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 playerDistance = targetPos - (Vector2)transform.position;
        
        Vector2 desiredVelocity = playerDistance.normalized * followSpeed;
        Vector2 steering = desiredVelocity - velocity;

        velocity += steering * Time.deltaTime;
        float slowDownFactor = Mathf.Clamp(playerDistance.magnitude / slowDownDistance, 0, 1);
        velocity *= slowDownFactor;

        transform.position += (Vector3)velocity * Time.deltaTime;

        float x = targetPos.x - transform.position.x;
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        Debug.DrawLine(transform.position, transform.position + (Vector3)velocity, Color.red);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, slowDownDistance);
    }

    Vector2 AvoidObstacles()
    {
        Vector2 forward = transform.up;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, forward, avoidanceDistance, obstacleLayerMask);

        if (hit.collider != null)
        {
            // Calculate avoidance force based on the obstacle position and distance
            Vector2 avoidanceDirection = (Vector2)transform.position - hit.point;
            return avoidanceDirection.normalized;
        }

        return Vector2.zero;
    }
}

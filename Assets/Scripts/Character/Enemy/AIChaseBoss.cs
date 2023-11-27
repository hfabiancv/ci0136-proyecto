using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIChaseBoss : MonoBehaviour
{
    public float speed;
    public float obstacleDetectionRange = 1f; // adjust the range based on your needs
    public LayerMask obstacleLayer; // set the layer for obstacles in the Inspector
    private bool sound;
    private Transform target;
    private Animator animator;
    [SerializeField] private AudioClip enemyAudio;
    public Transform spawner;
    // List<Transform> spawners;
    public GameObject bulletPrefab;
    public GameObject bullet;
    public GameObject spawnedBullet;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sound = false;
        // spawners = new List<Transform>();
        // InvokeRepeating("shoot", 0f, 2f);
    }

    private void Update()
    {
        //shoot();
        // StartCoroutine(getSound());
        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        // Check for obstacles in the path
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, obstacleDetectionRange, obstacleLayer);

        if (hit.collider != null)
        {
            // Obstacle detected, calculate a new direction to move around the obstacle
            Vector2 avoidanceDirection = Vector2.Perpendicular(direction).normalized;
            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3) avoidanceDirection, speed * Time.deltaTime);
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

    // public IEnumerator getSound() {
    //     float angle = 0f;
    //     float counter = 0;
    //     if (sound == false) {
    //         while (true) {
    //             sound = true;
    //             SoundController.instance.ExecuteSound(enemyAudio); 
    //             // float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * counter)* Mathf.PI)/180f);
    //             // float bulDirY = transform.position.x + Mathf.Sin(((angle + 180f * counter)* Mathf.PI)/180f);
    //             // Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
    //             // Vector2 bulDir = (bulMoveVector - transform.position).normalized;
    //             // Transform enemyTransform = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
    //             // GameObject bullet = Instantiate(bulletPrefab, enemyTransform.position, enemyTransform.rotation);
    //             // bullet.transform.position = transform.position;
    //             // bullet.transform.rotation = transform.rotation;
    //             // bullet.setActive(true);
    //             // bullet.GetComponent<Bullet>().SetMoveDirection(bulDir);
    //             //GameObject bullet = Instantiate(bulletPrefab, spawner.position, transform.rotation);

    //             //Destroy(bullet, 2f);
    //             ++counter;
    //             angle += 10f;
    //             if (angle >= 360f) {
    //                 angle = 0f;
    //             }
    //             yield return new WaitForSeconds(1);
    //         }

    //     }
    // }
    // public void shoot() {
    //     // for (int i = 0; i < )
    //     // Vector3 shootDirection = (target.position - spawner.position).normalized;
    //     // GameObject bullet = Instantiate(bulletPrefab, spawner.position, Quaternion.identity);
    //     // Destroy(bullet, 2f);
    //     if (bullet) {
    //         spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
    //         float bulletSpeed = speed + 0.5f;
    //         int damage = 30;
    //         spawnedBullet.GetComponent<Bullet>().speed = bulletSpeed;
    //         spawnedBullet.GetComponent<Bullet>().damage = damage;
    //         spawnedBullet.transform.rotation = transform.rotation;
    //         Destroy(spawnedBullet, 1f);
    //     }
    // }
}

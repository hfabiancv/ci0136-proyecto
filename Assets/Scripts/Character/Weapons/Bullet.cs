using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // bullet damage
    public int damage = 10;

    public GameObject impactEffect;

    // bullet speed
    public float speed = 1f;

    private Rigidbody2D rb2D;


    public float bulletLife = 1f; 


    // bullet rotation speed (degrees per second)
    public float rotationSpeed = 0f;
    private Vector2 spawnPoint;

    private float timer = 0f;
    


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spawnPoint = new Vector2(transform.position.x, transform.position.y);

        // Destroy the bullet after the specified bulletLife duration
        // Destroy(gameObject, bulletLife);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer) {
        // Moves right according to the bullet's rotation
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x+spawnPoint.x, y+spawnPoint.y);
    }



    // private void FixedUpdate()
    // {
    //     // Move bullet position
    //     rb2D.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);

    //     // Rotate the bullet based on rotationSpeed
    //     transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
    // }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // bullet speed
    public float speed = 5f;
    private new Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // destroy bullet when it hits something
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        // move bullet position
        rb2D.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }


}

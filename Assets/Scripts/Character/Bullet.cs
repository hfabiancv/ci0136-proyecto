using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // bullet damage
    public int damage = 10;
    public bool useImpactEffect;
    public GameObject impactEffect;

    // bullet speed
    public float speed = 5f;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        useImpactEffect = true;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // destroy bullet when it hits something
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (useImpactEffect == true) {
            GameObject effect = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        //}
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        // move bullet position
        rb2D.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }

}

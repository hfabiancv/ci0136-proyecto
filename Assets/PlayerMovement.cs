using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public Animator animator;
    public float moveSpeed;

    public float x, y;

    private bool isMoving;

    private Vector3 moveDir;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
            if (!isMoving)
            {
                animator.SetBool("isMoving", true);
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                animator.SetBool("isMoving", false);
                isMoving = false;
                StopMoving();
            }
        }
        moveDir = new Vector3(x, y).normalized;

        // flip the character
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = moveDir * moveSpeed * Time.deltaTime;
    }

    private void StopMoving()
    {
        rb2D.velocity = Vector2.zero;
    }
}

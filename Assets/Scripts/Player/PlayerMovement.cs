using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data.SqlClient;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Animator animator;
    // move speed
    public float moveSpeed;
    // player input
    public float x, y;
    // is the character moving?
    private bool isMoving;
    // move direction
    private Vector3 moveDir;
    // current state
    private PlayerState currentState;
    // player health
    public int health = 100;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ChangeState(new IdleState(this));
    }

    void Update()
    {
        // get player input
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        // update the current state
        currentState.Update();
        checkDeath();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = moveDir * moveSpeed * Time.deltaTime;
    }

    private void StopMoving()
    {
        // stop the character
        rb2D.velocity = Vector2.zero;
    }

    public void ChangeState(PlayerState newState)
    {
        // exit the current state
        if (currentState != null)
        {
            currentState.Exit();
        }
        // enter the new state
        currentState = newState;
        currentState.Enter();
    }

    public void MoveCharacter(float x, float y)
    {
        checkMovement();
        // set move direction
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

    void checkMovement()
    {
        // check if the character is moving
        if (x != 0 || y != 0)
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
            // set moving animation
            if (!isMoving)
            {
                animator.SetBool("isMoving", true);
                isMoving = true;
            }
        }
        else
        {
            // set idle animation
            if (isMoving)
            {
                animator.SetBool("isMoving", false);
                isMoving = false;
                StopMoving();
            }
        }
    }

    // create method to reduce health if player is in contact with enemy
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            Debug.Log("Player is being hit by enemy");
            health -= 5;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

    // check if player is deadd
    void checkDeath()
    {
        // if player is dead
        if (health <= 0)
        {
            // if player is dead
            Debug.Log("Player is dead");
            Destroy(gameObject);
        }
    }



}

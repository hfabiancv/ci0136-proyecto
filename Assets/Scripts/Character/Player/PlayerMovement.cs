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

    public new Camera camera;

    
    [Header("Sound Settings")]
    [SerializeField] private AudioClip stepSound;


    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashCooldown = 1f;
    bool isDashing;
    bool canDash;


    // [SerializeField] private float iFrameDuration;


    void Start()
    {
        isDashing = false;
        canDash = true;
        rb2D = GetComponent<Rigidbody2D>();
        ChangeState(new IdleState(this));
    }

    void Update()
    {
        if (!isDashing) {
            // get player input
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(KeyCode.Space) && canDash) {
                StartCoroutine(Dash());
            }

            // update the current state
            currentState.Update();


            // Get the position of the mouse cursor in the game world
            Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing) {
            rb2D.velocity = moveDir * moveSpeed * Time.deltaTime;
            // return;
        }
    }

    private IEnumerator Dash() {
        canDash = false;
        isDashing = true;
        rb2D.velocity = new Vector2(moveDir.x * dashSpeed, moveDir.y * dashSpeed);
        
        Physics2D.IgnoreLayerCollision(6, 7, true);
        Physics2D.IgnoreLayerCollision(7, 10, true);
        
        yield return new WaitForSeconds(dashDuration);
        
        Physics2D.IgnoreLayerCollision(6, 7, false);
        Physics2D.IgnoreLayerCollision(7, 10, false);
    
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
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

    // IEnumerator Sound()
    // {
    //     while (true) {
    //         SoundController.instance.ExecuteSound(stepSound);
    //         yield return new WaitForSeconds(0.5f);
    //         if (isMoving == false) {
    //             break;
    //         }
    //     }
        
    // }
}

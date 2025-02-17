using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    float speedX, speedY;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // reset
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveInput.y = Input.GetAxisRaw("Vertical") * moveSpeed;


        moveInput = moveInput.normalized;

        SetAnimations();
    }
    

    void FixedUpdate(){
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
   
    void SetAnimations(){
        animator.SetBool("WalkDown", false);
        animator.SetBool("WalkUp", false);
        animator.SetBool("WalkRight", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("Idle", false);

        // Determine which animation should play
        if (moveInput.y < 0)
        {
            animator.SetBool("WalkDown", true);
        }
        else if (moveInput.y > 0)
        {
            animator.SetBool("WalkUp", true);
        }
        else if (moveInput.x > 0)
        {
            animator.SetBool("WalkRight", true);
        }
        else if (moveInput.x < 0)
        {
            animator.SetBool("WalkLeft", true);
        }
        else
        {
            animator.SetBool("Idle", true);
        }
    }
    
    



}

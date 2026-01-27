using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float climbSpeed = 10f;

    Vector2 moveInput;
    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    CapsuleCollider2D bodyCollider;
    Animator animator;

    float baseGravity;
    bool isDead;

    // Animation
    bool isRunning;
    bool isClimbing;
    bool isFalling = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        baseGravity = rb.gravityScale;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        Climb();
        CheckAirState();
        AnimationTransition();
    }

    // Move
    void OnMove(InputValue value)
    {
        if(isDead) { return; }

        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed * Time.fixedDeltaTime, rb.linearVelocityY);
    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rb.linearVelocityX) > Mathf.Epsilon;
        isRunning = hasHorizontalSpeed;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocityX), transform.localScale.y);
        }
    }

    // Jump
    void OnJump(InputValue value)
    {
        if(isDead) { return; }
        
        if(!feetCollider.IsTouchingLayers(LayerMask.GetMask("Platform"))) { 
            return; 
        }

        if (value.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpSpeed * Time.fixedDeltaTime);
            animator.SetTrigger("jump");
        }
    }

    void CheckAirState()
    {
        bool isGround = feetCollider.IsTouchingLayers(LayerMask.GetMask("Platform"));
        float vy = rb.linearVelocityY;
  
        isFalling = !isGround && !isClimbing && vy < Mathf.Epsilon;
    }

    // Climb
    void Climb()
    {
        if (!bodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            rb.gravityScale = baseGravity;
            isClimbing = false;
            return;
        }

        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(rb.linearVelocityX, moveInput.y * climbSpeed * Time.fixedDeltaTime);

        isClimbing = Mathf.Abs(rb.linearVelocityY) > Mathf.Epsilon;
    }

    // Animation
    void AnimationTransition()
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isClimbing", isClimbing);
        animator.SetBool("isFalling", isFalling); 
    }

    // Getter & Setter
    public void setDead(bool state)
    {
        isDead = state;
    }

    public bool getDead()
    {
        return isDead;
    }

    public CapsuleCollider2D getBodyCollider()
    {
        return bodyCollider;
    }
}

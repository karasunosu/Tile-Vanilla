using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float horizontalFlySpeed = 10f;
    [SerializeField] float verticalFlySpeed = 10f;

    PlayerMovement player;
    CapsuleCollider2D bodyCollider;
    Animator animator;
    Rigidbody2D rb;

    float time;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        time = Time.fixedDeltaTime;
    }

    // Player die
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(player.getDead()) { return; }

        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard")))
        {
            player.setDead(true);
            animator.SetTrigger("Die");
            rb.linearVelocity = new Vector2(horizontalFlySpeed * time, verticalFlySpeed * time);
            
            StartCoroutine(TakePlayerLive());
        }
    }

    IEnumerator TakePlayerLive()
    {
        yield return new WaitForSecondsRealtime(2f);

        FindFirstObjectByType<GameSession>().PlayerDie();
    }
}

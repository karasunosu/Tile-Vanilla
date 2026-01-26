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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            player.setDead(true);
            animator.SetTrigger("Die");
            rb.linearVelocity = new Vector2(horizontalFlySpeed * time, verticalFlySpeed * time);
        }
    }
}

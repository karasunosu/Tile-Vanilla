using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        rb.linearVelocity = new Vector2(moveSpeed * transform.localScale.x * Time.fixedDeltaTime, rb.linearVelocityY);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Flip sprite
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}

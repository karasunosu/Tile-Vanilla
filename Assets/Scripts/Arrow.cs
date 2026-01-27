using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    Rigidbody2D rb;
    PlayerMovement player;
    float xSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * speed * Time.fixedDeltaTime;
        transform.localScale = new Vector2(player.transform.localScale.x, transform.localScale.y);
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 1f);
    }
}

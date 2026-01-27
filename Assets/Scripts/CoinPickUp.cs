using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] int score = 100;

    bool isPicked;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPicked)
        {
            isPicked = true;
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
            FindFirstObjectByType<GameSession>().AddScore(score);
            Destroy(gameObject);
        }
    }
}

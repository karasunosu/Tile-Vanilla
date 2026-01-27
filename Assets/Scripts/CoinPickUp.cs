using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField] AudioClip audio;


    bool isPicked;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPicked)
        {
            isPicked = true;
            AudioSource.PlayClipAtPoint(audio, gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject bow;

    PlayerMovement player;
    Animator animator;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    void OnAttack()
    {
        if(player.getDead()) { return; }

        animator.SetTrigger("isShooting");
        SpawnArrow();
    }
    void SpawnArrow()
    {
        Instantiate(arrow, bow.transform.position, transform.rotation);
    }
}

using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool isPlayerDead;

    private Animator anim;
    private Rigidbody2D rb;
    private bool isDead;

    private void Awake()
    {
        isPlayerDead = false;
        isDead = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleHit(other.gameObject);
    }

    private void HandleHit(GameObject hitObject)
    {
        if (isDead) return;

        if (hitObject.CompareTag("fire"))
        {
            isDead = true;
            isPlayerDead = true;

            if (rb != null)
                rb.linearVelocity = Vector2.zero;

            if (anim != null)
                anim.Play("CatDie");
        }
    }
}

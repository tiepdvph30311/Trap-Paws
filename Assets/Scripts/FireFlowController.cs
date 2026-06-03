using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FireFlowController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private Rigidbody2D rb;
    private float moveDirection = 1f;
    private bool isFlowing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            if (rb.bodyType == RigidbodyType2D.Static)
                rb.bodyType = RigidbodyType2D.Kinematic;

            if (rb.bodyType != RigidbodyType2D.Kinematic && rb.bodyType != RigidbodyType2D.Dynamic)
                rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void StartFlow(float direction, float customSpeed)
    {
        moveDirection = direction >= 0f ? 1f : -1f;
        speed = customSpeed;
        isFlowing = true;

        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (!isFlowing || rb == null)
            return;

        if (rb.bodyType == RigidbodyType2D.Static)
            return;

        rb.linearVelocity = new Vector2(moveDirection * speed, rb.linearVelocity.y);
    }
}

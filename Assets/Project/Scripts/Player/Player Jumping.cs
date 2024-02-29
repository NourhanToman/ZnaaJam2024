using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float fallGravity = 2.5f;
    [SerializeField] private float lowJumpGravity = 2f;
    [SerializeField] private int maxJumpCount = 2;

    private Rigidbody2D rb;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private int jumpCount = 0;

    private void Awake()
    {
        ServiceLocator.Instance.RegisterService(this);
        rb = GetComponent<Rigidbody2D>();
    }

    internal void HandleJump(bool isJumpRequested)
    {
        if (isJumpRequested && jumpCount < maxJumpCount)
        {
            isJumping = true;
            jumpCount++;
        }

        if (rb.velocity.y < 0)
            rb.gravityScale = fallGravity;
        else if (rb.velocity.y > 0 && !isJumpRequested)
            rb.gravityScale = lowJumpGravity;
        else
            rb.gravityScale = 1f;

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameConstant.GroundTag))
            jumpCount = 0;
    }
}
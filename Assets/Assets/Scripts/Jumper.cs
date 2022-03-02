using UnityEngine;

public class Jumper : MonoBehaviour
{
    public bool isJumping = false;

    [SerializeField]
    private float m_shortHopVelocity = 100;
    [SerializeField]
    private float m_jumpVelocity = 500;
    [SerializeField]
    private float m_fallMultiplier = 2.5f;
    [SerializeField]
    private float m_lowJumpMultiplier = 2.0f;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            isJumping = false;
            rb.velocity += Vector2.up * Physics2D.gravity.y * (m_fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if(rb.velocity.y > 0 && !isJumping)
        {
            print("Short hop");
            rb.velocity += Vector2.up * Physics2D.gravity.y * (m_lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }

    }
    public void ShortHop()
    {
        isJumping = true;
        rb.velocity = Vector2.up * m_jumpVelocity;
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * m_jumpVelocity, ForceMode2D.Impulse);
    }

}
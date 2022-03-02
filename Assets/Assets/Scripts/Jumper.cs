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

    private Rigidbody2D m_rigidbody;
    private float m_maxFallSpeed = -24f;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        if (m_rigidbody.velocity.y < 0)
        {
            isJumping = false;
            m_rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (m_fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if(m_rigidbody.velocity.y > 0 && !isJumping)
        {
            print("Short hop");
            m_rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (m_lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }

        m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, Mathf.Clamp(m_rigidbody.velocity.y, m_maxFallSpeed, m_rigidbody.velocity.y));
    }
    public void ShortHop()
    {
        isJumping = true;
        m_rigidbody.velocity = Vector2.up * m_jumpVelocity;
    }

    public void Jump()
    {
        m_rigidbody.AddForce(Vector2.up * m_jumpVelocity, ForceMode2D.Impulse);
    }

}
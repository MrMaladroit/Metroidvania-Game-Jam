using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField]
    private float m_shortHopVelocity = 100;
    [SerializeField]
    private float m_jumpVelocity = 500;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
    }
    public void ShortHop()
    {
        print("Short Hop Called");

        print("Velocity: " + m_shortHopVelocity);
        rb.AddForce(Vector2.up * m_shortHopVelocity, ForceMode2D.Impulse);
    }

    public void Jump()
    {
        print("Jump Called");
        print("Velocity: " + m_jumpVelocity);
        rb.AddForce(Vector2.up * m_jumpVelocity, ForceMode2D.Impulse);
    }

}
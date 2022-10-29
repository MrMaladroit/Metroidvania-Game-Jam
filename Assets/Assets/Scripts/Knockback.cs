using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField]
    private float m_knockbackForce = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<ITakeDamage>();
        var rb = collision.gameObject.GetComponent<Rigidbody2D>();
        print("Collison detected");
        if (collision.gameObject.tag == "Player") //target != null && rb != null)
        {
            //var direction = Vector2.Reflect(rb.velocity, collision.GetContact(0).normal);
            //rb.AddForce (direction * m_knockbackForce, ForceMode2D.Impulse);
            //print("Knockback called.");

            if(transform.position.x > collision.transform.position.x)
            {
                rb.AddForce(new Vector2(-m_knockbackForce, m_knockbackForce), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(m_knockbackForce, m_knockbackForce), ForceMode2D.Impulse);
            }
        }
    }
}
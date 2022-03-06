using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    [SerializeField]
    private int m_damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDamage target = collision.gameObject.GetComponent<ITakeDamage>();
        if(target != null)
        {
            target.TakeDamage(m_damage);
        }
        
        Destroy(this.gameObject);
    }
}
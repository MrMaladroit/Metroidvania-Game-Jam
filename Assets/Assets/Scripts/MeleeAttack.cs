using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    private int m_damage = 1;

    private Rigidbody2D m_rb;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var takeDamage = collision.gameObject.GetComponent<ITakeDamage>();

        if(collision.gameObject.tag == "Player" && takeDamage != null )
        {
            takeDamage.TakeDamage(m_damage);
        }
    }
}
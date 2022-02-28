using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAttack : MonoBehaviour
{
    [SerializeField]
    private float m_throwForce;
    [SerializeField]
    private float m_lobAngle;
    [SerializeField]
    private GameObject[] m_items;

    private GameObject m_currentItem;

    private void Awake()
    {
        m_currentItem = m_items[0];
    }


    public void Throw()
    {
        GameObject projectile  = Instantiate(m_currentItem, gameObject.transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(m_currentItem.transform.forward * m_throwForce, ForceMode2D.Impulse);
    }

    public void Lob()
    {
        GameObject projectile = Instantiate(m_currentItem, gameObject.transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-1 * m_lobAngle, 1 * m_throwForce), ForceMode2D.Impulse);
    }

    public void LoadNextItem()
    {

    }
}
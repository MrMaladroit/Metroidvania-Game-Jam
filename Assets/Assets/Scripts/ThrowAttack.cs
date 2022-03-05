using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAttack : MonoBehaviour
{
    [SerializeField]
    private float m_throwForce;
    [SerializeField]
    private float m_throwAngle;
    [SerializeField]
    private float m_lobForce;
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
        print("Throw Called");
        GameObject projectile  = Instantiate(m_currentItem, gameObject.transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2 (gameObject.transform.forward.z * m_throwForce, m_throwAngle), ForceMode2D.Impulse);
    }

    public void Lob()
    {
        print("Lob Called");
        GameObject projectile = Instantiate(m_currentItem, gameObject.transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce( new Vector2(m_lobAngle * gameObject.transform.forward.z, m_throwForce) , ForceMode2D.Impulse);
    }

    public void LoadNextItem()
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed;

    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        m_rigidbody.velocity = new Vector2(movementVector.x * m_moveSpeed, m_rigidbody.velocity.y);
    }
}
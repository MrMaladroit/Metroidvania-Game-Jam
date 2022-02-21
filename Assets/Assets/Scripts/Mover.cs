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
        movementVector.x = transform.position.x * m_moveSpeed * Time.deltaTime;
        movementVector.y = transform.position.y * m_moveSpeed * Time.deltaTime;
        m_rigidbody.MovePosition(movementVector);
    }
}
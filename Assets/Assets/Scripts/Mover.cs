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
        //float xPos = transform.position.x + movementVector.x * m_moveSpeed * Time.deltaTime;
        //float yPos = transform.position.y;
        //m_rigidbody.MovePosition(m_rigidbody.position + movementVector * Time.fixedDeltaTime);
    }
}
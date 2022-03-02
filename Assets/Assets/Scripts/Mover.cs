using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed;

    private Rigidbody2D m_rigidbody;
    private SpriteRenderer m_spriteRenderer;
    private float m_maxMoveSpeed;
    private Animator m_animator;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        print("Current velocity: " + m_rigidbody.velocity);
        m_rigidbody.velocity = new Vector2(Mathf.Clamp(m_rigidbody.velocity.x, 0, m_maxMoveSpeed), m_rigidbody.velocity.y) ;
    }


    public void Move(Vector2 movementVector)
    {
        if (movementVector.x != 0)
        {
            var facing = movementVector.x < 0 ? 180 : 0;
            transform.rotation = new Quaternion(0, facing, 0, 0);
        }
        m_animator.SetFloat("Speed", Mathf.Clamp(Mathf.Abs(movementVector.x), 0, 1));
        m_rigidbody.velocity = new Vector2(movementVector.x * m_moveSpeed, m_rigidbody.velocity.y);
    }
}
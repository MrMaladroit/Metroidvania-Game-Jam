using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float deceleration = 15f;
    [SerializeField]
    private float m_maxSpeed = 5f;
    [SerializeField]
    private float acceleration = 10f;

    private Rigidbody2D m_rigidbody;
    private Animator m_animator;
    private float xVelocity;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    public void Move(Vector2 movementVector)
    {
        if (movementVector.x != 0)
        {
            var facing = movementVector.x < 0 ? 180 : 0;
            transform.rotation = new Quaternion(0, facing, 0, 0);
        }

        m_animator.SetFloat("Speed", Mathf.Clamp(Mathf.Abs(movementVector.x), 0, 1));


        if(xVelocity > -m_maxSpeed && movementVector.x > 0)
        {
            xVelocity += acceleration * Time.fixedDeltaTime; 
        }
        else if(xVelocity < m_maxSpeed && movementVector.x < 0)
        {
            xVelocity -= acceleration * Time.fixedDeltaTime;
        }
        else
        {
            if(xVelocity > deceleration * Time.fixedDeltaTime)
            {
                xVelocity -= deceleration * Time.fixedDeltaTime;
            }
            else if(xVelocity < -deceleration * Time.fixedDeltaTime)
            {
                xVelocity += deceleration * Time.fixedDeltaTime;
            }
            else
            {
                xVelocity = 0;
            }
        }
        xVelocity = Mathf.Clamp(xVelocity, -m_maxSpeed, m_maxSpeed);
        m_rigidbody.velocity = new Vector2(xVelocity, m_rigidbody.velocity.y);
    }

}
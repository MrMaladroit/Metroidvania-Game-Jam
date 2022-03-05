using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputController : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_startPosition;
    [SerializeField]
    private Vector3 m_destination;

    private Mover m_mover;
    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_mover = GetComponent<Mover>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, m_destination) > 0.1)
        {
            float direction = transform.position.x > m_destination.x ? -1 : 1; 
            m_mover.Move(new Vector2(direction, 0));
        }
        else
        {
            var temp = m_startPosition;
            m_startPosition = m_destination;
            m_destination = temp;
        }
    }
}
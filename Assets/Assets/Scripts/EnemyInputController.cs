using System;
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
    private bool m_isDead = false;

    private void Awake()
    {
        m_mover = GetComponent<Mover>();
        m_startPosition = transform.position;
    }

    private void OnEnable()
    {
        Enemy.OnHealthReachedZero += StopMovement;
    }

    private void OnDisable()
    {
        Enemy.OnHealthReachedZero -= StopMovement;
    }

    private void StopMovement()
    {
        m_isDead = true;
    }

    private void FixedUpdate()
    {
        if(m_isDead)
        {
            //Fix this -- without stopping velocity, the animation becomes scuffed
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{

    public static Action OnHealthReachedZero;
    public int Health { get; }
    [SerializeField]
    private int m_health = 3;
    [SerializeField]
    private float m_destroyDelayInSeconds;

    private Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int Damage)
    {
        m_health -= Damage;

        if(m_health <= 0)
        {
            //Call Death function
            HealthReachedZero();
        }
    }

    private void HealthReachedZero()
    {
        OnHealthReachedZero();
        PlayDeathAnimation();
        Destroy(this.gameObject, m_destroyDelayInSeconds);
    }

    private void PlayDeathAnimation()
    {
        m_animator.SetBool("Dead", true);
    }
}

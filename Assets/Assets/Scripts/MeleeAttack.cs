using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    [SerializeField]
    private int m_damage = 1;
    public override void DoDamageToTarget(int damage)
    {
        throw new System.NotImplementedException();
    }

    public override bool IsTargetDamagable(GameObject target)
    {
        return target.GetComponent<ITakeDamage>() == null;
    }

    public override void StartAttack(GameObject obj)
    {
        if(IsTargetDamagable(obj))
        {
            DoDamageToTarget(m_damage);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public abstract void StartAttack();

    public abstract bool IsTargetDamagable(GameObject target);

    public abstract void DoDamageToTarget(int damage, ITakeDamage target);
}
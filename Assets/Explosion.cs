using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int damage = 15;

    public void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);
        other.TryGetComponent(out DamageTarget damageTarget);

        if (damageTarget) damageTarget.GetComponent<IDamageable>().TakeDamage(damage);
        if (playerManager) playerManager.GetComponent<IDamageable>().TakeDamage(damage);
    }
}

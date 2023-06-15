using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] int damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable;

        collision.transform.TryGetComponent(out PlayerManager playerManager); // checks for playerManager
        if (playerManager)
        {
            damageable = playerManager.GetComponent<IDamageable>();
            damageable.TakeDamage(damageAmount); // Runs TakeDamage
        }
    }
}

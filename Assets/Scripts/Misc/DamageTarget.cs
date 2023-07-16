using Unity.Collections;
using UnityEngine;

public class DamageTarget : MonoBehaviour, IDamageable
{
    public int maxHealth;
    public int Health { get; private set; }

    void Start()
    {
        Health = maxHealth;
    }

    public void Hit(int damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Hit(damageAmount);
    }
}

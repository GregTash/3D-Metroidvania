using UnityEngine;

public class DamageTarget : MonoBehaviour, IDamageable
{
    [SerializeField] int health;

    public void Hit(int damageAmount)
    {
        Debug.Log("DamageTarget hit");
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Hit(damageAmount);
    }
}

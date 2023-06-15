using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    public GameObject hitEnemy;
    [SerializeField] int weaponDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            hitEnemy = other.gameObject;
            Debug.Log(hitEnemy.name);
            DamageToEnemy();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hitEnemy = null;
    }

    void DamageToEnemy()
    {
        IDamageable damageable;
        Debug.Log("Enemy Found");
        hitEnemy.TryGetComponent(out DamageTarget damageTarget);
        Debug.Log("Component gotten");
        damageable = damageTarget.GetComponent<IDamageable>();
        Debug.Log("Got IDamageable");
        damageable.TakeDamage(weaponDamage);
        Debug.Log("Damage Taken");
    }
}

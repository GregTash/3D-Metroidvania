using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordCollision : MonoBehaviour
{
    public GameObject hitEnemy;
    [SerializeField] float appearForSeconds;
    [SerializeField] int weaponDamage;

    [SerializeField] PlayerInput PlayerInput;

    private void Start()
    {
        //Player
    }

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
        hitEnemy.TryGetComponent(out DamageTarget damageTarget);
        damageable = damageTarget.GetComponent<IDamageable>();
        damageable.TakeDamage(weaponDamage);
    }
}

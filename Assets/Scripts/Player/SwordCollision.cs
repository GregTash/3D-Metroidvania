using System;
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

    private void Awake()
    {
        transform.root.GetComponent<PlayerInput>();
        Debug.Log(transform.root.name);
    }

    private void OnEnable()
    {
        InputAction attackKeyPressed = PlayerInput.actions["Attack"];

        attackKeyPressed.started += OnSwing;

        attackKeyPressed.Enable();
    }

    private void OnDisable()
    {
        InputAction attackKeyPressed = PlayerInput.actions["Attack"];

        attackKeyPressed.Disable();

        attackKeyPressed.started -= OnSwing;
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
    
    void OnSwing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Swing();
        }
    }

    void Swing()
    {
        Debug.Log("Swing function working");
        StartCoroutine(IActivateSword());
    }

    IEnumerator IActivateSword()
    {
        Debug.Log("Enumerator is working");
        gameObject.SetActive(true);
        yield return new WaitForSeconds(appearForSeconds);
        gameObject.SetActive(false);
    }
}
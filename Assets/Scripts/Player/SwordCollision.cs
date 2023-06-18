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
    bool swinging;

    [SerializeField] PlayerInput PlayerInput;
    Collider _collider;
    Animator _animator;
    PlayerMovement _playerMovement;
    Rigidbody _playerRb;

    private void Awake()
    {
        transform.root.GetComponent<PlayerInput>();
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
        _playerRb = transform.root.GetComponent<Rigidbody>();
        _playerMovement = transform.root.GetComponent<PlayerMovement>();
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
        if (swinging) return;
        
        _animator.Play("Swing Sword");
    }

    void HitboxEnable()
    {
        _collider.enabled = true;
        swinging = true;
    }

    void HitboxDisable()
    {
        _collider.enabled = false;
        swinging = false;
    }

    void StopPlayer()
    {
        _playerMovement.detectInput = false;
        _playerRb.velocity = new Vector3(0, _playerRb.velocity.y, 0);
    }

    void StartPlayer()
    {
        _playerMovement.detectInput = true;
    }
}
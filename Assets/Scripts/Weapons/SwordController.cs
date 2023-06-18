using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordController : MonoBehaviour
{
    [HideInInspector] GameObject hitEnemy;
    [SerializeField] float appearForSeconds;
    [SerializeField] int weaponDamage;
    [SerializeField] float knockbackDistance;
    bool swinging;

    [SerializeField] PlayerInput PlayerInput;
    Collider _collider;
    Animator _animator;
    PlayerMovement _playerMovement;
    Rigidbody _playerRb;
    Camera _cam;

    AudioSource _audioSource;

    private void Awake()
    {
        transform.root.GetComponent<PlayerInput>();
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
        _playerRb = transform.root.GetComponent<Rigidbody>();
        _playerMovement = transform.root.GetComponent<PlayerMovement>();
        _audioSource = GetComponent<AudioSource>();
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
            DamageToEnemy();
            KnockbackEnemy();
            _audioSource.Play();
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
        _animator.Play("Swing Sword");
    }

    void KnockbackEnemy()
    {
        hitEnemy.GetComponent<Rigidbody>().AddForce(transform.forward * knockbackDistance);
    }

    void HitboxEnable()
    {
        _collider.enabled = true;
    }

    void HitboxDisable()
    {
        _collider.enabled = false;
    }
}
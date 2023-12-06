using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordController : MonoBehaviour
{
    [HideInInspector] public GameObject hitEnemy;
    [SerializeField] float appearForSeconds;
    [SerializeField] int weaponDamage;
    [SerializeField] float knockbackDistance;
    bool enemyDamaged;
    bool _swinging = false;

    [SerializeField] PlayerInput PlayerInput;
    Collider _collider;
    Animator _animator;
    PlayerMovement _playerMovement;
    Rigidbody _playerRb;
    Camera _cam;

    AudioSource _audioSource;
    [SerializeField] AudioSource swingSoundAudioSource;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
        AutoDisableSwing();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            hitEnemy = other.gameObject;
            if (!enemyDamaged)
            {
                DamageToEnemy();
                enemyDamaged = true;
            }
            StartCoroutine(IEnemyDamaged());
            //KnockbackEnemy();
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
        if(damageTarget.transform.tag != "Player")
        {
            damageable = damageTarget.GetComponent<IDamageable>();
            damageable.TakeDamage(weaponDamage);
        }
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
        if (!_playerMovement.detectInput) return;
        _animator.Play("Swing Sword");
        swingSoundAudioSource.Play();
    }

    void AutoDisableSwing()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            _swinging = false;
        }

        if(!_swinging)
        {
            HitboxDisable();
        }
    }

    void KnockbackEnemy()
    {
        hitEnemy.GetComponent<Rigidbody>().AddForce(transform.forward * knockbackDistance);
    }

    IEnumerator IEnemyDamaged()
    {
        yield return new WaitForSeconds(.15f);
        enemyDamaged = false;
    }

    void HitboxEnable()
    {
        _collider.enabled = true;
        _swinging = true;
    }

    void HitboxDisable()
    {
        _collider.enabled = false;
        _swinging = false;
    }
}
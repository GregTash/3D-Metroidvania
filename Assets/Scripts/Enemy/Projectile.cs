using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damageAmount;
    AudioSource _audioSource;
    Collider _collider;
    Renderer _renderer;
    [SerializeField] LayerMask groundLayer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable;

        collision.transform.TryGetComponent(out PlayerManager playerManager); // checks for playerManager
        collision.transform.TryGetComponent(out DamageTarget damageTarget);
        if (playerManager)
        {
            damageable = playerManager.GetComponent<IDamageable>();
            damageable.TakeDamage(damageAmount); // Runs TakeDamage
            AfterProjectileCollides();
        }
        if (damageTarget)
        {
            damageable = damageTarget.GetComponent<IDamageable>();
            damageable.TakeDamage(damageAmount);
            AfterProjectileCollides();
        }

        if (groundLayer == (groundLayer | (1 << collision.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }

    void AfterProjectileCollides()
    {
        _audioSource.Play();
        _collider.enabled = false;
        _renderer.enabled = false;
        Destroy(gameObject, 1);
    }
}

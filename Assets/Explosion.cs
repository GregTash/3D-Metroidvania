using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int damage = 15;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);
        other.TryGetComponent(out DamageTarget damageTarget);

        if (damageTarget || playerManager)
        {
            if (damageTarget != null) damageTarget.GetComponent<IDamageable>().TakeDamage(damage);
            if (playerManager != null) playerManager.GetComponent<IDamageable>().TakeDamage(damage);
            audioSource.Play();
        }
    }
}

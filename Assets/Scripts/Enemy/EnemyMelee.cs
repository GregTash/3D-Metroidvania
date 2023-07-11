using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] int damageAmount;
    // [SerializeField] int knockbackPower;
    AudioSource _audioSource;
    bool takenDamage;
    EnemyAI _enemyAI;
    Rigidbody _rb;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _enemyAI = GetComponent<EnemyAI>();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable;

        collision.transform.TryGetComponent(out PlayerManager playerManager); // checks for playerManager
        if (playerManager)
        {
            if (!takenDamage)
            {
                damageable = playerManager.GetComponent<IDamageable>();
                damageable.TakeDamage(damageAmount); // Runs TakeDamage
                _audioSource.Play();
                takenDamage = true;
                //_rb.AddForce(-transform.forward * knockbackPower, ForceMode.Force);
                StartCoroutine(ITimeBetweenDamage());
            }
        }
    }

    IEnumerator ITimeBetweenDamage()
    {
        yield return new WaitForSeconds(.2f);
        takenDamage = false;
    }
}

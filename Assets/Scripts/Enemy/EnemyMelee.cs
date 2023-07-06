using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] int damageAmount;
    AudioSource _audioSource;
    bool takenDamage;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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

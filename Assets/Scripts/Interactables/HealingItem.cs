using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] int healingAmount = 25;
    [SerializeField] private AudioClip _clip;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.TryGetComponent(out PlayerManager _playerManager);

        if (_playerManager)
        {
            AudioSource.PlayClipAtPoint(_clip, transform.position);
            _playerManager.health += healingAmount;
        }

        Destroy(gameObject);
    }
}

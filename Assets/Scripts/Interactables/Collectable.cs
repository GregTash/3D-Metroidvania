using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int collectableAmount = 1;
    [SerializeField] PlayerManager _playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerManager.collectables += collectableAmount;

            PlayerPrefs.SetInt(transform.name, 1);

            Destroy(gameObject);
        }
    }
}

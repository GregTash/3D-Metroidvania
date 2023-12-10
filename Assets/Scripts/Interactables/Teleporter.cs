using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportLocation;
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        collision.TryGetComponent(out PlayerManager playerManager);
        {
            if (playerManager)
            {
                collision.transform.position = teleportLocation.position;
                _audioSource.Play();
            }
        }
    }
}

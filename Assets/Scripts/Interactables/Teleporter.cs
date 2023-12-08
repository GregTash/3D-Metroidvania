using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportLocation;

    private void OnTriggerEnter(Collider collision)
    {
        collision.TryGetComponent(out PlayerManager playerManager);
        {
            if (playerManager)
            {
                collision.transform.position = teleportLocation.position;
            }
        }
    }
}

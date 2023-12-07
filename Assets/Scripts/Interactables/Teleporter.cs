using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportLocation;
    [SerializeField] private float timeUntilNextTeleport;
    [SerializeField] private float timer;
    [SerializeField] private PlayerManager playerManger;

    private void Update()
    {
        if (!playerManger.canTeleport)
        {
            timer += Time.deltaTime;
            if (timer >= timeUntilNextTeleport)
            {
                playerManger.canTeleport = true;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        collision.TryGetComponent(out PlayerManager playerManager);
        {
            if (playerManager && playerManager.canTeleport)
            {
                collision.transform.position = teleportLocation.position;
                playerManager.canTeleport = false;
            }
        }
    }
}

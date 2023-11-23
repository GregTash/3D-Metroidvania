using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItem : MonoBehaviour
{
    [SerializeField] int arrowPickupAmount;
    [SerializeField] PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerManager = other.GetComponentInChildren<PlayerManager>();

            playerManager.arrowsLeft += arrowPickupAmount;

            Destroy(gameObject);
        }
    }
}

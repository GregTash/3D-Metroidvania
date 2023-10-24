using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItem : MonoBehaviour
{
    [SerializeField] int arrowPickupAmount;
    [SerializeField] BowController bowController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bowController.arrowsLeft += arrowPickupAmount;

            Destroy(gameObject);
        }
    }
}

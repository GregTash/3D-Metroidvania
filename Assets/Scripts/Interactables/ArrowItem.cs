using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItem : MonoBehaviour
{
    [SerializeField] int arrowPickupAmount;
    [SerializeField] BowController _bowController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _bowController.arrowsLeft += arrowPickupAmount;

            Destroy(gameObject);
        }
    }
}

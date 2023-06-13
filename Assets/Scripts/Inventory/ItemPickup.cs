using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] Item item;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);

        if(playerManager)
        {
            playerManager.PlayerInventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
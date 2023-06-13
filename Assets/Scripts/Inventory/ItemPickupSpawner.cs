using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupSpawner : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        //ItemPickup.SpawnItemPickup(transform.position, item);
        Destroy(gameObject);
    }
}
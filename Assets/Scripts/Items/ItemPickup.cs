using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public static ItemPickup SpawnItemPickup(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemPickup, position, Quaternion.identity);

        ItemPickup itemPickup = transform.GetComponent<ItemPickup>();
        itemPickup.SetItem(item);

        return itemPickup;
    }

    Item _item;
    public void SetItem(Item item)
    {
        this._item = item;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);

        if(playerManager)
        {
            playerManager.PlayerInventory.AddItem(_item);
            Destroy(gameObject);
        }
    }
}

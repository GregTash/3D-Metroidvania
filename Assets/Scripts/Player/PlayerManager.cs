using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] InventoryUI uiInventory;
    Inventory _playerInventory;

    private void Awake()
    {
        _playerInventory = new Inventory();
        uiInventory.SetInventory(_playerInventory);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] InventoryUI uiInventory;
    public Inventory PlayerInventory { get; private set; }
    [SerializeField] PlayerInput playerInput;

    private void Start()
    {
        PlayerInventory = new Inventory();
        uiInventory.SetInventory(PlayerInventory);
        ItemPickup.SpawnItemPickup(new Vector3(0, 1, 0), new Item { itemType = Item.ItemType.Sword, amount = 1 });
    }

    private void OnEnable()
    {
        InputAction toggleInventory = playerInput.actions["Inventory"];

        toggleInventory.started += ToggleInventory;
    }

    private void OnDisable()
    {
        InputAction toggleInventory = playerInput.actions["Inventory"];

        toggleInventory.started -= ToggleInventory;
    }

    void ToggleInventory(InputAction.CallbackContext context)
    {
        if(!uiInventory.gameObject.activeSelf)
        {
            uiInventory.gameObject.SetActive(true);
        }
        else
        {
            uiInventory.gameObject.SetActive(false);
        }
    }
}

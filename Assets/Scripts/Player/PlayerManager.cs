using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] InventoryUI uiInventory;
    Inventory _playerInventory;
    [SerializeField] PlayerInput playerInput;

    private void Awake()
    {
        _playerInventory = new Inventory();
        uiInventory.SetInventory(_playerInventory);
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

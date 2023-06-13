using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //public int health = 100;
    [SerializeField] InventoryUI uiInventory;
    public Inventory PlayerInventory { get; private set; }
    [SerializeField] PlayerInput playerInput;

    private void Start()
    {
        PlayerInventory = new Inventory();
        uiInventory.SetInventory(PlayerInventory);
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

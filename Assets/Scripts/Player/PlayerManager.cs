using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public int health = 100;
    public int MaxHealth { get; private set; } = 100;

    [SerializeField] InventoryUI uiInventory;
    public Inventory PlayerInventory { get; private set; }
    [SerializeField] PlayerInput playerInput;

    [SerializeField] GameObject bowObject;
    [SerializeField] GameObject swordObject;


    private void Start()
    {
        PlayerInventory = new Inventory();
        uiInventory.SetInventory(PlayerInventory);
    }

    private void OnEnable()
    {
        InputAction toggleInventory = playerInput.actions["Inventory"];

        toggleInventory.started += ToggleInventory;

        // Draw Bow Enable
        InputAction aimKeyPressed = playerInput.actions["Aim"];

        aimKeyPressed.started += WeaponSwitch;
    }

    private void OnDisable()
    {
        InputAction toggleInventory = playerInput.actions["Inventory"];

        toggleInventory.started -= ToggleInventory;

        // Disable Bow Enable
        InputAction aimKeyPressed = playerInput.actions["Aim"];

        aimKeyPressed.started -= WeaponSwitch;
    }

    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(health > MaxHealth)
        {
            health = MaxHealth;
        }

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

    void WeaponSwitch(InputAction.CallbackContext context)
    {
        float aimDown = playerInput.actions["Aim"].ReadValue<float>();
        float threshold = 0.001f;
        if (aimDown > 0)
        {
            bowObject.SetActive(true);
            swordObject.SetActive(false);
        }
        else if (aimDown <= threshold)
        {
            bowObject.SetActive(false);
            swordObject.SetActive(true);
        }

    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }
}

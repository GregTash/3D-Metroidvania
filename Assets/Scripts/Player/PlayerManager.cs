using TMPro;
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

    public int arrowsLeft;
    [SerializeField] TextMeshProUGUI arrowsLeftText;

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

        aimKeyPressed.performed += WeaponSwitch;
        aimKeyPressed.canceled += WeaponSwitch;
    }

    private void OnDisable()
    {
        InputAction toggleInventory = playerInput.actions["Inventory"];

        toggleInventory.started -= ToggleInventory;

        // Disable Bow Enable
        InputAction aimKeyPressed = playerInput.actions["Aim"];

        aimKeyPressed.performed -= WeaponSwitch;
        aimKeyPressed.canceled -= WeaponSwitch;
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

        arrowsLeftText.text = "Arrows left: " + arrowsLeft;
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
        if (!bowObject.activeSelf)
        {
            bowObject.SetActive(true);
            swordObject.SetActive(false);
        }
        else
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

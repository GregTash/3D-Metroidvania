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

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }
}

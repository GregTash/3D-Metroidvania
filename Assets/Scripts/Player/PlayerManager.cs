using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public int health = 100;
    public int MaxHealth { get; private set; } = 100;

    public bool allowDamage = true;

    [SerializeField] PlayerInput playerInput;

    public int collectables = 0;

    [HideInInspector] public Transform respawnPoint;

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

    public void TakeDamage(int damageAmount)
    {
        if(allowDamage) health -= damageAmount;
    }
}

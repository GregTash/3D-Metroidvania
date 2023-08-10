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

    public int gemsCollected = 0;

    bool mountainArea = false;

    bool poisonLake = false;

    [HideInInspector] public Transform respawnPoint;

    void Start()
    {
        SetInitialSpawnpoint();
    }

    void Update()
    {
        if(health <= 0)
        {
            Respawn();
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

    void SetInitialSpawnpoint()
    {
        GameObject startPos = new GameObject();

        startPos.name = "StartPos";
        startPos.transform.position = transform.position;

        respawnPoint = startPos.transform;
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
        health = MaxHealth;
    }
}

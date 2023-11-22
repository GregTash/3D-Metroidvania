using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public int health = 100;
    public int MaxHealth { get; private set; } = 100;

    public bool allowDamage = true;

    [SerializeField] PlayerInput playerInput;

    public int collectables = 0;

    public int gemsCollected = 0;

    bool _dying = false;

    [HideInInspector] public Transform respawnPoint;
    [SerializeField] PlayerAnimator playerAnimatorScript;
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Rigidbody playerRb;

    void Start()
    {
        SetInitialSpawnpoint();

        collectables = PlayerPrefs.GetInt("Collectables");

        gemsCollected = PlayerPrefs.GetInt("GemsCollected");

        health = PlayerPrefs.GetInt("Health");
    }

    void Update()
    {
        UpdatePlayerPrefs();

        if(health <= 0)
        {
            playerRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

            if (!_dying)
            {
                StartCoroutine(Die());
                _dying = true;
            }
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

    public void Respawn()
    {
        playerAnimator.SetTrigger("Alive");
        playerAnimatorScript.enabled = true;
        playerMovement.detectInput = true;
        transform.position = respawnPoint.position;
        health = MaxHealth;
        _dying = false;
        playerRb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void UpdatePlayerPrefs()
    {
        if (PlayerPrefs.GetInt("Collectables") != collectables)
        {
            PlayerPrefs.SetInt("Collectables", collectables);
        }

        if (PlayerPrefs.GetInt("GemsCollected") != gemsCollected)
        {
            PlayerPrefs.SetInt("GemsCollected", gemsCollected);
        }

        if(PlayerPrefs.GetInt("Health") != health)
        {
            PlayerPrefs.SetInt("Health", health);
        }
    }

    IEnumerator Die()
    {
        playerAnimator.Play("Die");
        playerAnimatorScript.enabled = false;
        playerMovement.detectInput = false;
        yield return new WaitForSeconds(4);
        Respawn();
    }
}

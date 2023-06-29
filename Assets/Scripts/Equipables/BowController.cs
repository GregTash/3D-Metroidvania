using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowController : MonoBehaviour
{
    [SerializeField] PlayerInput PlayerInput;
    [SerializeField] GameObject arrowSpawner;
    [SerializeField] GameObject projectile;
    [SerializeField] float shotPower;
    PlayerControls _playerControls;
    [SerializeField] PlayerManager _playerManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.root.GetComponent<PlayerInput>();
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    private void OnEnable()
    {
        _playerControls.Default.Attack.started += OnShootBow;
        // Enable Shoot Bow
        InputAction shootKeyPressed = PlayerInput.actions["Attack"];

        shootKeyPressed.Enable();

        shootKeyPressed.started += OnShootBow;
    }

    private void OnDisable()
    {
        _playerControls.Default.Attack.started -= OnShootBow;

        // Disable Shoot Bow
        InputAction shootKeyPressed = PlayerInput.actions["Attack"];

        shootKeyPressed.Disable();

        shootKeyPressed.started -= OnShootBow;
    }

    void OnShootBow(InputAction.CallbackContext context)
    {
        if (_playerManager.arrowsLeft > 0)
        {
            Debug.Log("Shot");
            Rigidbody arrow = Instantiate(projectile, arrowSpawner.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            arrow.velocity = Camera.main.transform.forward * shotPower;
            _playerManager.arrowsLeft -= 1;
        }
        else if (_playerManager.arrowsLeft <= 0)
        {
            Debug.Log("Can't shoot anymore, we have " + _playerManager.arrowsLeft + " arrows left");
        }
    }
}

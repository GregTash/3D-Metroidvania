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
    WeaponManager _weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.root.GetComponent<PlayerInput>();
        _weaponManager = GetComponentInParent<WeaponManager>();
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
        if (_weaponManager.arrowsLeft > 0)
        {
            Debug.Log("Shot");
            Rigidbody arrow = Instantiate(projectile, arrowSpawner.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            arrow.velocity = Camera.main.transform.forward * shotPower;
            _weaponManager.arrowsLeft -= 1;
        }
        else if (_weaponManager.arrowsLeft <= 0)
        {
            Debug.Log("Can't shoot anymore, we have " + _weaponManager.arrowsLeft + " arrows left");
        }
    }
}

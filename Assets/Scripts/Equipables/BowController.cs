using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowController : MonoBehaviour
{
    [SerializeField] PlayerInput PlayerInput;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameObject arrowSpawner;
    [SerializeField] GameObject projectile;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] float shotPower;
    PlayerControls _playerControls;
    
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    private void OnEnable()
    {
        _playerControls.Default.Attack.started += OnShootBow;

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
        if (!playerMovement.detectInput) return;

        if (playerManager.arrowsLeft > 0)
        {
            _audioSource.Play();

            Rigidbody arrow = Instantiate(projectile, arrowSpawner.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            arrow.transform.parent = null;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);

            Vector3 hitPoint;
            if(hit.transform != null)
            {
                hitPoint = hit.point;
            }
            else
            {
                hitPoint = ray.GetPoint(100);
            }

            Vector3 direction = hitPoint - arrowSpawner.transform.position;
            arrow.transform.forward = direction.normalized;

            arrow.AddForce(direction.normalized * shotPower, ForceMode.Impulse);

            playerManager.arrowsLeft -= 1;
        }
    }
}

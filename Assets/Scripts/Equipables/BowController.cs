using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowController : MonoBehaviour
{
    ThirdPersonCam _thirdPersonCam;
    [SerializeField] PlayerInput PlayerInput;
    [SerializeField] GameObject swordPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.root.GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        // Enable Shoot Bow
        InputAction shootKeyPressed = PlayerInput.actions["Attack"];

        shootKeyPressed.started += OnShootBow;

        shootKeyPressed.Enable();
    }

    private void OnDisable()
    {
        // Disable Shoot Bow
        InputAction shootKeyPressed = PlayerInput.actions["Attack"];

        shootKeyPressed.Disable();

        shootKeyPressed.started -= OnShootBow;
    }

    void OnShootBow(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ShootBow();
        }
    }

    void ShootBow()
    {

    }
}

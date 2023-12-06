using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public GameObject bombObject;
    public GameObject scratchObject;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerManager playerManager;

    bool _bombEnabled = false;

    private void OnEnable()
    {
        // Draw Bow Enable
        InputAction aimKeyPressed = playerInput.actions["Aim"];

        aimKeyPressed.performed += WeaponSwitch;
        aimKeyPressed.canceled += WeaponSwitch;
    }

    private void OnDisable()
    {
        // Draw Bow Disable
        InputAction aimKeyPressed = playerInput.actions["Aim"];

        aimKeyPressed.performed -= WeaponSwitch;
        aimKeyPressed.canceled -= WeaponSwitch;
    }

    private void Update()
    {
        if (playerManager.bombs <= 0)
        {
            bombObject.SetActive(false);
        }

        if (playerManager.bombs > 0 && _bombEnabled)
        {
            bombObject.SetActive(true);
        }
    }

    void WeaponSwitch(InputAction.CallbackContext context)
    {
        if (!playerMovement.detectInput) return;

        if (!_bombEnabled)
        {
            if (playerManager.bombs > 0) bombObject.SetActive(true);
            scratchObject.SetActive(false);
            _bombEnabled = true;
        }
        else
        {
            bombObject.SetActive(false);
            scratchObject.SetActive(true);
            _bombEnabled = false;
        }
    }
}

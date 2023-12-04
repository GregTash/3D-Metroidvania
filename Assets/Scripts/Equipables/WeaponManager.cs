using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public GameObject bombObject;
    public GameObject swordObject;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerManager playerManager;

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

    void WeaponSwitch(InputAction.CallbackContext context)
    {
        if (!playerMovement.detectInput) return;

        if (!bombObject.activeSelf && playerMovement.detectInput)
        {
            if (playerManager.bombs > 0) bombObject.SetActive(true);
            swordObject.SetActive(false);
        }
        else
        {
            bombObject.SetActive(false);
            swordObject.SetActive(true);
        }
    }
}

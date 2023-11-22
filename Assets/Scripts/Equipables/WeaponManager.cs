using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public GameObject bowObject;
    public GameObject swordObject;
    [SerializeField] PlayerInput playerInput;
    BowController _bowController;
    PlayerMovement _playerMovement;

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

    // Start is called before the first frame update
    void Start()
    {
        _bowController = transform.GetChild(1).gameObject.GetComponent<BowController>();
        _playerMovement = transform.root.GetComponent<PlayerMovement>();
    }

    void WeaponSwitch(InputAction.CallbackContext context)
    {

        if (!bowObject.activeSelf && _playerMovement.detectInput)
        {
            bowObject.SetActive(true);
            swordObject.SetActive(false);

        }
        else
        {
            bowObject.SetActive(false);
            swordObject.SetActive(true);
        }
    }
}

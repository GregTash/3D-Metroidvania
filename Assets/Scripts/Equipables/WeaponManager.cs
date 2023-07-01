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


    [SerializeField] TextMeshProUGUI playerArrowsLeftText;

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
    }

    // Update is called once per frame
    void Update()
    {
        playerArrowsLeftText.text = "Arrows left: " + _bowController.arrowsLeft;
    }

    void WeaponSwitch(InputAction.CallbackContext context)
    {
        if (!bowObject.activeSelf)
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

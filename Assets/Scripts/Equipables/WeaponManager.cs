using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    public GameObject bowObject;
    public GameObject swordObject;
    public List<GameObject> weaponList;
    int selectedWeapon = 0;
    [SerializeField] PlayerInput playerInput;

    BowController _bowController;

    [SerializeField] TextMeshProUGUI playerArrowsLeftText;

    //TODO: Make a List that holds all weapon objects
    //TODO: Make an integer that holds the weapon select ID (E.G. if you press 2, you will select weapon 2 from the list)
    //TODO: Enable and disable weapons based on your keypress (E.G. You select weapon 2, it enables the bow, and disables the sword and bombs)



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

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    selectedWeapon = 0;
        //    WeaponSwitch();
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    selectedWeapon = 1;
        //    WeaponSwitch();
        //}

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

        // THIS WORKS. THE SWORD HOWEVER CANNOT BE SWUNG AFTERWARDS AND BOW SHOOTS TWICE. UNKNOWN REASON. WILL LOOK INTO IT AGAIN
        //for (int i = 0; i < weaponList.Count; i++)
        //{
        //    if (weaponList[selectedWeapon] != weaponList[i])
        //    {
        //        weaponList[i].SetActive(false);
        //    }
        //    weaponList[i].gameObject.SetActive(i == selectedWeapon);
        //}
    }
}

/*
        for(int i = 0; i < weaponSelect[].Length; i++)
        {
            if (weaponSelect[id] == weaponSelect[i]) continue;

            weaponSelect[i].SetActive(false);
        }

JUST AN EXAMPLE
*/
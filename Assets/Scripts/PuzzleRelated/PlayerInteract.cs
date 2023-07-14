using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    bool playerInRange;

    [SerializeField] PlayerInput PlayerInput;

    [SerializeField] UnityEvent onInteractEvent;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        InputAction interactKeyPressed = PlayerInput.actions["Interact"];

        interactKeyPressed.started += OnInteract;

        interactKeyPressed.Enable();
    }

    private void OnDisable()
    {
        InputAction interactKeyPressed = PlayerInput.actions["Interact"];

        interactKeyPressed.started -= OnInteract;

        interactKeyPressed.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            onInteractEvent.Invoke();
        }
    }
}

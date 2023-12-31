using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] bool playerInRange;

    [SerializeField] PlayerInput PlayerInput;

    [SerializeField] UnityEvent onInteractEvent;

    private bool interactedWith;

    private void OnEnable()
    {
        if (PlayerInput != null)
        {
            InputAction interactKeyPressed = PlayerInput.actions["Interact"];

            interactKeyPressed.started += OnInteract;
        }
    }

    private void OnDisable()
    {
        if (PlayerInput != null)
        {
            InputAction interactKeyPressed = PlayerInput.actions["Interact"];

            interactKeyPressed.started -= OnInteract;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            interactedWith = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        if (playerInRange && !interactedWith)
        {
            Debug.Log("interacted");
            onInteractEvent.Invoke();
            interactedWith = true;
        }
    }
}

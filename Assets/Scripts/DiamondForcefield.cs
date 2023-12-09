using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DiamondForcefield : MonoBehaviour
{
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerManager PlayerManager;
    [SerializeField] private bool playerInRange;
    [SerializeField] private UnityEvent onInteractEvent;
    
        
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
    
    void OnInteract(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (PlayerManager.diamondsCollected == 3)
                onInteractEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.TryGetComponent(out PlayerManager playerManager);
        if (playerManager)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}

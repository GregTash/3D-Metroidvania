using UnityEngine;
using UnityEngine.InputSystem;

public class EquippedItemManager : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    public bool equipped = false;

    private void OnEnable()
    {
        InputAction useEquippedKeyPress = playerInput.actions["Attack"];

        useEquippedKeyPress.started += OnUse;
    }

    private void OnDisable()
    {
        InputAction useEquippedKeyPress = playerInput.actions["Attack"];

        useEquippedKeyPress.started -= OnUse;
    }

    void OnUse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PlayerEvents.onUseEquippedEvent?.Invoke();
        }
    }
}

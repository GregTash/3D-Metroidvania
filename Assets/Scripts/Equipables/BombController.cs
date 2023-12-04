using UnityEngine;
using UnityEngine.InputSystem;

public class BombController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    private void OnEnable()
    {
        _playerControls.Default.Attack.started += OnThrow;
        playerInput.actions["Attack"].started += OnThrow;
    }

    private void OnDisable()
    {
        _playerControls.Default.Attack.started -= OnThrow;
        playerInput.actions["Attack"].started -= OnThrow;
    }

    void OnThrow(InputAction.CallbackContext context)
    {
        Debug.Log("WORKING THROW!");
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class GlidePower : MonoBehaviour
{
    PlayerMovement _playerMovement;
    [SerializeField] PlayerInput playerInput;
    Rigidbody _playerRb;
    float _glideVelocity = -1f, _glideSpeed = 15f, _playerSpeed;

    private void Start()
    {
        _playerMovement = transform.root.GetComponent<PlayerMovement>();
        _playerRb = transform.root.GetComponent<Rigidbody>();

        _playerSpeed = _playerMovement.moveSpeed;
    }

    private void OnEnable()
    {
        InputAction glideKeyPress = playerInput.actions["Jump"];
        glideKeyPress.started += GlideEnable;
        glideKeyPress.canceled += GlideDisable;
    }

    private void OnDisable()
    {
        InputAction glideKeyPress = playerInput.actions["Jump"];
        glideKeyPress.started -= GlideEnable;
        glideKeyPress.canceled -= GlideDisable;
    }

    private void Update()
    {
        if(_playerMovement.TouchingSomething)
        {
            GlideDisableNoCallbackContext();
        }
    }

    void GlideEnable(InputAction.CallbackContext context)
    {
        if (_playerMovement.Grounded) return;

        _playerMovement.moveSpeed = _glideSpeed;

        _playerRb.useGravity = false;
        _playerRb.velocity = new Vector3(_playerRb.velocity.x, _glideVelocity, _playerRb.velocity.z);
    }

    void GlideDisable(InputAction.CallbackContext context)
    {
        GlideDisableNoCallbackContext();
    }

    void GlideDisableNoCallbackContext()
    {
        _playerRb.useGravity = true;
        _playerMovement.moveSpeed = _playerSpeed;
    }
}

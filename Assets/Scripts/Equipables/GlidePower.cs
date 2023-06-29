using UnityEngine;
using UnityEngine.InputSystem;

public class GlidePower : MonoBehaviour
{
    PlayerMovement _playerMovement;
    [SerializeField] PlayerInput playerInput;
    Rigidbody _playerRb;
    float _glideVelocity = -1f, _glideSpeed = 15f, _playerSpeed;
    bool _disableUsage = false, _currentlyGliding = false;
    public float MaxGlidingStamina { get; private set; } = 100f;
    public float GlidingStamina { get; private set; }
    float _staminaDrain = 35f, _staminaRegain = 70f;

    private void Start()
    {
        _playerMovement = transform.root.GetComponent<PlayerMovement>();
        _playerRb = transform.root.GetComponent<Rigidbody>();

        _playerSpeed = _playerMovement.moveSpeed;

        GlidingStamina = MaxGlidingStamina;
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
        Debug.Log(_currentlyGliding);

        if(_playerMovement.TouchingSomething || GlidingStamina <= 0)
        {
            GlideDisableNoCallbackContext();
        }

        if(_playerMovement.Grounded)
        {
            _disableUsage = false;
        }

        if(GlidingStamina > MaxGlidingStamina)
        {
            GlidingStamina = MaxGlidingStamina;
        }

        if(_currentlyGliding)
        {
            DrainGlideStamina();
        }
        else
        {
            IncreaseGlideStamina();
        }
    }

    void GlideEnable(InputAction.CallbackContext context)
    {
        if (_playerMovement.Grounded || _disableUsage) return;

        _disableUsage = true;
        _currentlyGliding = true;

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

        _currentlyGliding = false;

        if (GlidingStamina < 0)
        {
            GlidingStamina = 0;
        }
    }

    void DrainGlideStamina()
    {
        GlidingStamina -= _staminaDrain * Time.deltaTime;
    }

    void IncreaseGlideStamina()
    {
        GlidingStamina += _staminaRegain * Time.deltaTime;
    }
}

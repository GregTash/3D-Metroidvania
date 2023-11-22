using UnityEngine;
using UnityEngine.InputSystem;

public class GlidePower : MonoBehaviour
{
    PlayerMovement _playerMovement;
    AudioSource _audioSource;
    [SerializeField] PlayerInput playerInput;
    Rigidbody _playerRb;
    float _glideVelocity = -1f, _glideSpeed = 15f, _playerSpeed;
    public bool disableUsage = false;
    [HideInInspector] public bool currentlyGliding = false;
    public float MaxGlidingStamina { get; private set; } = 100f;
    public float GlidingStamina { get; private set; }
    float _staminaDrain = 35f, _staminaRegain = 100f;

    private void Start()
    {
        _playerMovement = transform.root.GetComponent<PlayerMovement>();
        _playerRb = transform.root.GetComponent<Rigidbody>();

        _playerSpeed = _playerMovement.moveSpeed;

        GlidingStamina = MaxGlidingStamina;

        _audioSource = GetComponent<AudioSource>();
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
        if (!_playerMovement.detectInput) _audioSource.Stop();

        if(_playerMovement.TouchingSomething || GlidingStamina <= 0)
        {
            if(currentlyGliding)
            {
                GlideDisableNoCallbackContext();
            }
        }

        if(_playerMovement.Grounded)
        {
            IncreaseGlideStamina();
        }

        if(GlidingStamina > MaxGlidingStamina)
        {
            GlidingStamina = MaxGlidingStamina;
        }

        if(currentlyGliding)
        {
            DrainGlideStamina();
        }
    }

    void GlideEnable(InputAction.CallbackContext context)
    {
        if (!_playerMovement.detectInput) return;

        if (_playerMovement.Grounded || disableUsage || _playerMovement.TouchingSomething || GlidingStamina <= 0) return;

        currentlyGliding = true;

        _audioSource.Play();

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
        if (!currentlyGliding) return;

        _playerRb.useGravity = true;
        _playerMovement.moveSpeed = _playerSpeed;

        currentlyGliding = false;

        _audioSource.Stop();

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

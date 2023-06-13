using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool detectInput = true;

    [Header("Movement")]
    [SerializeField] float moveSpeed;

    [SerializeField] float groundDrag;

    [SerializeField] float jumpForce;

    [Header("GroundCheck")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask ignoreLayers;
    bool _grounded = false;

    [SerializeField] Transform orientation;

    float _horizontalInput;
    float _verticalInput;

    Vector3 _moveDir;

    Rigidbody _rb;

    public PlayerInput PlayerInput { get; private set; }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        PlayerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if(detectInput) GetInput();

        GroundCheck();

        MoveSpeedControl();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnEnable()
    {
        InputAction jumpKeyPress = PlayerInput.actions["Jump"];

        jumpKeyPress.started += OnJump;

        jumpKeyPress.Enable();
    }

    private void OnDisable()
    {
        InputAction jumpKeyPress = PlayerInput.actions["Jump"];

        jumpKeyPress.Disable();

        jumpKeyPress.started -= OnJump;
    }

    void GetInput()
    {
        _horizontalInput = PlayerInput.actions["Horizontal"].ReadValue<float>();
        _verticalInput = PlayerInput.actions["Vertical"].ReadValue<float>();
    }

    void OnMove()
    {
        //Calculate the movement direction and then move forward.
        _moveDir = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

        _rb.AddForce(_moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    void Jump()
    {
        //Reset the y velocity (to ensure the player will always jump at the exact same height).
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(_grounded)
            {
                Jump();
            }
        }
    }

    void GroundCheck()
    {
        _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ~ignoreLayers);

        if (_grounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = 0;
        }
    }

    void MoveSpeedControl()
    {
        Vector3 flatVelocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        //Limit the velocity if required.
        if(flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            _rb.velocity = new Vector3(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
        }
    }
}

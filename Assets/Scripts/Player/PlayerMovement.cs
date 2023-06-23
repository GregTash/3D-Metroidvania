using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool detectInput = true;

    [Header("Movement")]
    public float moveSpeed;

    [SerializeField] float groundDrag;

    [SerializeField] float jumpForce;

    [Header("GroundCheck")]
    [SerializeField] float playerHeight, maxWalkableAngle = 45f;
    [SerializeField] LayerMask ignoreLayers;
    public bool Grounded { get; private set; } = false;
    public bool TouchingSomething { get; private set; }

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
        SlopeCheck();
    }

    private void OnEnable()
    {
        InputAction jumpKeyPress = PlayerInput.actions["Jump"];

        jumpKeyPress.started += OnJump;
    }

    private void OnDisable()
    {
        InputAction jumpKeyPress = PlayerInput.actions["Jump"];

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
            if(Grounded)
            {
                Jump();
            }
        }
    }

    void GroundCheck()
    {
        Grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ~ignoreLayers);

        if (Grounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = 0;
        }
    }

    void SlopeCheck()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, playerHeight + 3f, ~ignoreLayers);

        if (hit.transform != null)
        {
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            if (slopeAngle >= maxWalkableAngle && !Grounded)
            {
                if (_horizontalInput != 0 || _verticalInput != 0)
                {
                    _rb.AddForce(Vector3.up * Physics.gravity.y);
                }
            }
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

    private void OnCollisionEnter(Collision collision)
    {
        TouchingSomething = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        TouchingSomething = false;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInput playerInput;
    Animator _playerAnimator;

    public static readonly int MoveInput = Animator.StringToHash("MoveInput");
    public static readonly int Moving = Animator.StringToHash("Moving");
    public static readonly int YVelocity = Animator.StringToHash("YVelocity");
    public static readonly int Grounded = Animator.StringToHash("Grounded");

    private void OnEnable()
    {
        InputAction jumpKeyPress = playerInput.actions["Jump"];
        jumpKeyPress.started += OnJump;
    }

    private void OnDisable()
    {
        InputAction jumpKeyPress = playerInput.actions["Jump"];
        jumpKeyPress.started -= OnJump;
    }

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerRb.velocity.x > 2 || playerRb.velocity.x < -2 || playerRb.velocity.z > 2 || playerRb.velocity.z < -2) _playerAnimator.SetBool(Moving, true); 
        else _playerAnimator.SetBool(Moving, false);

        _playerAnimator.SetFloat(YVelocity, playerRb.velocity.y);
        _playerAnimator.SetBool(Grounded, playerMovement.Grounded);
    }

    void OnJump(InputAction.CallbackContext context)
    {
        _playerAnimator.Play("Jump");
    }
}

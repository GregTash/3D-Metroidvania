using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GlidePower glidePower;
    [SerializeField] StompPower stompPower;
    Animator _playerAnimator;

    bool _stompAnimationPlaying = false;

    public static readonly int MoveInput = Animator.StringToHash("MoveInput");
    public static readonly int GlideInput = Animator.StringToHash("GlideInput");
    public static readonly int Moving = Animator.StringToHash("Moving");
    public static readonly int YVelocity = Animator.StringToHash("YVelocity");
    public static readonly int Grounded = Animator.StringToHash("Grounded");
    public static readonly int Alive = Animator.StringToHash("Alive");

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

        if (glidePower.currentlyGliding)
        {
            _playerAnimator.SetBool(GlideInput, true);
            _playerAnimator.Play("Gliding");
        }
        else _playerAnimator.SetBool(GlideInput, false);

        _playerAnimator.SetFloat(YVelocity, playerRb.velocity.y);
        _playerAnimator.SetBool(Grounded, playerMovement.Grounded);

        if(stompPower.stomping && !_stompAnimationPlaying)
        {
            _playerAnimator.Play("Stomp");
            _stompAnimationPlaying = true;
        }
        else if (!stompPower.stomping)
        {
            _stompAnimationPlaying = false;
        }
    }

    void OnJump(InputAction.CallbackContext context)
    {
        _playerAnimator.Play("Jump");
    }
}

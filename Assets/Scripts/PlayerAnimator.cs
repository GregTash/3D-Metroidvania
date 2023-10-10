using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    Animator _playerAnimator;

    public static readonly int MoveInput = Animator.StringToHash("MoveInput");
    public static readonly int Moving = Animator.StringToHash("Moving");

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerRb.velocity.x > 2 || playerRb.velocity.x < -2 || playerRb.velocity.z > 2 || playerRb.velocity.z < -2) _playerAnimator.SetBool(Moving, true); 
        else _playerAnimator.SetBool(Moving, false);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class BombController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Transform playerCameraTransform;
    PlayerControls _playerControls;

    [SerializeField] GameObject bombObj;

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
        if (playerManager.bombs > 0)
        {
            GameObject newBomb = Instantiate(bombObj, transform.position + (transform.forward) + new Vector3(0, 1, 0), bombObj.transform.rotation);
            newBomb.GetComponent<Rigidbody>().AddForce(playerCameraTransform.forward * 50, ForceMode.Impulse);
            playerManager.bombs--;
        }
    }
}

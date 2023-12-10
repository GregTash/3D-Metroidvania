using UnityEngine;
using UnityEngine.InputSystem;

public class BombController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Transform playerCameraTransform;
    PlayerControls _playerControls;

    [SerializeField] GameObject bombObj;
    [SerializeField] float timeBeforeThrowAgain = 1.0f;
    float _tempTimeBeforeThrowAgain = 0.0f;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    private void OnEnable()
    {
        playerInput.actions["Attack"].started += OnThrow;
        _tempTimeBeforeThrowAgain = 0.0f;
    }

    private void OnDisable()
    {
        playerInput.actions["Attack"].started -= OnThrow;
        _tempTimeBeforeThrowAgain = 0.0f;
    }

    private void Update()
    {
        if (_tempTimeBeforeThrowAgain > 0)
        {
            _tempTimeBeforeThrowAgain -= Time.deltaTime;
        }
    }

    void OnThrow(InputAction.CallbackContext context)
    {
        if (playerManager.bombs > 0)
        {
            if (_tempTimeBeforeThrowAgain > 0) return;

            GameObject newBomb = Instantiate(bombObj, transform.position + (transform.forward) + new Vector3(0, 1, 0), bombObj.transform.rotation);
            newBomb.GetComponent<Rigidbody>().AddForce(playerCameraTransform.forward * 50, ForceMode.Impulse);
            playerManager.bombs--;

            _tempTimeBeforeThrowAgain = timeBeforeThrowAgain;
        }
    }
}

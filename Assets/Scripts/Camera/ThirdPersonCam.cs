using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    //Two of the same variable, so the player's input values can be accessed outside of this script.
    [SerializeField] PlayerInput playerInput;
    public PlayerInput PlayerInput { get; private set; }

    [SerializeField] Transform orientation;
    [SerializeField] Transform player;
    [SerializeField] Transform playerObj;
    [SerializeField] Transform aimLookAt;

    [SerializeField] float rotationSpeed;

    [SerializeField] CameraMode cameraMode;

    [SerializeField] CinemachineCameraOffset camOffset;

    [SerializeField] GameObject crosshairObj;

    public enum CameraMode
    {
        Normal,
        Aiming
    }

    private void Start()
    {
        CursorSetup();

        PlayerInput = playerInput;
    }

    void Update()
    {
        OnLook();
    }

    private void OnLook()
    {
        //Get the input values and set the input direction.
        float horizontalInput = PlayerInput.actions["Horizontal"].ReadValue<float>();
        float verticalInput = PlayerInput.actions["Vertical"].ReadValue<float>();
        float aimInput = PlayerInput.actions["Aim"].ReadValue<float>();
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (aimInput != 0)
        {
            cameraMode = CameraMode.Aiming;
        }
        else
        {
            cameraMode = CameraMode.Normal;
        }

        if (cameraMode == CameraMode.Normal)
        {
            crosshairObj.SetActive(false);

            //Set the view direction and orientation.
            Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            orientation.forward = viewDir.normalized;

            //Set the forward direction of the playerObj.
            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, rotationSpeed * Time.deltaTime);
            }

            camOffset.enabled = false;
        }
        else if (cameraMode == CameraMode.Aiming)
        {
            crosshairObj.SetActive(true);

            //Set the view direction and orientation.
            Vector3 viewDir = aimLookAt.position - new Vector3(transform.position.x, aimLookAt.position.y, transform.position.z);
            orientation.forward = viewDir.normalized;

            camOffset.enabled = true;

            playerObj.forward = viewDir.normalized;
        }
    }

    void CursorSetup()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

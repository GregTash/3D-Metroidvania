using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Intro : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.actions["Jump"].started += LoadMainMenuOnPress;
        playerInput.actions["Pause"].started += LoadMainMenuOnPress;
    }

    private void OnDisable()
    {
        playerInput.actions["Jump"].started -= LoadMainMenuOnPress;
        playerInput.actions["Pause"].started -= LoadMainMenuOnPress;
    }

    void LoadMainMenuOnPress(InputAction.CallbackContext context)
    {
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(2);
    }
}

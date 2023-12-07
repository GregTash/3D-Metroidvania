using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class IntroCredits : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.actions["Jump"].started += LoadIntroOnPress;
        playerInput.actions["Pause"].started += LoadIntroOnPress;
    }

    private void OnDisable()
    {
        playerInput.actions["Jump"].started -= LoadIntroOnPress;
        playerInput.actions["Pause"].started -= LoadIntroOnPress;
    }

    void LoadIntroOnPress(InputAction.CallbackContext context)
    {
        LoadIntro();
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene(1);
    }
}

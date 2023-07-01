using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameUI;

    [SerializeField] PlayerInput playerInput;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void OnEnable()
    {
        InputAction togglePause = playerInput.actions["Pause"];
        togglePause.started += PauseGame;
    }

    private void OnDisable()
    {
        InputAction togglePause = playerInput.actions["Pause"];
        togglePause.started -= PauseGame;
    }

    void PauseGame(InputAction.CallbackContext context)
    {
        if (!pauseUI.gameObject.activeSelf)
        {
            pauseUI.SetActive(true);
            gameUI.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            pauseUI.SetActive(false);
            gameUI.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}

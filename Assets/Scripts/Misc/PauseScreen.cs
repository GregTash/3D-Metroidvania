using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameUI;

    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerMovement playerMovement;
    
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
            playerMovement.detectInput = false;
        }
        else
        {
            pauseUI.SetActive(false);
            gameUI.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            playerMovement.detectInput = true;
        }
    }

    public void ResumeGame(InputAction.CallbackContext context)
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}

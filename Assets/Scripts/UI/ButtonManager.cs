using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnPressStart()
    {
        SceneManager.LoadScene("MainScene");
        PlayerPrefs.DeleteAll();
    }

    public void OnPressExit()
    {
        Application.Quit();
    }
}

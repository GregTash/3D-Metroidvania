using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnPressStart()
    {
        SceneManager.LoadScene("Loading");
        PlayerPrefs.DeleteAll();
    }

    public void OnPressExit()
    {
        Application.Quit();
    }
}

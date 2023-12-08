using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInstant : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("MainScene");
    }
}

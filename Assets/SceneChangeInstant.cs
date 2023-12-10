using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInstant : MonoBehaviour
{
    public string nextScene;
    void Start()
    {
        SceneManager.LoadScene(nextScene);
    }
}

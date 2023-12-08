using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] string sceneToLoad;
    float _alpha = 0.0f;
    bool _enabled = false;

    private void Update()
    {
        if (_enabled)
        {
            _alpha += Time.deltaTime / 2;
            image.color = new Color(0, 0, 0, _alpha);

            if (_alpha >= 2)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    public void EnableFadeToBlack()
    {
        _enabled = true;
    }
}
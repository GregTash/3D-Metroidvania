using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager player);

        if (!player) return;

        SceneManager.LoadScene("End");
    }
}

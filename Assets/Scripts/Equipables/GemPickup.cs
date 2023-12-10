using UnityEngine;
using UnityEngine.SceneManagement;

public class GemPickup : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt(transform.name) > 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager player);

        if (!player) return;

        player.gemsCollected++;

        PlayerPrefs.SetInt(transform.name, 0);

        Destroy(gameObject);
    }
}

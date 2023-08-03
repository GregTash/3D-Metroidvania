using UnityEngine;
using UnityEngine.SceneManagement;

public class GemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager player);

        if (!player) return;

        player.gemsCollected++;

        Destroy(gameObject);

        if (player.gemsCollected == 2)
        {
            SceneManager.LoadScene("Leaderboard");
        }
        
    }
}

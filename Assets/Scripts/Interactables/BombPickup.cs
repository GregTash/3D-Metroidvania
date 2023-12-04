using UnityEngine;

public class BombPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);

        if (playerManager)
        {
            playerManager.bombs++;
            Destroy(gameObject);
        }
    }
}

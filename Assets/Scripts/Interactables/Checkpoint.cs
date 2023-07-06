using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);

        if(playerManager)
        {
            playerManager.respawnPoint = respawnPoint;
        }
    }
}

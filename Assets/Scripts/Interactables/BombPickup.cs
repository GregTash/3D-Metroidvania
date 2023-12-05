using UnityEngine;

public class BombPickup : MonoBehaviour
{
    [SerializeField] int amount;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);

        if (playerManager)
        {
            playerManager.bombs += amount;
            Destroy(gameObject);
        }
    }
}

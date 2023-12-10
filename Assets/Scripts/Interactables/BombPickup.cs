using UnityEngine;

public class BombPickup : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] private AudioClip _clip;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);

        if (playerManager)
        {
            AudioSource.PlayClipAtPoint(_clip, transform.position, .75f);
            playerManager.bombs += amount;
            Destroy(gameObject);
        }
    }
}

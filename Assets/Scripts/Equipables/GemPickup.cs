using UnityEngine;
using UnityEngine.SceneManagement;

public class GemPickup : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private AudioSource _audioSource;
    private void Start()
    {
        if (PlayerPrefs.GetInt(transform.name) > 0)
        {
            Destroy(gameObject, 5);
        }
    }

    public void AddGemToInventory()
    {
        playerManager.gemsCollected++;
        
        PlayerPrefs.SetInt(transform.name, 1);

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        
        Destroy(gameObject, 5);
    }
}

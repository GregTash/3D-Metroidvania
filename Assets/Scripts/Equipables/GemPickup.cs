using UnityEngine;
using UnityEngine.SceneManagement;

public class GemPickup : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private void Start()
    {
        if (PlayerPrefs.GetInt(transform.name) > 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddGemToInventory()
    {
        playerManager.gemsCollected++;
        
        PlayerPrefs.SetInt(transform.name, 1);
        
        Destroy(gameObject);
    }
}

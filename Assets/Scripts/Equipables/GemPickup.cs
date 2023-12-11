using UnityEngine;
using UnityEngine.SceneManagement;

public class GemPickup : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    public void AddGemToInventory()
    {
        playerManager.gemsCollected++;
        
        PlayerPrefs.SetInt(transform.name, 1);

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        
        Destroy(gameObject, 5);
    }
}

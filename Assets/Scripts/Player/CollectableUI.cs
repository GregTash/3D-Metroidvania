using UnityEngine;
using TMPro;

public class CollectableUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectableText;
    [SerializeField] PlayerManager _playerManager;

    public static int collected = 0;

    // Update is called once per frame
    void Update()
    {
        collectableText.text = "Collectables: " + _playerManager.collectables;
        collected = _playerManager.collectables;
    }
}

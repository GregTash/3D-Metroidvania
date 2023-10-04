using UnityEngine;
using TMPro;

public class CollectableUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectableText;
    [SerializeField] PlayerManager _playerManager;

    public static int collected = 0;

    void Update()
    {
        collectableText.text = _playerManager.collectables.ToString();
        collected = _playerManager.collectables;
    }
}

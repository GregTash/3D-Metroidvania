using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemsCollectedUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gemCollectText;
    [SerializeField] PlayerManager _playerManager;

    public static int gemsCollect = 0;

    void Update()
    {
        gemCollectText.text = _playerManager.gemsCollected.ToString();
        gemsCollect = _playerManager.gemsCollected;
    }
}

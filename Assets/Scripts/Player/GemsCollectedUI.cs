using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemsCollectedUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gemCollectText;
    [SerializeField] PlayerManager _playerManager;

    public static int gemsCollect = 0;

    // Update is called once per frame
    void Update()
    {
        gemCollectText.text = "Gems Collected: " + _playerManager.gemsCollected;
        gemsCollect = _playerManager.gemsCollected;
    }
}

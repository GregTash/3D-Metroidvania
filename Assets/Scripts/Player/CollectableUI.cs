using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectableText;
    [SerializeField] PlayerManager _playerManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collectableText.text = "Collectables: " + _playerManager.collectables;
    }
}

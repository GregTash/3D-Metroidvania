using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombCounter : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private TextMeshProUGUI bombCounter;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bombCounter.text = "x" + _playerManager.bombs;
    }
}

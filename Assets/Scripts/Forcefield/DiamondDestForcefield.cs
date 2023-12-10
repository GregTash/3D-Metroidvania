using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondDestForcefield : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    private void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerManager.diamondsCollected >= 3)
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 1.5f);
        }
    }
}

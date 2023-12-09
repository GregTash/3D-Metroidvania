using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDiamond : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private void Start()
    {
        if (PlayerPrefs.GetInt(transform.name) > 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddDiamondToInventory()
    {
        playerManager.diamondsCollected++;
        
        PlayerPrefs.SetInt(transform.name, 1);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDiamond : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private AudioClip _clip;
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

        if (playerManager.diamondsCollected >= 3)
        {
            AudioSource.PlayClipAtPoint(_clip, playerManager.transform.position, .5f);
        }
        
        PlayerPrefs.SetInt(transform.name, 1);
    }
}

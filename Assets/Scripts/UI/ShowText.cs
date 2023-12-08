using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] private GameObject textObject;
    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.TryGetComponent(out PlayerManager _playerManager);
        if (_playerManager)
        {
            textObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textObject.SetActive(false);
    }
}

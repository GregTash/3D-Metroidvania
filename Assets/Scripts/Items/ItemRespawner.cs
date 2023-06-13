using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawner : MonoBehaviour
{
    [SerializeField] GameObject itemToRespawn;
    [SerializeField] float respawnTime = 4f;
    bool _respawning = false;

    private void Start()
    {
        Instantiate(itemToRespawn, transform);
    }

    void Update()
    {
        if(GetChildCount() <= 1 && _respawning == false)
        {
            StartCoroutine(RespawnItem());
        }
    }

    int GetChildCount()
    {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        return children.Length;
    }

    IEnumerator RespawnItem()
    {
        _respawning = true;
        yield return new WaitForSeconds(respawnTime);
        Instantiate(itemToRespawn, transform);
        _respawning = false;
    }
}

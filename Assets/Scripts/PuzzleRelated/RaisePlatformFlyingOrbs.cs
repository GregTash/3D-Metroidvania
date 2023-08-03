using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class RaisePlatformFlyingOrbs : MonoBehaviour
{
    public GameObject[] orbsToDestroy;
    public GameObject platform;

    private void Start()
    {

    }

    private void Update()
    {
        OnDestroyedOrb();
        if (orbsToDestroy.Length == 0)
        {
            platform.transform.DOMoveY(-8.2f, 1f);
        }
    }

    void OnDestroyedOrb()
    {
        for (int i = 0; i < orbsToDestroy.Length; i++)
        {
            if (orbsToDestroy[i] == null)
            {
                // The GameObject has been destroyed, remove it from the array
                RemoveGameObjectFromArray(i);
            }
        }
    }

    void RemoveGameObjectFromArray(int indexToRemove)
    {
        if (indexToRemove < 0 || indexToRemove >= orbsToDestroy.Length)
            return;

        for (int i = indexToRemove; i < orbsToDestroy.Length - 1; i++)
        {
            orbsToDestroy[i] = orbsToDestroy[i + 1];
        }

        // Resize the array to remove the last element (which is now a duplicate)
        System.Array.Resize(ref orbsToDestroy, orbsToDestroy.Length - 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPuzzle : MonoBehaviour
{
    public GameObject[] birdsToDestroy;
    public GameObject collectable;

    private void Start()
    {
        
    }

    private void Update()
    {
        OnDestroyedBird();
        if (birdsToDestroy.Length == 0)
        {
            collectable.SetActive(true);
        }
    }

    void OnDestroyedBird() 
    {
        for (int i = 0; i < birdsToDestroy.Length; i++)
        {
            if (birdsToDestroy[i] == null)
            {
                // The GameObject has been destroyed, remove it from the array
                RemoveGameObjectFromArray(i);
            }
        }
    }

    void RemoveGameObjectFromArray(int indexToRemove)
    {
        if (indexToRemove < 0 || indexToRemove >= birdsToDestroy.Length)
            return;

        for (int i = indexToRemove; i < birdsToDestroy.Length - 1; i++)
        {
            birdsToDestroy[i] = birdsToDestroy[i + 1];
        }

        // Resize the array to remove the last element (which is now a duplicate)
        System.Array.Resize(ref birdsToDestroy, birdsToDestroy.Length - 1);
    }
}

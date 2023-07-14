using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] float newPosition;
    [SerializeField] GameObject progressTrackers;
    [SerializeField] GameObject progressOne;
    [SerializeField] GameObject progressTwo;
    [SerializeField] GameObject progressThree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (progressOne.activeInHierarchy && progressTwo.activeInHierarchy && progressThree.activeInHierarchy)
        {
            transform.DOMoveY(newPosition, 5f);
            Destroy(progressTrackers);
        }
    }

    
}

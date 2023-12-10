using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForceField : MonoBehaviour
{
    [SerializeField] private GameObject forceField;
    
    public void DestroyField()
    {
        GetComponent<AudioSource>().Play();
        Destroy(forceField, 1.5f);
    }
}

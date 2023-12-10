using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForceField : MonoBehaviour
{
    [SerializeField] private GameObject forceField;
    
    public void DestroyField()
    {
        Destroy(forceField, 1f);
    }
}

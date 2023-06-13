using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform teleportTransform;

    private void OnTriggerEnter(Collider collision)
    {
        Teleport(collision.transform);
    }

    void Teleport(Transform teleportObj)
    {
        teleportObj.transform.position = teleportTransform.position;
    }
}

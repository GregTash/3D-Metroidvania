using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnFall : MonoBehaviour
{
    [SerializeField] float yPosForDeath = -500f;

    void FixedUpdate()
    {
        if (transform.position.y <= yPosForDeath)
        {
            Destroy(gameObject);
        }
    }
}
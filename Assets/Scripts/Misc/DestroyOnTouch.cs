using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.TryGetComponent(out PlayerManager playerManager);

        if (playerManager)
        {
            Destroy(gameObject);
        }
    }
}

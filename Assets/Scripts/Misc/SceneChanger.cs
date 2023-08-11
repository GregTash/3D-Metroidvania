using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string scene;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager playerManager);

        if (playerManager)
            SceneManager.LoadScene(scene);
    }
}

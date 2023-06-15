using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCHange : MonoBehaviour
{
    public GameObject endPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            endPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

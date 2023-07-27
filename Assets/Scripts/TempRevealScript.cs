using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempRevealScript : MonoBehaviour
{
    public GameObject revealedText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            revealedText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        revealedText.SetActive(false);
    }
}

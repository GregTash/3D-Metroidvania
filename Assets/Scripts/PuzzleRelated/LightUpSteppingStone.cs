using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpSteppingStone : MonoBehaviour
{
    public Material litMaterial;
    private Material originalMaterial;
    private new Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            renderer.material = litMaterial;
            // Optionally, trigger any other effects you want when stepping on the stone.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            renderer.material = originalMaterial;
            // Optionally, turn off any additional effects when leaving the stone.
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingStoneMaterial : MonoBehaviour
{
    public Material steppedOnMaterial;

    private Material originalMaterial;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with this object
        if (other.CompareTag("Player"))
        {
            // Change the material to the "stepped on" material
            renderer.material = steppedOnMaterial;
        }
    }
}

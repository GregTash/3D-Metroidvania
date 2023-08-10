using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] float maxHeight = 1f, speed = 1f;
    [SerializeField] bool inverted = false;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if(!inverted) transform.position = new Vector3(startPos.x, startPos.y + Mathf.Sin(Time.time * speed) * maxHeight, startPos.z);
        else transform.position = new Vector3(startPos.x, startPos.y + Mathf.Sin(Time.time * speed) * maxHeight * -1, startPos.z);
    }
}

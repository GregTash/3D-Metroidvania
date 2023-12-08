using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SinWave : MonoBehaviour
{
    Vector3 startPos;
    Rigidbody _rb;
    [SerializeField] float maxHeight = 1f, speed = 1f;
    [SerializeField] bool inverted = false;
    
    [SerializeField] private bool isRotating;
    [SerializeField] private Vector3 rotationAngle;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        startPos = transform.position;
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void Update()
    {
        if(!inverted) _rb.velocity = new Vector3(0, Mathf.Sin(Time.time * speed) * maxHeight, 0);
        else _rb.velocity = new Vector3(0, (Mathf.Sin(Time.time * speed) * maxHeight) * -1, 0);
        
        if (isRotating)
            transform.Rotate(rotationAngle * (rotationSpeed * Time.deltaTime));
    }
}

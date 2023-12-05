using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

public class RaisePlatform : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float timeTilFall;
    [SerializeField] private float timer;
    private bool triggeredDrop;
    private Vector3 origPosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        origPosition = transform.position;
    }

    private void Update()
    {
        if (triggeredDrop)
        {
            timer += Time.deltaTime;

            if (timer >= timeTilFall)
            {
                DropPlatform();
            }
        }

        if (transform.position.y <= -500)
        {
            Instantiate(this, origPosition, quaternion.identity);
            
            Destroy(this, 2f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        other.transform.TryGetComponent(out PlayerManager playerManager);
        
        if (playerManager)
        {
            triggeredDrop = true;
        }
    }

    void DropPlatform()
    {
        _rb.useGravity = true;

        GetComponent<Collider>().enabled = false;
    }
}

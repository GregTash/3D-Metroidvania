using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float timeTilFall;
    [SerializeField] private float timer;
    private bool triggeredDrop;
    public Vector3 origPosition;
    [SerializeField] private GameObject spawnInObject;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
    }

    private void OnCollisionEnter(Collision other)
    {
        other.transform.TryGetComponent(out PlayerManager playerManager);
        other.transform.TryGetComponent(out RespawnPlatform respawnPlatform);
        
        if (playerManager)
        {
            triggeredDrop = true;
        }

        if (respawnPlatform)
        {
            transform.position = origPosition;
            _rb.useGravity = false;
            _rb.constraints |= RigidbodyConstraints.FreezePositionY;
            timer = 0;
        }
    }

    void DropPlatform()
    {
        _rb.useGravity = true;
        _rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        _rb.mass = 2000f;
        triggeredDrop = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RaisePlatform : MonoBehaviour
{
    [SerializeField] private Vector3 origPosition;
    [SerializeField] private bool isGroundPounded;
    [SerializeField] private Vector3 newPosition;
    [SerializeField] private float time;
    private float _origTime;
    private bool _direction;
    private void Start()
    {
        _origTime = time;
        origPosition = transform.position;
        _direction = true;
    }

    private void Update()
    {
        if (time <= 0)
        {
            if (_direction)
            {
                _direction = false;
            }
            else if (!_direction)
            {
                _direction = true;
            }

            time = _origTime;
        }
        else if (time > 0)
        {
            time -= Time.deltaTime;
        }
        
        if (_direction)
        {
            transform.DOMove(newPosition, time);
        }
        else if (!_direction)
        {
            transform.DOMove(origPosition, time);
        }
    }
}

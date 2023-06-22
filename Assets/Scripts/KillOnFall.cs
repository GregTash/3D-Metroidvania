using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnFall : MonoBehaviour
{
    public bool _grounded = false;
    [SerializeField] float timeBeforeDeath = 5f;
    float _timeBeforeDeath;
    [SerializeField] GameObject enemyObj;

    private void Awake()
    {
        _timeBeforeDeath = timeBeforeDeath;
    }

    void Update()
    {
        if(!_grounded)
        {
            _timeBeforeDeath -= Time.deltaTime;
        }
        else
        {
            _timeBeforeDeath = timeBeforeDeath;
        }

        if(_timeBeforeDeath <= 0)
        {
            Destroy(enemyObj);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _grounded = false;
    }
}